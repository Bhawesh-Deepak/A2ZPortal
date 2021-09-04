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
    public class PossessionStatusMaster : Controller
    {
        private readonly IGenericRepository<PossessionStatus, int> _iPossessionStatusGenericRepository;

        public PossessionStatusMaster(IGenericRepository<PossessionStatus, int> iPossessionStatusGenericRepository)
        {
            _iPossessionStatusGenericRepository = iPossessionStatusGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Possession Status Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(PossessionStatusMaster), "PossessionStatusMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iPossessionStatusGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(PossessionStatusMaster), "PossessionStatusMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iPossessionStatusGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(PossessionStatusMaster), "PossessionStatusMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(PossessionStatus model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iPossessionStatusGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Possession Status Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iPossessionStatusGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Possession Status created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iPossessionStatusGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iPossessionStatusGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Possession Status deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

    }
}
