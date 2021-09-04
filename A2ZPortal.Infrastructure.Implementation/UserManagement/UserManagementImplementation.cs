using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Implementation.UserManagement
{
    public class UserManagementImplementation : IUserManagementRepository
    {
        private readonly string _connectionString;

        public UserManagementImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;

        }
        public async Task<IEnumerable<SubModuleDetail>> GetSubModuleDetails()
        {
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetSubModuleDetails,
                System.Data.CommandType.StoredProcedure, null);

            var response = new List<SubModuleDetail>();

            while (reader.Read())
            {
                var model = new SubModuleDetail();
                model.ModuleId = reader.DefaultIfNull<int>("Id");
                model.MoudleName = reader.DefaultIfNull<string>("ModuleName");
                model.SubModuleName = reader.DefaultIfNull<string>("SubModuleName");
                model.ControllerName = reader.DefaultIfNull<string>("ControllerName");
                model.ActionName = reader.DefaultIfNull<string>("ActionName");

                response.Add(model);
            }
            return response;
        }
    }
}
