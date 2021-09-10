using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper.Extension;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.ViewComponents
{
    public class MenuSubMenuViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = HttpContext.Session.GetObject<List<UserAccessDetailModel>>("AccessInformation");
            return await Task.FromResult((IViewComponentResult)View("_MenuSubMenu", model));
        }
    }
}
