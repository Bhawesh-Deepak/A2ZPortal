using A2ZPortal.Core.ViewModel.HomeDetail;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.HomeDetailRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Implementation.HomeDetail
{
    public class HomeDetailImplementation : IHomeDetailRepository
    {
        private readonly string _connectionString;

        public HomeDetailImplementation(IConfiguration iconfiguration) 
        {
            _connectionString = iconfiguration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<List<PropertyLocationWiseCountVm>> GetPropertyLocatonWiseCount()
        {
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetPropertyLocationWiseCount,
                        System.Data.CommandType.StoredProcedure, null);

            var models = new List<PropertyLocationWiseCountVm>();

            while (reader.Read())
            {
                var model = new PropertyLocationWiseCountVm();
                model.PropertyCount = reader.DefaultIfNull<int>("PropertyCount");
                model.LocationName = reader.DefaultIfNull<string>("LocationName");
                model.LocationId = reader.DefaultIfNull<int>("LocationId");

                models.Add(model);
            }
            return models;
        }

        public async  Task<List<RecentPropertyDetail>> GetRecentPropertyDetail()
        {
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetRecentPropertyDetails,
                        System.Data.CommandType.StoredProcedure, null);

            var models = new List<RecentPropertyDetail>();

            while (reader.Read())
            {
                var model = new RecentPropertyDetail();
                model.PropertyId = reader.DefaultIfNull<int>("PropertyDetailId");
                model.ImagePath = reader.DefaultIfNull<string>("ImagePath");

                models.Add(model);
            }
            return models;
        }
    }
}
