using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Master
{
    public class PropertyDetailController : Controller
    {
        private readonly IGenericRepository<PropertyDetail, int> _IPropertyDetailRepository;
        private readonly IGenericRepository<PropertyImage, int> _IPropertyImageRepository;

        public PropertyDetailController(IGenericRepository<PropertyDetail, int> propertyDetailRepository,
            IGenericRepository<PropertyImage, int> propertyImageRepository)
        {
            _IPropertyDetailRepository = propertyDetailRepository;
            _IPropertyImageRepository = propertyImageRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = "Property Detail";
            return await Task.Run(() => View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyDetailIndex")));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _IPropertyDetailRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyDetailDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }

        public async Task<IActionResult> Create(int id)
        {
            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyDetailCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(PropertyDetail model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _IPropertyDetailRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Property Status Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _IPropertyDetailRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Property Status created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _IPropertyDetailRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Property Status deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
