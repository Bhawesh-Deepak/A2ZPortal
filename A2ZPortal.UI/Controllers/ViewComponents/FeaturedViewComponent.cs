using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.ViewComponents
{
    public class FeaturedViewComponent : ViewComponent
    {
        private readonly IPropertyDashBoradRepository _IPropertyDashBoardRepository;
        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        public FeaturedViewComponent(IPropertyDashBoradRepository propertyDashBoradRepository, IConfiguration configuration)
        {
            _IPropertyDashBoardRepository = propertyDashBoradRepository;
            _configuration = configuration;
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pageIndex=1)
        {
            var models = await _IPropertyDashBoardRepository.GetPropertyFeatureDetails(pageIndex, 6);
            
            models.ForEach(item =>
            {
                item.ImagePath = APIURL + item.ImagePath;
            });
            return await Task.FromResult((IViewComponentResult)View("_FeaturedProperty", models));
        }


    }
}
