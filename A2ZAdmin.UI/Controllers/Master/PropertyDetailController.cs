using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Master
{
    public class PropertyDetailController : Controller
    {
        private readonly IGenericRepository<PropertyDetail, int> _IPropertyDetailRepository;
        private readonly IGenericRepository<PropertyImage, int> _IPropertyImageRepository;
        private readonly IHostingEnvironment _IhostingEnviroment;
        private readonly IGenericRepository<PropertyType, int> _IPropertyTypeMasterRepository;
        private readonly IGenericRepository<PropertyStatusModel, int> _IPropertyStatusRepository;
        private readonly IGenericRepository<BedRoom, int> _IBedRoomRepository;
        private readonly IGenericRepository<BathRoom, int> _IBathRoomRepository;
        private readonly IGenericRepository<Budget, int> _IBudgetRepository;

        public PropertyDetailController(IGenericRepository<PropertyDetail, int> propertyDetailRepository,
            IGenericRepository<PropertyImage, int> propertyImageRepository,
            IHostingEnvironment hostingEnvironment, IGenericRepository<PropertyType, int> propertyTypeRepo
            , IGenericRepository<PropertyStatusModel, int> propertyStatusRepository
            , IGenericRepository<BedRoom, int> bedRoomRepository
            , IGenericRepository<BathRoom, int> bathRoomRepository
            , IGenericRepository<Budget, int> budgetRepository



            )
        {
            _IPropertyDetailRepository = propertyDetailRepository;
            _IPropertyImageRepository = propertyImageRepository;
            _IhostingEnviroment = hostingEnvironment;
            _IPropertyStatusRepository = propertyStatusRepository;
            _IBedRoomRepository = bedRoomRepository;
            _IBathRoomRepository = bathRoomRepository;
            _IBudgetRepository = budgetRepository;
            _IPropertyTypeMasterRepository = propertyTypeRepo;
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
            await PopulateViewBag();

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyDetailCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(PropertyDetail model, IFormFile[] PropertyImage)
        {
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);

                var updateResponse = await _IPropertyDetailRepository.Update(updateModel);

                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    await PropertyImageInsert(PropertyImage, false);

                    return Json("Property Status Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);

                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);

            var createResponse = await _IPropertyDetailRepository.CreateEntity(createModel);

            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                await PropertyImageInsert(PropertyImage, true);
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

        private async Task<bool> PropertyImageInsert(IFormFile[] PropertyImage, bool isUpdate)
        {
            var imageResponse = await BlobHelper.UploadImageOnFolder(PropertyImage.ToList(), _IhostingEnviroment);

            var lastInsertedId = (await _IPropertyDetailRepository.GetList(x => x.IsActive == true)).Entities.Max(x => x.Id);

            if (isUpdate)
            {
                var inActiveImageResonse = await InActivateThePropertyImage(lastInsertedId);
            }

            List<PropertyImage> imageDetails = new List<PropertyImage>();

            foreach (var data in imageResponse)
            {
                imageDetails.Add(new PropertyImage()
                {
                    PropertyDetailId = lastInsertedId,
                    ImagePath = data,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                });
            }

            var imageInsertResponse = await _IPropertyImageRepository.Add(imageDetails.ToArray());

            return imageInsertResponse.ResponseStatus != ResponseStatus.Error;
        }
        private async Task<bool> InActivateThePropertyImage(int propertyId)
        {
            var imageList = await _IPropertyImageRepository.GetList(x => x.PropertyDetailId == propertyId);

            foreach (var data in imageList.Entities)
            {
                data.IsActive = false;
                data.IsDeleted = true;
            }

            var updateResponse = await _IPropertyImageRepository.Update(imageList.Entities.ToArray());

            return updateResponse.ResponseStatus != ResponseStatus.Error;
        }

        private async Task PopulateViewBag()
        {
            ViewBag.PropertyStatus = (await _IPropertyStatusRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.BedRoom = (await _IBedRoomRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.BathRoom = (await _IBathRoomRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.Budget = (await _IBudgetRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.PropertyType = (await _IPropertyTypeMasterRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
        }
    }
}
