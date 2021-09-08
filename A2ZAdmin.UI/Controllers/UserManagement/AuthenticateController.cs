using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.UserManagement
{
    public class AuthenticateController : Controller
    {
        private readonly IUserManagementRepository _IUserManagementRepository;

        public AuthenticateController(IUserManagementRepository userManagementRepository)
        {
            _IUserManagementRepository = userManagementRepository;
        }
        public IActionResult Index()
        {
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Authenticate", "Login"));
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthModel model)
        {
            var response = await _IUserManagementRepository.AuthenticateUser(model.UserName, model.Password);
            if (response.ResponseStatus == A2ZPortal.Core.Entities.Common.ResponseStatus.Error)
            {
                model.Message = "User name or password is not valid !";
                ModelState.Remove("UserName");
                ModelState.Remove("Password");
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Authenticate", "Login"), model);
            }
            else
            {
                HttpContext.Session.SetObject("AccessInformation", response.Entity.UserAccessDetails);
                HttpContext.Session.SetString("EmployeeName", response.Entity.EmployeeName);
                return RedirectToAction("Index", "Home");

            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return await Task.Run(() => RedirectToAction("Index", "Authenticate"));
        }
    }
}
