using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    public class PropertyDetails : Controller
    {
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;
        private readonly IGenericRepository<SubLocation, int> _iSubLocationGenericRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _iPropertyStatusGenericRepository;
        private readonly IGenericRepository<PropertyType, int> _iPropertyTypeGenericRepository;
        private readonly IGenericRepository<BedRoom, int> _iBedRoomGenericRepository;
        private readonly IGenericRepository<BathRoom, int> _iBathRoomGenericRepository;
        private readonly IPropertyDetailCompleteRepository _IPropertyCompleteRepository;
        private readonly string APIURL = string.Empty;
        private readonly IGenericRepository<Brochure, int> _IBrochureRepository;
        private readonly IVirtualImageRepository IVirtualImageRepository;
        public PropertyDetails(IGenericRepository<Location, int> iLocationGenericRepository,
            IGenericRepository<SubLocation, int> iSubLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository,
             IPropertyDetailCompleteRepository propertyDetailCompleteRepository,
             IConfiguration configuration, IGenericRepository<Brochure, int> brochureRepository,
             IVirtualImageRepository virtualImageRepository
             )
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;
            _IPropertyCompleteRepository = propertyDetailCompleteRepository;
            APIURL = configuration.GetSection("APIURL").Value;
            _IBrochureRepository = brochureRepository;
            IVirtualImageRepository = virtualImageRepository;
        }
        public async Task<IActionResult> Index(int location, int sub_location, int bathRoom,
            int status, int category, int bedrooms, int min_price, int max_price, int min_area, int max_area)
        {

            await PopulateViewBag();

            var model = new PropertySearchVm()
            {
                LocationId = location,
                SubLocationId = sub_location,
                PropertyStatus = status,
                BathRoomId = bathRoom,
                BedRoomId = bedrooms,
                MaxArea = max_area,
                MinArea = min_area,
                MinPrice = min_price,
                MaxPrice = max_area,
                PageNumber = 1,
                PageSize = 6
            };

            return View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetails", "PropertyHome"), model);
        }
        public async Task<IActionResult> FilteredPropertyDetail(int location, int subLocation, string status,
            int property, int bedRoom, int bathRoom, string fromPrice, string toPrice, string fromArea, string toArea, int pageIndex)
        {
            var requestModel = new PropertySearchVm()
            {
                LocationId = location == 0 ? null : location,
                SubLocationId = subLocation == 0 ? null : subLocation,
                PropertyStatusId = Convert.ToInt32(status) == 0 ? null : Convert.ToInt32(status),
                BedRoomId = bedRoom == 0 ? null : bedRoom,
                BathRoomId = bathRoom == 0 ? null : bathRoom,
                PageNumber = pageIndex == 0 ? 1 : pageIndex
            };
            return await Task.Run(() => ViewComponent("PropertyDetail", requestModel));

        }


        public async Task<IActionResult> GetPropertyDetail(int id)
        
        {
            var response = await _IPropertyCompleteRepository.GetCompletePropertyDetail(id);
            response.ImageDetails.ForEach(item =>
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
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetails", "CompletePropertyDetail"), response);
        }
        [CustomAuthenticate]
        public async Task<IActionResult> DownloadBrochure(int propId)
        {
            var response = await _IBrochureRepository.GetSingle(x => x.PropertyId == propId);
            if (response.ResponseStatus != ResponseStatus.Error) {
                var pdfFile = APIURL + response.Entity.BrochurePath;
                return RedirectPermanent(pdfFile);
            }
            return RedirectToAction("Index", "Error");
        }

        public async Task<IActionResult> DisplayPropertyVirtualTour(int propId) 
        {
            var response = await IVirtualImageRepository.GetVirtualImage(propId);
            response.ImagePath= APIURL + response.ImagePath;
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("360PanomaIImages", "_360ImageView"), response);
        }
        private async Task PopulateViewBag()
        {
            ViewBag.PropertyStatus = (await _iPropertyStatusGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.BedRoom = (await _iBedRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.BathRoom = (await _iBathRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.PropertyType = (await _iPropertyTypeGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.Location = (await _iLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
            ViewBag.SubLocation = (await _iSubLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted)).Entities;
        }
    }
}
