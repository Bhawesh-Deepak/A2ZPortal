using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Common
{
    public class FilterMasterController : Controller
    {
        private readonly IUserManagementRepository _IUserManagementRepository;
        public FilterMasterController(IUserManagementRepository userManagementRepository)
        {
            _IUserManagementRepository = userManagementRepository;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _IUserManagementRepository.GetSubModuleDetails();
            return PartialView("", response);
        }
    }
}
