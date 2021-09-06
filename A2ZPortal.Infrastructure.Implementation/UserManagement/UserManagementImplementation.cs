using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task<ResponseModel<AuthenticateModel>> AuthenticateUser(string userName, string password)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@userName",userName),
                 new SqlParameter("@password",password),
            };

            var response = new AuthenticateModel();

            var userAccessDetails = new List<UserAccessDetailModel>();

            try
            {
                var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.AuthenticateUser,
                  System.Data.CommandType.StoredProcedure, sqlParams);

                while (reader.Read())
                {
                    response.EmployeeCode = reader.DefaultIfNull<string>("EmpCode");
                    response.EmployeeName = reader.DefaultIfNull<string>("EmployeeName");
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        var userAccessDetail = new UserAccessDetailModel();

                        userAccessDetail.ModuleName = reader.DefaultIfNull<string>("ModuleName");
                        userAccessDetail.SubModuleName = reader.DefaultIfNull<string>("SubModuleName");
                        userAccessDetail.ControllerName = reader.DefaultIfNull<string>("ControllerName");
                        userAccessDetail.ActionName = reader.DefaultIfNull<string>("ActionName");
                        userAccessDetail.SubModuleIcon = reader.DefaultIfNull<string>("SubModuleIcon");
                        userAccessDetail.ModuleIcon = reader.DefaultIfNull<string>("ModuleIcon");

                        userAccessDetails.Add(userAccessDetail);
                    }
                }

                response.UserAccessDetails = userAccessDetails;

                return new ResponseModel<AuthenticateModel>(response, null, ResponseStatus.Success, "Login Success");
            }
            catch (Exception ex)
            {
                return new ResponseModel<AuthenticateModel>(null, null, ResponseStatus.Error, ex.Message);

            }


        }

        public async Task<IEnumerable<RoleAccess>> GetRoleAccess(int roleId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@roleId",roleId)
            };
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetRoleAccessDetails,
               System.Data.CommandType.StoredProcedure, sqlParams);

            var response = new List<RoleAccess>();

            while (reader.Read())
            {
                var model = new RoleAccess();
                model.Id = reader.DefaultIfNull<int>("Id");
                model.MoudleName = reader.DefaultIfNull<string>("ModuleName");
                model.SubModuleName = reader.DefaultIfNull<string>("SubModuleName");
                model.ControllerName = reader.DefaultIfNull<string>("ControllerName");
                model.ActionName = reader.DefaultIfNull<string>("ActionName");
                model.IsAccess = (reader.DefaultIfNull<int>("IsAccess") > 0);
                model.RoleAccessId = reader.DefaultIfNull<int>("IsAccess");
                model.SubModuleId = reader.DefaultIfNull<int>("SubModuleId");
                response.Add(model);
            }
            return response;
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
