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
    public class PropertyDashBoradImplementation : IPropertyDashBoradRepository
    {
        private readonly string _connectionString;

        public PropertyDashBoradImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<List<FeaturedPropertyVm>> GetPropertyFeatureDetails(int pageNumber, int pageSize)
        {
            SqlParameter[] param = { new SqlParameter("@PageNbr", pageNumber), new SqlParameter("@PageSize", pageSize) };

            var models = new List<FeaturedPropertyVm>();

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetFeaturedProperty,
                System.Data.CommandType.StoredProcedure, param);

            while (reader.Read())
            {
                var model = new FeaturedPropertyVm();
                model.ImagePath = reader.DefaultIfNull<string>("ImagePath");
                model.PropertyId = reader.DefaultIfNull<int>("Id");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.Description = reader.DefaultIfNull<string>("ProprtyDescription");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.BedRooms = reader.DefaultIfNull<int>("BedRooms");
                model.BathRooms = reader.DefaultIfNull<int>("BathRooms");
                model.TotalArea = reader.DefaultIfNull<decimal>("TotalArea");
                model.CategoryName = reader.DefaultIfNull<string>("CategoryId");
                model.PropertyType = reader.DefaultIfNull<string>("PropertyTypeId");
                model.Price = reader.DefaultIfNull<decimal>("Price");

                models.Add(model);
            }

            return models;
        }
    }
}
