using A2ZPortal.Core.Entities.UserManagement;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.ViewComponents
{
    public class MenuSubMenuViewComponent : ViewComponent
    {
        private readonly IGenericRepository<MenuSubMenu, int> _iMenuSubMenuRepository;

        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        public MenuSubMenuViewComponent(IGenericRepository<MenuSubMenu, int> iMenuSubMenuRepository, IConfiguration configuration)
        {
            _iMenuSubMenuRepository = iMenuSubMenuRepository;
            _configuration = configuration;
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = await _iMenuSubMenuRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            return await Task.FromResult((IViewComponentResult)View("_MenuSubMenu", models.Entities.ToList()));
        }
    }
}
