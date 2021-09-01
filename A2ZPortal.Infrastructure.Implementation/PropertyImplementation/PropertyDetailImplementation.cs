using A2ZPortal.Core.ViewModel.PropertyDetail;
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
    }
}
