using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper.Extension;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.ViewComponents
{
    public class MenuSubMenuViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = HttpContext.Session.GetObject<IEnumerable<UserAccessDetailModel>>("AccessInformation");
            return await Task.FromResult((IViewComponentResult)View("_MenuSubMenu", model));
        }
    }
}
