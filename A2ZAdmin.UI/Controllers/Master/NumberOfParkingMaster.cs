using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Master
{
    public class NumberOfParkingMaster : Controller
    {
        private readonly IGenericRepository<NumberOfParking, int> _iNumberOfParkingGenericRepository;

        public NumberOfParkingMaster(IGenericRepository<NumberOfParking, int> iNumberOfParkingGenericRepository)
        {
            _iNumberOfParkingGenericRepository = iNumberOfParkingGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Number Of Parking Property Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(NumberOfParkingMaster), "NumberOfParkingMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iNumberOfParkingGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(NumberOfParkingMaster), "NumberOfParkingMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iNumberOfParkingGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(NumberOfParkingMaster), "NumberOfParkingMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(NumberOfParking model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iNumberOfParkingGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Number Of Parking Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iNumberOfParkingGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Number Of Parking created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iNumberOfParkingGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iNumberOfParkingGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Number Of Parking deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
