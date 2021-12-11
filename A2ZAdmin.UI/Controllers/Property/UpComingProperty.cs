using A2ZAdmin.UI.Helper;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Property
{
    [CustomAuthenticate]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

    public class UpComingProperty : Controller
    {
        private readonly IHostingEnvironment _IhostingEnviroment;
        private readonly IGenericRepository<UpComingPropertyDetail, int> _iUpComingPropertyDetailGenericRepository;

        public UpComingProperty(IGenericRepository<UpComingPropertyDetail, int> iUpComingPropertyDetailGenericRepository, IHostingEnvironment hostingEnvironment)
        {
            _iUpComingPropertyDetailGenericRepository = iUpComingPropertyDetailGenericRepository;
            _IhostingEnviroment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Up Coming Property";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(UpComingProperty), "UpComingPropertyIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iUpComingPropertyDetailGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(UpComingProperty), "UpComingPropertyDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            var response = await _iUpComingPropertyDetailGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(UpComingProperty), "UpComingPropertyCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(UpComingPropertyDetail model, IFormFile[] ImagePath)
        {
            if (ImagePath.Count() > 0)
            {
                var imageResponse = await BlobHelper.UploadImageOnFolder(ImagePath.ToList(), _IhostingEnviroment);
                model.ImagePath = imageResponse[0];
            }
            
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iUpComingPropertyDetailGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Up Coming Property Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iUpComingPropertyDetailGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Up Coming Property created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iUpComingPropertyDetailGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iUpComingPropertyDetailGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Up Coming Property  deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
