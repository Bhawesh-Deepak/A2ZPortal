using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.UserManagement;
using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.UserManagement
{
    public class RoleAccessController : Controller
    {
        private readonly IUserManagementRepository _IUserManagementRepository;
        private readonly IGenericRepository<RoleMaster, int> _IRoleMasterRepository;
        private readonly IGenericRepository<RoleAccessDetail, int> _IRoleAccessDetailRepository;
        public RoleAccessController(IUserManagementRepository userManagementRepository,
            IGenericRepository<RoleMaster, int> roleMasterRepository,
            IGenericRepository<RoleAccessDetail, int> roleAccessDetailRepository)
        {
            _IUserManagementRepository = userManagementRepository;
            _IRoleMasterRepository = roleMasterRepository;
            _IRoleAccessDetailRepository = roleAccessDetailRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = "Role Access";
            ViewBag.RoleDetails = (await _IRoleMasterRepository.GetList(x => x.IsActive == true
            && x.IsDeleted == false)).Entities;
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("RoleAccess", "RoleAcccessIndex"));
        }

        public async Task<IActionResult> RoleAccess(int roleId)
        {
            HttpContext.Session.SetInt32("RoleId", roleId);
            var response = await _IUserManagementRepository.GetRoleAccess(roleId);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("RoleAccess", "RoleAccessDetail"), response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAccess(List<RoleAccess> models)
        {
           var deleteResponse = await DeleteRoleAccess(Convert.ToInt32(HttpContext.Session.GetInt32("RoleId")));
            List<RoleAccessDetail> roleAccesses = new List<RoleAccessDetail>();

            models.ForEach(item =>
            {
                var model = new RoleAccessDetail();
                model.RoleId = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
                model.Id = item.RoleAccessId;
                model.SubModuleId = item.SubModuleId;
                model.ModuleId = item.Id;
                model.IsActive = true;
                model.IsDelete = false;
                model.IsEdit = true;
                model.IsDelete = true;
                model.IsCreate = true;
                model.CreatedBy = 1;
                model.CreatedDate = DateTime.Now;
                roleAccesses.Add(model);
            });

            var response = await _IRoleAccessDetailRepository.Add(roleAccesses.ToArray());
            if (response.ResponseStatus != A2ZPortal.Core.Entities.Common.ResponseStatus.Error)
            {
                return Json("Role Access Created.");
            }
            return Json("Something wents wrong, Please contact admin Team !!");

        }

        private async Task<bool> DeleteRoleAccess(int roleId)
        {
            var roleAccessModels = await _IRoleAccessDetailRepository
                .GetList(x => x.RoleId == roleId);

            roleAccessModels.Entities.ToList().ForEach(item =>
            {
                item.IsActive = false;
                item.IsDelete = true;
                item.UpdatedBy = 1;
                item.UpdatedDate = DateTime.Now;
            });

            var deleteResponse = await _IRoleAccessDetailRepository
                .Delete(roleAccessModels.Entities.ToArray());

            return deleteResponse.ResponseStatus
                != A2ZPortal.Core.Entities.Common.ResponseStatus.Error;
        }
    }
}
