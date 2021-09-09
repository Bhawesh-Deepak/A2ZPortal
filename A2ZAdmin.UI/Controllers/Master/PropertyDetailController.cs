using A2ZAdmin.UI.Helper;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Master
{
    [CustomAuthenticate]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
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
        private readonly IGenericRepository<Location, int> _ILocationRepository;
        private readonly IGenericRepository<SubLocation, int> _ISubLocationRepository;
        private readonly IPropertyDetailRepository _IPropertyDetailsRepository;
        private readonly IGenericRepository<AdditionalRoom, int> _IAdditionalRoomRepository;
        private readonly IGenericRepository<FurnishedStatus, int> _IFurnishedStatusRepository;
        private readonly IGenericRepository<AgeOfProperty, int> _IAgeOfPropertyRepository;
        private readonly IGenericRepository<NumberOfParking, int> _INumberOfParkingRepository;
        private readonly IGenericRepository<ViewFacing, int> _IViewFacingRepository;
        private readonly IGenericRepository<DefiningLocation, int> _IDefiningLocationRepository;
        private readonly IGenericRepository<ExplaningPrice, int> _IExplaningPriceRepository;
        private readonly IGenericRepository<ExplaningProperty, int> _IExplaningPropertyRepository;
        private readonly IGenericRepository<SizeAndStructure, int> _ISizeAndStructureRepository;
        private readonly IGenericRepository<SuitableFor, int> _ISuitableForRepository;
        private readonly IGenericRepository<Amenities, int> _IAmenitiesRepository;
        public PropertyDetailController(IGenericRepository<PropertyDetail, int> propertyDetailRepository,
            IGenericRepository<PropertyImage, int> propertyImageRepository,
            IHostingEnvironment hostingEnvironment, IGenericRepository<PropertyType, int> propertyTypeRepo
            , IGenericRepository<PropertyStatusModel, int> propertyStatusRepository
            , IGenericRepository<BedRoom, int> bedRoomRepository
            , IGenericRepository<BathRoom, int> bathRoomRepository
            , IGenericRepository<Budget, int> budgetRepository
            , IGenericRepository<Location, int> _LocationRepository
             , IGenericRepository<SubLocation, int> _SubLocationRepository
            , IPropertyDetailRepository propertDetailsRepository
             , IGenericRepository<AdditionalRoom, int> _AdditionalRoomRepository
            , IGenericRepository<FurnishedStatus, int> _FurnishedStatusRepository
            , IGenericRepository<AgeOfProperty, int> _AgeOfPropertyRepository
            , IGenericRepository<NumberOfParking, int> _NumberOfParkingRepository
            , IGenericRepository<ViewFacing, int> _ViewFacingRepository
             , IGenericRepository<DefiningLocation, int> _DefiningLocationRepository
             , IGenericRepository<ExplaningPrice, int> _ExplaningPriceRepository
             , IGenericRepository<ExplaningProperty, int> _ExplaningPropertyRepository
             , IGenericRepository<SizeAndStructure, int> _SizeAndStructureRepository
             , IGenericRepository<SuitableFor, int> _SuitableForRepository
            , IGenericRepository<Amenities, int> _AmenitiesRepository
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
            _ILocationRepository = _LocationRepository;
            _IPropertyDetailsRepository = propertDetailsRepository;
            _ISubLocationRepository = _SubLocationRepository;
            _IAdditionalRoomRepository = _AdditionalRoomRepository;
            _IFurnishedStatusRepository = _FurnishedStatusRepository;
            _IAgeOfPropertyRepository = _AgeOfPropertyRepository;
            _INumberOfParkingRepository = _NumberOfParkingRepository;
            _IViewFacingRepository = _ViewFacingRepository;
            _IDefiningLocationRepository = _DefiningLocationRepository;
            _IExplaningPriceRepository = _ExplaningPriceRepository;
            _IExplaningPropertyRepository = _ExplaningPropertyRepository;
            _ISizeAndStructureRepository = _SizeAndStructureRepository;
            _ISuitableForRepository = _SuitableForRepository;
            _IAmenitiesRepository = _AmenitiesRepository;
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
        public async Task<IActionResult> RentResidential(int id)
        {
            await PopulateViewBag();

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "RentResidentialCreate"), response.Entity);
        }
        public async Task<IActionResult> SellCommercial(int id)
        {
            await PopulateViewBag();

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "SellCommercialCreate"), response.Entity);
        }
        public async Task<IActionResult> RentCommercial(int id)
        {
            await PopulateViewBag();

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "RentCommercialCreate"), response.Entity);
        }
        public async Task<IActionResult> SellResidential(int id)
        {
            await PopulateViewBag();

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "SellResidentialCreate"), response.Entity);
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
        public async Task<IActionResult> GetPropertyDetail()
        {
            var requestModel = new PropertyRequestModel() {
                PageNumber=1,
                PageSize=50
            };
            var response = await _IPropertyDetailsRepository.GetPropertyDetails(requestModel);
            return PartialView(ViewPageHelper.InstanceHelper
                .GetPathDetail("PropertyDetail", "PropertyDetailDetails"), response);

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
            ViewBag.Location = (await _ILocationRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.SubLocation = (await _ISubLocationRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.AdditionalRoom = (await _IAdditionalRoomRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.FurnishedStatus = (await _IFurnishedStatusRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.AgeOfProperty = (await _IAgeOfPropertyRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.NumberOfParking = (await _INumberOfParkingRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.ViewFacing = (await _IViewFacingRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.DefiningLocation = (await _IDefiningLocationRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.ExplaningPrice = (await _IExplaningPriceRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.ExplaningProperty = (await _IExplaningPropertyRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.SizeAndStructure = (await _ISizeAndStructureRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.SuitableFor = (await _ISuitableForRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.Amenities = (await _IAmenitiesRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
        }
    }
}
