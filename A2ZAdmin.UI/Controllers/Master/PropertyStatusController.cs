using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using Serilog;
using A2ZAdmin.UI.Helper;

namespace A2ZAdmin.UI.Controllers.Master
{
    [CustomAuthenticate]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class PropertyStatusController : Controller
    {
        private readonly IGenericRepository<PropertyStatusModel, int> _IPropertyStatusRepository;

        public PropertyStatusController(IGenericRepository<PropertyStatusModel, int> iPropertyStatusRepository)
        {
            _IPropertyStatusRepository = iPropertyStatusRepository;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = "Property Status Master";
            return await Task.Run(()=> View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyStatus", "PropertyIndex")));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _IPropertyStatusRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyStatus", "PropertyDetail"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }

        public async Task<IActionResult> Create(int id)
        {
            var response = await _IPropertyStatusRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyStatus", "PropertyCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(PropertyStatusModel model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _IPropertyStatusRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Property Status Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _IPropertyStatusRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Property Status created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _IPropertyStatusRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _IPropertyStatusRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Property Status deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
