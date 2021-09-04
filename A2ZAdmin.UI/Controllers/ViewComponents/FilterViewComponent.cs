using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.ViewComponents
{
    [ViewComponent(Name = "Filter")]
    public class FilterViewComponent:ViewComponent
    {
        private readonly IUserManagementRepository _IUserManagementRepository;

        public FilterViewComponent(IUserManagementRepository iUserManagementRepository)
        {
            _IUserManagementRepository = iUserManagementRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model =(await  _IUserManagementRepository.GetSubModuleDetails()).OrderBy(x=>x.SubModuleName).ToList();
            return await Task.FromResult((IViewComponentResult)View("_FilterSharedPartial", model));
        }
    }
}
