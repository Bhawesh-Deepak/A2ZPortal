using System;
using System.Diagnostics;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Customers;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A2ZPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;
        private readonly IGenericRepository<SubLocation, int> _iSubLocationGenericRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _iPropertyStatusGenericRepository;
        private readonly IGenericRepository<PropertyType, int> _iPropertyTypeGenericRepository;
        private readonly IGenericRepository<BedRoom, int> _iBedRoomGenericRepository;
        private readonly IGenericRepository<BathRoom, int> _iBathRoomGenericRepository;
        private readonly IGenericRepository<Amenities, int> _iAmenitiesGenericRepository;
        private readonly IGenericRepository<EmailSubscriber, int> _IEmailSubscribeRepository;

        public HomeController(IGenericRepository<Location, int> iLocationGenericRepository,
            IGenericRepository<SubLocation, int> iSubLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository,
             IGenericRepository<Amenities, int> iAmenitiesGenericRepository,
             IGenericRepository<EmailSubscriber, int> _emailSubscribeRepository

            )
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;
            _iAmenitiesGenericRepository = iAmenitiesGenericRepository;
            _IEmailSubscribeRepository = _emailSubscribeRepository;
        }
      


        public async Task<IActionResult> Index()
        {
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

        public async Task<IActionResult> SeachBoxPartial()
        {
            await PopulateViewBag();
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Home", "SeachMaster"));
        }

        public async Task<IActionResult> FeaturedProperty(int pageIndex)
        {
            return await Task.Run(() => ViewComponent("Featured", pageIndex));
        }

        public async Task<IActionResult> SubscribeEmail(string email)
        {
            var model = new EmailSubscriber() { EmailAddress = email };
            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var response = await _IEmailSubscribeRepository.CreateEntity(createModel);
            return response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error
                ? Json("OOPS something wents wrong, Please contact admin !")
                : Json("Thanks for subscribing us, we will update the latest information to your email");
        }

        #region PrivateBlock Code to populate the select list
        private async Task PopulateViewBag()
        {
            ViewBag.PropertyStatus = (await _iPropertyStatusGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.BedRoom = (await _iBedRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.BathRoom = (await _iBathRoomGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.PropertyType = (await _iPropertyTypeGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.Location = (await _iLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.SubLocation = (await _iSubLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.Amenities = (await _iAmenitiesGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
        }
        #endregion
    }
}