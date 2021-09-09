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
    public class SizeAndStructureMaster : Controller
    {
        private readonly IGenericRepository<SizeAndStructure, int> _iSizeAndStructureGenericRepository;

        public SizeAndStructureMaster(IGenericRepository<SizeAndStructure, int> iSizeAndStructureGenericRepository)
        {
            _iSizeAndStructureGenericRepository = iSizeAndStructureGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Size And Structure Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SizeAndStructureMaster), "SizeAndStructureMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iSizeAndStructureGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SizeAndStructureMaster), "SizeAndStructureMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iSizeAndStructureGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SizeAndStructureMaster), "SizeAndStructureMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(SizeAndStructure model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iSizeAndStructureGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Size And Structure Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iSizeAndStructureGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Size And Structure created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iSizeAndStructureGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iSizeAndStructureGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Size And Structure deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

    }
}
