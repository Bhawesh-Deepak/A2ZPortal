using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.ViewComponents
{
    public class PropertyDetailViewComponent:ViewComponent
    {
        private readonly IPropertyDetailRepository _IPropertyDetailRepository;
        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        public PropertyDetailViewComponent(IPropertyDetailRepository propertyDetailRepository, IConfiguration configuration)
        {
            _IPropertyDetailRepository = propertyDetailRepository;
            _configuration = configuration;
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(PropertySearchVm requestModel)
        {
            var models = await _IPropertyDetailRepository.GetPropertyCompleteDetail(requestModel);

            models.ForEach(item =>
            {
                item.ImagePath = APIURL + item.ImagePath;
            });
            return await Task.FromResult((IViewComponentResult)View("_PropertyDetail", models));
        }
    }
}
