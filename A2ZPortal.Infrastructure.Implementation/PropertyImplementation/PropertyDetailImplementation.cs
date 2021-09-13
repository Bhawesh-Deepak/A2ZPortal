using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.PropertyList;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Implementation.PropertyImplementation
{
    public class PropertyDetailImplementation : IPropertyDetailRepository
    {
        private readonly string _connectionString;

        public PropertyDetailImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<List<PropertyCompleteListVm>> GetPropertyCompleteDetail(PropertyRequestModel requestModel)
        {
            var models = new List<PropertyCompleteListVm>();
            SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@PageNbr",requestModel.PageNumber),
                    new SqlParameter("@PageSize",requestModel.PageSize==0?6:requestModel.PageSize),
                    new SqlParameter("@LocationId",requestModel.LocationId==0?null: requestModel.LocationId),
                    new SqlParameter("@SubLocationId",requestModel.SubLocationId ==0?null: requestModel.SubLocationId),
                    new SqlParameter("@PropertyTypeId",requestModel.PropertyId ==0?null: requestModel.PropertyId),
                    new SqlParameter("@PropertyStatusId",requestModel.PropertyStatusId ==0?null: requestModel.PropertyStatusId),
                    new SqlParameter("@BedRoomId",requestModel.BedRoomId ==0?null: requestModel.BedRoomId),
                    new SqlParameter("@BathRoomId",requestModel.BathRoomId ==0?null: requestModel.BathRoomId)
                   
                };

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetCompletePropertyDetails,
                System.Data.CommandType.StoredProcedure, sqlParameters);

            while (reader.Read())
            {

                var model = new PropertyCompleteListVm();
                model.PropertyId = reader.DefaultIfNull<int>("Id");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.Description = reader.DefaultIfNull<string>("ProprtyDescription");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.CategoryName = reader.DefaultIfNull<string>("CategoryId");
                model.BedRooms = reader.DefaultIfNull<int>("BedRooms");
                model.BathRooms = reader.DefaultIfNull<int>("BathRooms");
                model.Price = reader.DefaultIfNull<decimal>("Price");
                model.ImagePath = reader.DefaultIfNull<string>("PropImage");
                model.Area = reader.DefaultIfNull<decimal>("TotalArea");
                model.TotalCount = reader.DefaultIfNull<int>("TotalCount");

                models.Add(model);
            }
            return models;
        }

        public async Task<PropertyDetailListVm> GetPropertyDetail(int id)
        {
            var model = new PropertyDetailListVm();
            var imageModels = new List<PropertyImage>();
            var features = new List<string>();

            SqlParameter[] sqlParameters = { new SqlParameter("@propId", id) };
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetPropertyDetailList,
                System.Data.CommandType.StoredProcedure, sqlParameters);
            while (reader.Read())
            {
                model.Id = reader.DefaultIfNull<int>("Id");
                model.CategoryName = reader.DefaultIfNull<string>("CategoryId");
                model.LocationName = reader.DefaultIfNull<string>("LocationName");
                model.SubLocationName = reader.DefaultIfNull<string>("SubLocationName");
                model.Budget = reader.DefaultIfNull<string>("Budgets");
                model.AreaCovered = reader.DefaultIfNull<decimal>("AreaCovered");
                model.TotalArea = reader.DefaultIfNull<decimal>("TotalArea");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.PropertyDescription = reader.DefaultIfNull<string>("ProprtyDescription");
                model.longitude = reader.DefaultIfNull<string>("Longitude");
                model.Latitude = reader.DefaultIfNull<string>("Lattitude");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.PlaceId = reader.DefaultIfNull<string>("PlaceId");
                model.BedRooms = reader.DefaultIfNull<int>("BedRooms");
                model.BathRooms = reader.DefaultIfNull<int>("BathRooms");
                model.RoomName = reader.DefaultIfNull<string>("RoomName");
                model.PossesionStatus = reader.DefaultIfNull<string>("PossesionStatus");
                model.FurnishingStatus = reader.DefaultIfNull<string>("FurnishingStatus");
                model.Age = reader.DefaultIfNull<int>("Age");
                model.TotalParking = reader.DefaultIfNull<int>("TotalParking");
                model.Facing = reader.DefaultIfNull<string>("Facing");
                model.FloorNumber = reader.DefaultIfNull<string>("FloorNumber");
                model.TowerBlock = reader.DefaultIfNull<string>("TowerBlock");
                model.UnitNumber = reader.DefaultIfNull<string>("UnitNumber");
                model.TarkeshiNumber = reader.DefaultIfNull<string>("TrakheesiNumber");
                model.DefiningLocation = reader.DefaultIfNull<string>("DLocationName");
                model.PriceName = reader.DefaultIfNull<string>("PriceName");
                model.ExplaningName = reader.DefaultIfNull<string>("ExplaningName");
                model.DefiningStructure = reader.DefaultIfNull<string>("DefiningStructure");
                model.SuitableName = reader.DefaultIfNull<string>("SuitabelName");
                model.SpaceType = reader.DefaultIfNull<string>("SpaceType");
                model.Maintainence = reader.DefaultIfNull<decimal>("Maintaince");
                model.SecurityDeposit = reader.DefaultIfNull<string>("Security_Deposit");
                model.NoOfChecks = reader.DefaultIfNull<int>("NoOfChecks");
                model.LandLoardDetails = reader.DefaultIfNull<string>("LandLordDetails");
                model.NameofOwner = reader.DefaultIfNull<string>("Nameoftheowner");
                model.EmailAddress = reader.DefaultIfNull<string>("OwnersEmaiAddress");
                model.MobileNumber = reader.DefaultIfNull<string>("MobileNoOftheOwner");
            }

            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    var imageModel = new PropertyImage();
                    imageModel.ImagePath = reader.DefaultIfNull<string>("ImagePath");
                    imageModel.IsExclusive = reader.DefaultIfNull<bool>("IsExclusive");
                    imageModel.IsRecent = reader.DefaultIfNull<bool>("IsRecent");
                    imageModel.IsPrimary = reader.DefaultIfNull<bool>("IsPrimaryImage");

                    imageModels.Add(imageModel);
                }
            }

            if (reader.NextResult())
            {
                while (reader.Read())
                {
                    features.Add(reader.DefaultIfNull<string>("AmenitiesName"));
                }
            }

            model.Amenities = features;
            model.PropertyImages = imageModels;
            return model;
        }

        public async Task<List<PropertyDetailVm>> GetPropertyDetails(PropertyRequestModel requestModel)
        {
            var models = new List<PropertyDetailVm>();
            SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@PageNbr",requestModel.PageNumber),
                    new SqlParameter("@PageSize",requestModel.PageSize),
                    new SqlParameter("@LocationId",requestModel.LocationId==0?null: requestModel.LocationId),
                    new SqlParameter("@SubLocationId",requestModel.SubLocationId ==0?null: requestModel.SubLocationId),
                    new SqlParameter("@PropertyTypeId",requestModel.PropertyId ==0?null: requestModel.PropertyId),
                    new SqlParameter("@PropertyStatusId",requestModel.PropertyStatusId ==0?null: requestModel.PropertyStatusId),
                    new SqlParameter("@BedRoomId",requestModel.BedRoomId ==0?null: requestModel.BedRoomId),
                    new SqlParameter("@BathRoomId",requestModel.BathRoomId ==0?null: requestModel.BathRoomId),
                    new SqlParameter("@BudgetId",requestModel.BUdgetID ==0?null: requestModel.BUdgetID)
                };

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetPropertyDetails,
                System.Data.CommandType.StoredProcedure, sqlParameters);
            while (reader.Read())
            {

                var model = new PropertyDetailVm();
                model.Id = reader.DefaultIfNull<int>("Id");
                model.LocationName = reader.DefaultIfNull<string>("LocationName");
                model.SubLocation = reader.DefaultIfNull<string>("SubLocationName");
                model.PropertyTypeName = reader.DefaultIfNull<string>("PropertyTypeName");
                model.PropertyStatus = reader.DefaultIfNull<string>("PropertyStatus");
                model.BedRoom = reader.DefaultIfNull<int>("BedRooms");
                model.BathRoom = reader.DefaultIfNull<int>("BathRooms");
                model.Budget = reader.DefaultIfNull<decimal>("Budgets");
                model.AreaCovered = reader.DefaultIfNull<decimal>("AreaCovered");
                model.TotalArea = reader.DefaultIfNull<decimal>("TotalArea");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.PlaceId = reader.DefaultIfNull<string>("PlaceId");
                model.Longitude = reader.DefaultIfNull<string>("Longitude");
                model.Latitude = reader.DefaultIfNull<string>("Lattitude");
                model.Images = reader.DefaultIfNull<string>("ImagePath");
                //model.Features = reader.DefaultIfNull<>("FeatureId");

                models.Add(model);
            }
            return models;
        }

        public async Task<List<PropertyListVm>> GetPropertyListVm()
        {
            var models = new List<PropertyListVm>();
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetPropertyList,
                System.Data.CommandType.StoredProcedure, null);
            while (reader.Read())
            {

                var model = new PropertyListVm();
                model.Id = reader.DefaultIfNull<int>("Id");
                model.Location = reader.DefaultIfNull<string>("LocationName");
                model.SubLocation = reader.DefaultIfNull<string>("SubLocationName");
                model.CategoryName = reader.DefaultIfNull<string>("CategoryId");
                model.PropertyType = reader.DefaultIfNull<string>("PropertyTypeId");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.Description = reader.DefaultIfNull<string>("ProprtyDescription");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.Price = reader.DefaultIfNull<decimal>("Price");
                models.Add(model);
            }
            return models;
        }
    }
}
