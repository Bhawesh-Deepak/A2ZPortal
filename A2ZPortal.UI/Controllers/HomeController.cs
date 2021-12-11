using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.HomeDetailRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using A2ZPortal.UI.Helper;
using A2ZPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace A2ZPortal.UI.Controllers
{
    [ResponseCache(Duration = 120)]
    [BreadcrumbActionFilter]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<UpComingPropertyDetail, int> _iUpComingPropertyDetailGenericRepository;
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;
        private readonly IGenericRepository<SubLocation, int> _iSubLocationGenericRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _iPropertyStatusGenericRepository;
        private readonly IGenericRepository<PropertyType, int> _iPropertyTypeGenericRepository;
        private readonly IGenericRepository<BedRoom, int> _iBedRoomGenericRepository;
        private readonly IGenericRepository<BathRoom, int> _iBathRoomGenericRepository;
        private readonly IGenericRepository<Amenities, int> _iAmenitiesGenericRepository;
        private readonly IHomeDetailRepository _IHomeDetailRepository;
        private readonly IPropertyDashBoradRepository _IPropertyDashBoradRepository;
        private readonly string APIURL;
        private readonly IConfiguration _configuration;
        public HomeController(IGenericRepository<Location, int> iLocationGenericRepository,
            IGenericRepository<SubLocation, int> iSubLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository,
             IGenericRepository<Amenities, int> iAmenitiesGenericRepository,
             IHomeDetailRepository homeDetailRepository, IConfiguration configuration,
             IPropertyDashBoradRepository propertyDashBoradRepository,
             IGenericRepository<UpComingPropertyDetail, int> iUpComingPropertyDetailGenericRepository


            )
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;
            _iAmenitiesGenericRepository = iAmenitiesGenericRepository;
            APIURL = configuration.GetSection("APIURL").Value;
            _IHomeDetailRepository = homeDetailRepository;
            _iUpComingPropertyDetailGenericRepository = iUpComingPropertyDetailGenericRepository;
            _IPropertyDashBoradRepository = propertyDashBoradRepository;

        }
        private async Task PopulateViewBag()
        {
            var taskRecentProperty = _IHomeDetailRepository.GetRecentPropertyDetail();
            var taskPropertyLocationWiseCount = _IHomeDetailRepository.GetPropertyLocatonWiseCount();
            var taskRecentPropertyDetails = _IPropertyDashBoradRepository.GetRecentPropertyDetail(1, 10);
            var taskPropertyStatus = _iPropertyStatusGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskBedRooms = _iBedRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskBathRooms = _iBathRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskPropertyType = _iPropertyTypeGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskLocation = _iLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskSubLocation = _iSubLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskAnemities = _iAmenitiesGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);

            await Task.WhenAll
                            (taskPropertyLocationWiseCount,
                            taskRecentProperty,
                            taskRecentPropertyDetails, taskPropertyStatus, taskBedRooms,
                            taskBathRooms, taskPropertyType, taskLocation, taskSubLocation, taskAnemities);

            var recentProperties = taskRecentProperty.Result;

            recentProperties.ForEach(x =>
            {
                x.ImagePath = APIURL + x.ImagePath;

            });

            var recentPropertyDetails = taskRecentPropertyDetails.Result;
            recentPropertyDetails.ForEach(x =>
            {
                x.ImagePath = APIURL + x.ImagePath;
            });


            ViewBag.PropertyRecentDetail = recentPropertyDetails;
            ViewBag.PropertyLocationCount = taskPropertyLocationWiseCount.Result;
            ViewBag.PropertyImage = recentProperties;
            ViewBag.PropertyStatus = taskPropertyStatus.Result.Entities;
            ViewBag.BedRoom = taskBedRooms.Result.Entities;
            ViewBag.BathRoom = taskBathRooms.Result.Entities;
            ViewBag.PropertyType = taskPropertyType.Result.Entities;
            ViewBag.Location = taskLocation.Result.Entities;
            ViewBag.SubLocation = taskSubLocation.Result.Entities;
            ViewBag.Amenities = taskAnemities.Result.Entities;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "| Index";
            await PopulateViewBag();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Search(string prefix)
        {
            var taskLocation = _iLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted).Result.Entities.Where(p => p.LocationName.Contains(prefix)).ToList();
            return Json(taskLocation);
        }
        public async Task<IActionResult> SeachBoxPartial()
        {
            await PopulateViewBag();
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Home", "SeachMaster"));
        }
        public async Task<IActionResult> UpComingProject()
        {
            var taskPropertyStatus = await _iUpComingPropertyDetailGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);

            taskPropertyStatus.Entities.ToList().ForEach(item =>
            {
                item.ImagePath = APIURL + item.ImagePath;
            });
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Home", "UpComingProject"), taskPropertyStatus.Entities.LastOrDefault());
        }
        public async Task<IActionResult> FeaturedProperty(int pageIndex)
        {
            return await Task.Run(() => ViewComponent("Featured", pageIndex));
        }
        public async Task<IActionResult> TestimonialProperty()
        {
            return await Task.Run(() => ViewComponent("Testimonials"));
        }
    }
}