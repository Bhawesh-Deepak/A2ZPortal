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
    public class VirtualImageImplementation : IVirtualImageRepository
    {
        private readonly string _connectionString;

        public VirtualImageImplementation(IConfiguration configuration) { 
            _connectionString= configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }
        public async Task<VirtiualImageVm> GetVirtualImage(int propId)
        {
            SqlParameter[] param = { new SqlParameter("@propId", propId) };

            var model = new VirtiualImageVm();

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetVirtualImage,
                System.Data.CommandType.StoredProcedure, param);

            while (reader.Read())
            {
                model.ImagePath = reader.DefaultIfNull<string>("ImagePath");
            }

            return model;
        }
    }
}
