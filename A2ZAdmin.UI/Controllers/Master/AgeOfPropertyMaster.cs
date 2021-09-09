using A2ZAdmin.UI.Helper;
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
    [CustomAuthenticate]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class AgeOfPropertyMaster : Controller
    {
        private readonly IGenericRepository<AgeOfProperty, int> _iAgeOfPropertyGenericRepository;

        public AgeOfPropertyMaster(IGenericRepository<AgeOfProperty, int> iAgeOfPropertyGenericRepository)
        {
            _iAgeOfPropertyGenericRepository = iAgeOfPropertyGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Age Of Property Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AgeOfPropertyMaster), "AgeOfPropertyMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iAgeOfPropertyGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AgeOfPropertyMaster), "AgeOfPropertyMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iAgeOfPropertyGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(AgeOfPropertyMaster), "AgeOfPropertyMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(AgeOfProperty model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iAgeOfPropertyGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Age Of Property Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iAgeOfPropertyGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Age Of Property created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iAgeOfPropertyGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iAgeOfPropertyGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Age Of Property  deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

    }
}
