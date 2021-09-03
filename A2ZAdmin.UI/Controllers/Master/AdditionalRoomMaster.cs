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
    public class AdditionalRoomMaster : Controller
    {
         private readonly IGenericRepository<AdditionalRoom, int> _iAdditionalRoomGenericRepository;

        public AdditionalRoomMaster(IGenericRepository<AdditionalRoom, int> iAdditionalRoomGenericRepository)
        {
            _iAdditionalRoomGenericRepository = iAdditionalRoomGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Area Measurement Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AdditionalRoomMaster), "AdditionalRoomMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iAdditionalRoomGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AdditionalRoomMaster), "AdditionalRoomMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iAdditionalRoomGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AdditionalRoomMaster), "AdditionalRoomCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(AdditionalRoom model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iAdditionalRoomGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Additional Room Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iAdditionalRoomGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Additional Room created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iAdditionalRoomGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iAdditionalRoomGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Additional Room deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

    }
}
