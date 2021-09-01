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
    public class SubLoactionMaster : Controller
    {
        private readonly IGenericRepository<SubLocation, int> _iSubLocationGenericRepository;
        private readonly IGenericRepository<Location, int> _iLocationGenericRepository;

        public SubLoactionMaster(IGenericRepository<SubLocation, int> iSubLocationGenericRepository
            , IGenericRepository<Location, int> iLocationGenericRepository)
        {
            _iSubLocationGenericRepository = iSubLocationGenericRepository;
            _iLocationGenericRepository = iLocationGenericRepository;
        }
        private async Task PopulateViewBag()
        {
            ViewBag.Location = (await _iLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;

        }
        public IActionResult Index()
        {
            ViewData["Header"] = "Sub Location Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubLoactionMaster), "SubLocationMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var response = await _iSubLocationGenericRepository.GetList(x => x.IsActive == true && x.IsDeleted == false);
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubLoactionMaster), "SubLocationMasterDetails"), response.Entities);
            }
            Log.Error(response.Message);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));

        }
        public async Task<IActionResult> Create(int id)
        {
            await PopulateViewBag();
            var response = await _iSubLocationGenericRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(SubLoactionMaster), "SubLocationMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(SubLocation model)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _iSubLocationGenericRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Sub Location Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _iSubLocationGenericRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Sub Location  created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _iSubLocationGenericRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _iSubLocationGenericRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Sub Location  deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }
    }
}
