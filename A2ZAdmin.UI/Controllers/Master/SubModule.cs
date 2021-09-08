using A2ZAdmin.UI.Helper;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.ViewModel.MasterModel;
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
    public class SubModule : Controller
    {
        private readonly IGenericRepository<SubModuleMaster, int> _iSubModuleGenericRepository;
        private readonly IGenericRepository<ModuleMaster, int> _iModuleGenericRepository;

        public SubModule(IGenericRepository<SubModuleMaster, int> iSubModuleGenericRepository
         , IGenericRepository<ModuleMaster, int> iModuleGenericRepository)
        {
            _iSubModuleGenericRepository = iSubModuleGenericRepository;
            _iModuleGenericRepository = iModuleGenericRepository;
        }
        private async Task PopulateViewBag()
        {
            ViewBag.Module = (await _iModuleGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;

        }
        public IActionResult Index()
        {
            ViewData["Header"] = "Sub Module Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubModule), "SubModuleIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var SubModuleResponse = await _iSubModuleGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            var ModuleResponse = await _iModuleGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            var submoduleList = from submodule in SubModuleResponse.Entities
                                join module in ModuleResponse.Entities
                                on submodule.ModuleId equals module.Id
                                select new SubModuleViewModel
                                {
                                    Id = submodule.Id,
                                    ModuleName = module.ModuleName,
                                    SubModuleName = submodule.SubModuleName,
                                    AreaName = submodule.AreaName,
                                    ControllerName = submodule.ControllerName,
                                    ActionName = submodule.ActionName,
                                    SortOrder = submodule.SortOrder,
                                    IconImagePath = submodule.IconImagePath
                                };
            if (SubModuleResponse.ResponseStatus != ResponseStatus.Error && ModuleResponse.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubModule), "SubModuleDetails"), submoduleList);
            }
            Log.Error(SubModuleResponse.Message);
            Log.Error(ModuleResponse.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            await PopulateViewBag();
            var response = await _iSubModuleGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubModule), "SubModuleCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(SubModuleMaster model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iSubModuleGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Sub Module Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iSubModuleGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Sub Module created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iSubModuleGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iSubModuleGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Sub Module  deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
