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
    public class DefiningLocationMaster : Controller
    {
        private readonly IGenericRepository<DefiningLocation, int> _iDefiningLocationGenericRepository;

        public DefiningLocationMaster(IGenericRepository<DefiningLocation, int> iDefiningLocationGenericRepository)
        {
            _iDefiningLocationGenericRepository = iDefiningLocationGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Defining Location Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(DefiningLocationMaster), "DefiningLocationMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iDefiningLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(DefiningLocationMaster), "DefiningLocationMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iDefiningLocationGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(DefiningLocationMaster), "DefiningLocationMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(DefiningLocation model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iDefiningLocationGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Defining Location Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iDefiningLocationGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Defining Location created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iDefiningLocationGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iDefiningLocationGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Defining Location deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

    }
}
