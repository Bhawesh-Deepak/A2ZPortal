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
                model.Id = reader.DefaultIfNull<int>("Age");
                model.Id = reader.DefaultIfNull<int>("TotalParking");

                model.Id = reader.DefaultIfNull<int>("Facing");
                model.Id = reader.DefaultIfNull<int>("FloorNumber");
                model.Id = reader.DefaultIfNull<int>("TowerBlock");
                model.Id = reader.DefaultIfNull<int>("UnitNumber");
                model.Id = reader.DefaultIfNull<int>("TrakheesiNumber");
                model.Id = reader.DefaultIfNull<int>("DLocationName");
                model.Id = reader.DefaultIfNull<int>("PriceName");
                model.Id = reader.DefaultIfNull<int>("ExplaningName");
                model.Id = reader.DefaultIfNull<int>("DefiningStructure");
                model.Id = reader.DefaultIfNull<int>("SuitabelName");

                model.Id = reader.DefaultIfNull<int>("SpaceType");
                model.Id = reader.DefaultIfNull<int>("Maintaince");
                model.Id = reader.DefaultIfNull<int>("Security_Deposit");
                model.Id = reader.DefaultIfNull<int>("NoOfChecks");
                model.Id = reader.DefaultIfNull<int>("LandLordDetails");
                model.Id = reader.DefaultIfNull<int>("Nameoftheowner");
                model.Id = reader.DefaultIfNull<int>("OwnersEmaiAddress");
                model.Id = reader.DefaultIfNull<int>("MobileNoOftheOwner");
                model.Id = reader.DefaultIfNull<int>("MeasurementType");
                model.Id = reader.DefaultIfNull<int>("AreaTypeName");
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
