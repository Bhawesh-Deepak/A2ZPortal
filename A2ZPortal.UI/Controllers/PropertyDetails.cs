using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
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

        public PropertyDetails(IGenericRepository<Location, int> iLocationGenericRepository,
            IGenericRepository<SubLocation, int> iSubLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository)
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;

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
                LocationId = location==0? null:location,
                SubLocationId = subLocation==0? null:subLocation,
                PropertyStatusId = Convert.ToInt32(status)==0?null : Convert.ToInt32(status),
                BedRoomId=bedRoom==0?null:bedRoom,
                BathRoomId=bathRoom==0? null : bathRoom,
                PageNumber=pageIndex==0?1 : pageIndex
            };
            return await Task.Run(() => ViewComponent("PropertyDetail", requestModel));

        }

        private async Task PopulateViewBag()
        {
            ViewBag.PropertyStatus = (await _iPropertyStatusGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.BedRoom = (await _iBedRoomGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.BathRoom = (await _iBathRoomGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.PropertyType = (await _iPropertyTypeGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.Location = (await _iLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.SubLocation = (await _iSubLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
        }
    }
}
