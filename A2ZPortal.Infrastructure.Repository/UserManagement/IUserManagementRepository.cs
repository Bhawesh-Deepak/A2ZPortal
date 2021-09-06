using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.ViewModel.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.UserManagement
{
    public interface IUserManagementRepository
    {
        Task<IEnumerable<SubModuleDetail>> GetSubModuleDetails();
        Task<IEnumerable<RoleAccess>> GetRoleAccess(int roleId);
        Task<ResponseModel<AuthenticateModel>> AuthenticateUser(string userName, string password);
    }
}
