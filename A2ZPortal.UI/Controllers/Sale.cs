
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Enums;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace A2ZPortal.UI.Controllers
{
    [BreadcrumbActionFilter]
    public class Sale : Controller
    {
        private readonly IPropertyDetailCompleteRepository _IPropertyDetailCompleteRepository;
        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        public Sale(IPropertyDetailCompleteRepository propertyDetailCompleteRepository, IConfiguration configuration) {
            _IPropertyDetailCompleteRepository = propertyDetailCompleteRepository;
            _configuration = configuration;
           
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = " | Sale";
            ViewBag.ControllerName = "Sales";
            var response = await _IPropertyDetailCompleteRepository.GetPropertyDetailByName(PropertyEnums.Sell.ToString());
             response.ForEach(item => {
                 if (string.IsNullOrEmpty(item.ImagePath)) {
                     item.ImagePath = "/A2Z-contents/PropertyImageNotFound.png";
                 }
                 else {
                     item.ImagePath = APIURL + item.ImagePath;
                 }
              
            });
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("Projects", "Index"), response);
        }
    }
}
