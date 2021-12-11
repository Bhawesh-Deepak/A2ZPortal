using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    [BreadcrumbActionFilter]
    public class UpcomingProject : Controller
    {
        private readonly IGenericRepository<UpComingPropertyDetail, int> _iUpComingPropertyDetailGenericRepository;
        private readonly IConfiguration _configuration;
        private readonly string APIURL = string.Empty;
        private readonly IGenericRepository<Contact, int> _IContactRepository;
        public UpcomingProject(IGenericRepository<UpComingPropertyDetail, int> iUpComingPropertyDetailGenericRepository, IGenericRepository<Contact, int> ContactRepository,IConfiguration configuration)
        {
            _iUpComingPropertyDetailGenericRepository = iUpComingPropertyDetailGenericRepository;
            _configuration = configuration;
            _IContactRepository = ContactRepository;
            APIURL = configuration.GetSection("APIURL").Value;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = " | Projects";
            var response = await _iUpComingPropertyDetailGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            response.Entities.ToList().ForEach(item =>
            {
                if (string.IsNullOrEmpty(item.ImagePath))
                {
                    item.ImagePath = "/A2Z-contents/PropertyImageNotFound.png";
                }
                else
                {
                    item.ImagePath = APIURL + item.ImagePath;
                }

            });
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("UpcomingProject", "Index"), response.Entities);
        }
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var response = await _iUpComingPropertyDetailGenericRepository.GetSingle(x => x.Id == id);
            response.Entity.ImagePath = APIURL + response.Entity.ImagePath;
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("UpcomingProject", "CompletePropertyDetail"), response.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact model, int Id)
        {
             
            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var response = await _IContactRepository.CreateEntity(createModel);

            ModelState.Clear();
            ViewData["ErrorMessage"] = response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error ?
                            "Something wents wrong, Please contact admin." :
                            "Thanks for contact me. i will contact you soon";

            return View(ViewPageHelper.InstanceHelper.GetPathDetail("UpcomingProject", "GetPropertyDetail"));
        }
    }
}
