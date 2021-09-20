using A2ZPortal.Core.ViewModel.PropertyDetail;
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
    public class PropertyDetailCompleteImplementation : IPropertyDetailCompleteRepository
    {
        private readonly string _connectionString;

        public PropertyDetailCompleteImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<CompletePropertyDetailsVm> GetCompletePropertyDetail(int propertyId)
        {
            SqlParameter[] param = { new SqlParameter("@propId", propertyId) };

            var model = new CompletePropertyDetailsVm();
            var imageModels = new List<ImageDetails>();
            var features = new List<Features>();

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetPropertyCompleteDetail,
                System.Data.CommandType.StoredProcedure, param);

            while (reader.Read())
            {
                model.Id = reader.DefaultIfNull<int>("Id");
                model.CategoryId = reader.DefaultIfNull<string>("CategoryId");
                model.LocationName = reader.DefaultIfNull<string>("LocationName");
                model.SubLocationName = reader.DefaultIfNull<string>("SubLocationName");
                model.Budgets = reader.DefaultIfNull<int>("Budgets");
                model.AreaCovered = reader.DefaultIfNull<int>("AreaCovered");
                model.TotalArea = reader.DefaultIfNull<int>("TotalArea");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.ProprtyDescription = reader.DefaultIfNull<string>("ProprtyDescription");
                model.Longitude = reader.DefaultIfNull<string>("Longitude");

                model.Lattitude = reader.DefaultIfNull<string>("Lattitude");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.PlaceId = reader.DefaultIfNull<string>("PlaceId");
                model.BedRooms = reader.DefaultIfNull<int>("BedRooms");
                model.BathRooms = reader.DefaultIfNull<int>("BathRooms");
                model.RoomName = reader.DefaultIfNull<string>("RoomName");
                model.PossesionStatus = reader.DefaultIfNull<string>("PossesionStatus");
                model.FurnishingStatus = reader.DefaultIfNull<string>("FurnishingStatus");
                model.Age = reader.DefaultIfNull<int>("Age");
                model.TotalParking= reader.DefaultIfNull<int>("TotalParking");

                model.Facing = reader.DefaultIfNull<string>("Facing");
                model.FloorNumber= reader.DefaultIfNull<string>("FloorNumber");
                model.TowerBlock= reader.DefaultIfNull<string>("TowerBlock");
                model.UnitNumber= reader.DefaultIfNull<string>("UnitNumber");
                model.TrakheesiNumber= reader.DefaultIfNull<string>("TrakheesiNumber");
                model.DLocationName= reader.DefaultIfNull<string>("DLocationName");
                model.PriceName= reader.DefaultIfNull<string>("PriceName");
                model.ExplaningName= reader.DefaultIfNull<string>("ExplaningName");
                model.DefiningStructure= reader.DefaultIfNull<string>("DefiningStructure");
                model.SuitabelName= reader.DefaultIfNull<string>("SuitabelName");

                model.SpaceType= reader.DefaultIfNull<string>("SpaceType");
                model.Maintaince = reader.DefaultIfNull<int>("Maintaince");
                model.Security_Deposit = reader.DefaultIfNull<string>("Security_Deposit");
                model.NoOfChecks = reader.DefaultIfNull<int>("NoOfChecks");
                model.LandLordDetails = reader.DefaultIfNull<string>("LandLordDetails");
                model.Nameoftheowner = reader.DefaultIfNull<string>("Nameoftheowner");
                model.OwnersEmaiAddress = reader.DefaultIfNull<string>("OwnersEmaiAddress");
                model.MobileNoOftheOwner = reader.DefaultIfNull<string>("MobileNoOftheOwner");
                model.MeasurementType = reader.DefaultIfNull<string>("MeasurementType");
                model.AreaTypeName = reader.DefaultIfNull<string>("AreaTypeName");
            }

            if (reader.NextResult()) {

                while (reader.Read())
                {
                    var imageModel = new ImageDetails();
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
                    var feature = new Features();
                    feature.Feature = reader.DefaultIfNull<string>("AmenitiesName");
                    features.Add(feature);
                }
            }

            model.FeatureDetails = features;
            model.ImageDetails = imageModels;

            return model;
        }
    }
}
