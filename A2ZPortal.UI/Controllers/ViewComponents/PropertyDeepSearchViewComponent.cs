using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.ViewComponents
{
    [BreadcrumbActionFilter]
    public class PropertyDeepSearchViewComponent:ViewComponent
    {
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _iPropertyStatusGenericRepository;
        private readonly IGenericRepository<PropertyType, int> _iPropertyTypeGenericRepository;
        private readonly IGenericRepository<BedRoom, int> _iBedRoomGenericRepository;
        private readonly IGenericRepository<BathRoom, int> _iBathRoomGenericRepository;
        private readonly IGenericRepository<Amenities, int> _iAmenitiesGenericRepository;
        public PropertyDeepSearchViewComponent(IGenericRepository<Location, int> iLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository,
             IGenericRepository<Amenities, int> iAmenitiesGenericRepository


            )
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;
            _iAmenitiesGenericRepository = iAmenitiesGenericRepository;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await PopulateViewBag();
            return await Task.FromResult((IViewComponentResult)View("_DeepSearch"));
        }
        private async Task PopulateViewBag()
        {
            var taskPropertyStatus = _iPropertyStatusGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskBedRooms = _iBedRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskBathRooms = _iBathRoomGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskPropertyType = _iPropertyTypeGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskLocation = _iLocationGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            var taskAnemities = _iAmenitiesGenericRepository.GetList(x => x.IsActive && !x.IsDeleted);
            ViewBag.PropertyStatus = taskPropertyStatus.Result.Entities;
            ViewBag.BedRoom = taskBedRooms.Result.Entities;
            ViewBag.BathRoom = taskBathRooms.Result.Entities;
            ViewBag.PropertyType = taskPropertyType.Result.Entities;
            ViewBag.Location = taskLocation.Result.Entities;
            ViewBag.Amenities = taskAnemities.Result.Entities;
        }
    }
}
