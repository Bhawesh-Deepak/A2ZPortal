using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;

namespace A2ZAdmin.UI.Controllers.Master
{
    public class Module : Controller
    {
        private readonly IGenericRepository<ModuleMaster, int> _iModuleGenericRepository;

        public Module(IGenericRepository<ModuleMaster, int> iModuleGenericRepository)
        {
            _iModuleGenericRepository = iModuleGenericRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Module Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(Module),"ModuleIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iModuleGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(Module), "ModuleDetails"), response.Entities);
        }

        public async Task<IActionResult> Create(int id)
        {
            var response = await _iModuleGenericRepository.GetSingle(x=>x.Id==id);
            
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(Module), "ModuleCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(ModuleMaster model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iModuleGenericRepository.Update(updateModel);
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iModuleGenericRepository.CreateEntity(createModel);
            return Json("Created");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iModuleGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iModuleGenericRepository.Delete(deleteModel);
            return Json("Deleted");
        }
    }
}
