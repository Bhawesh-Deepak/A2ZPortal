using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    public class PropertySearchController : Controller
    {
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;
        private readonly IGenericRepository<SubLocation, int> _iSubLocationGenericRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _iPropertyStatusGenericRepository;
        private readonly IGenericRepository<PropertyType, int> _iPropertyTypeGenericRepository;
        private readonly IGenericRepository<BedRoom, int> _iBedRoomGenericRepository;
        private readonly IGenericRepository<BathRoom, int> _iBathRoomGenericRepository;

        public PropertySearchController(IGenericRepository<Location, int> iLocationGenericRepository,
            IGenericRepository<SubLocation, int> iSubLocationGenericRepository,
             IGenericRepository<PropertyStatusModel, int> iPropertyStatusGenericRepository,
             IGenericRepository<PropertyType, int> iPropertyTypeGenericRepository,
              IGenericRepository<BedRoom, int> iBedRoomGenericRepository,
             IGenericRepository<BathRoom, int> iBathRoomGenericRepository

            )
        {
            _iLocationGenericRepository = iLocationGenericRepository;
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iPropertyStatusGenericRepository = iPropertyStatusGenericRepository;
            _iPropertyTypeGenericRepository = iPropertyTypeGenericRepository;
            _iBedRoomGenericRepository = iBedRoomGenericRepository;
            _iBathRoomGenericRepository = iBathRoomGenericRepository;
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
        public async Task<IActionResult> Index()
        {
            await PopulateViewBag();
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertySearch", "Index"));
        }
    }
}
