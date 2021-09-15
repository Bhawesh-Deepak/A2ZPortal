using A2ZAdmin.UI.Helper;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Core.ViewModel.PropertyDetail;
using A2ZPortal.Core.ViewModel.RequestFolder;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.Infrastructure.Repository.PropertyDetailRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IGenericRepository<PropertyFeature, int> _IPropertyFeatureRepository;
        private readonly IGenericRepository<PossessionStatus, int> _IPossessionStatusRepository;
        private readonly IGenericRepository<AreaType, int> _IAreaTypeRepository;
        private readonly IGenericRepository<AreaMeasurement, int> _IAreaMeasurementRepository;

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
            , IGenericRepository<Amenities, int> _AmenitiesRepository,
            IGenericRepository<PropertyFeature, int> _PropertyFeatureRepository,
            IGenericRepository<PossessionStatus, int> _PossessionStatusRepository,
            IGenericRepository<AreaType, int> _AreaTypeRepository,
            IGenericRepository<AreaMeasurement, int> _AreaMeasurementRepository
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
            _IPropertyFeatureRepository = _PropertyFeatureRepository;
            _IPossessionStatusRepository = _PossessionStatusRepository;
            _IAreaTypeRepository = _AreaTypeRepository;
            _IAreaMeasurementRepository = _AreaMeasurementRepository;
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

            HttpContext.Session.SetObject("PropCat", ("Rent", "Residential"));

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            if (id > 0)
            {
                await PopulateImageViewBag(response.Entity.Id);
            }

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "RentResidentialCreate"), response.Entity);
        }
        public async Task<IActionResult> SellCommercial(int id)
        {
            await PopulateViewBag();

            HttpContext.Session.SetObject("PropCat", ("Sell", "Commercial"));

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            if (id > 0)
            {
                await PopulateImageViewBag(response.Entity.Id);
            }

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "SellCommercialCreate"), response.Entity);
        }
        public async Task<IActionResult> RentCommercial(int id)
        {
            await PopulateViewBag();

            HttpContext.Session.SetObject("PropCat", ("Rent", "Commercial"));

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            if (id > 0)
            {
                await PopulateImageViewBag(response.Entity.Id);
            }

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "RentCommercialCreate"), response.Entity);
        }
        public async Task<IActionResult> SellResidential(int id)
        {
            await PopulateViewBag();

            HttpContext.Session.SetObject("PropCat", ("Sell", "Residential"));

            var response = await _IPropertyDetailRepository.GetSingle(x => x.Id == id);

            if (id > 0)
            {
                await PopulateImageViewBag(response.Entity.Id);
            }

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "SellResidentialCreate"), response.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> PostCreate(PropertyDetail model, IFormFile[] PropertyImage)
        {
            var propertyType = HttpContext.Session.GetObject<(string, string)>("PropCat");

            model.PropertyTypeId = propertyType.Item1;
            model.CategoryId = propertyType.Item2;

            return model.Id == 0 ?
                await CreatePropertyDetails(model, PropertyImage) :
                await UpdatePropertyDetails(model, PropertyImage);
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
            var requestModel = new PropertyRequestModel()
            {
                PageNumber = 1,
                PageSize = 50
            };
            var response = await _IPropertyDetailsRepository.GetPropertyDetails(requestModel);
            return PartialView(ViewPageHelper.InstanceHelper
                .GetPathDetail("PropertyDetail", "PropertyDetailDetails"), response);

        }

        private async Task<bool> InsertPropertyFeature(List<int> propertyFeatures, bool isUpdated, int propertyDetailId)
        {
            if (propertyFeatures != null && propertyFeatures.Count() > 0)
            {
                if (isUpdated)
                {
                    var returnModel = await _IPropertyFeatureRepository.GetList(x => x.PropertyDetailId == propertyDetailId);
                    returnModel.Entities.ToList().ForEach(item =>
                    {
                        item.IsActive = false;
                        item.IsDeleted = true;
                    });

                    var updateResponse = await _IPropertyFeatureRepository.Update(returnModel.Entities.ToArray());
                }
                var models = new List<PropertyFeature>();

                propertyFeatures.ForEach(item =>
                {
                    var model = new PropertyFeature()
                    {
                        CreatedBy = 1,
                        CreatedDate = System.DateTime.Now,
                        PropertyDetailId = propertyDetailId,
                        FeatureId = item
                    };
                    models.Add(model);

                });
                var createReponse = await _IPropertyFeatureRepository.Add(models.ToArray());

                return createReponse.ResponseStatus != ResponseStatus.Error;
            }

            return false;
        }
        private async Task<bool> PropertyImageInsert(IFormFile[] PropertyImage, bool isUpdate, int lastInsertedId)
        {
            var imageResponse = await BlobHelper.UploadImageOnFolder(PropertyImage.ToList(), _IhostingEnviroment);

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
                    IsDeleted = false,
                    IsPrimaryImage = false,
                    IsExclusive = false,
                    IsRecent = false
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
            ViewBag.PossessionStatus = (await _IPossessionStatusRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.AreaType = (await _IAreaTypeRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
            ViewBag.AreaMeasurement = (await _IAreaMeasurementRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;


        }

        private async Task<IActionResult> CreatePropertyDetails(PropertyDetail model, IFormFile[] PropertyImage)
        {
            var createModel = ReplaceNullWithDefault.ReplaceWithDefault<PropertyDetail>(CommonCrudHelper.CommonCreateCode(model, 1));

            var createResponse = await _IPropertyDetailRepository.CreateEntity(createModel);

            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                var lastInsertedId = (await _IPropertyDetailRepository.GetList(x => x.IsActive == true)).Entities.Max(x => x.Id);

                await PropertyImageInsert(PropertyImage, false, lastInsertedId);

                await InsertPropertyFeature(model.Amenities, false, lastInsertedId);

                return Json(lastInsertedId);
            }
            Log.Error(createResponse.Message);

            return Json(-1);
        }

        private async Task<IActionResult> UpdatePropertyDetails(PropertyDetail model, IFormFile[] PropertyImage)
        {
            var updateModel = ReplaceNullWithDefault.ReplaceWithDefault<PropertyDetail>(CommonCrudHelper.CommonUpdateCode(model, 1));

            var updateResponse = await _IPropertyDetailRepository.CreateEntity(updateModel);

            if (updateResponse.ResponseStatus != ResponseStatus.Error)
            {
                var lastInsertedId = (await _IPropertyDetailRepository.GetList(x => x.IsActive == true)).Entities.Max(x => x.Id);

                await PropertyImageInsert(PropertyImage, true, lastInsertedId);

                await InsertPropertyFeature(model.Amenities, true, lastInsertedId);

                return Json(lastInsertedId);
            }
            Log.Error(updateResponse.Message);

            return Json(-1);
        }

        public async Task<IActionResult> GetPropertyImageDetails(int propertyId)
        {
            var response = await _IPropertyImageRepository.GetList(x => x.IsActive == true && x.IsDeleted == false
            && x.PropertyDetailId == propertyId);

            var model = new PropertyImageVm();
            model.PropertyImages = response.Entities.ToList();
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyImageDetail"), model);

        }

        [HttpPost]
        public async Task<IActionResult> MappImage(PropertyImageVm model)
        {
            model.PropertyImages.ForEach(item =>
            {
                item.CreatedBy = 1;
                item.CreatedDate = DateTime.Now;
                item.IsActive = true;
                item.IsDeleted = false;
            });

            var response = await _IPropertyImageRepository.Update(model.PropertyImages.ToArray());
            if (response.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Image mapped successfully !!!!");
            }
            return Json("Something wents wrong Please contact admin Team");
        }

        public async Task<IActionResult> GetPropertyList()
        {
            var response = await _IPropertyDetailsRepository.GetPropertyListVm();
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyDetailList"), response);

        }
        private async Task PopulateImageViewBag(int propId)
        {
            ViewBag.ImageDetails = (await _IPropertyImageRepository.GetList(x => x.IsActive == true && x.IsDeleted == false
                 && x.PropertyDetailId == propId
            )).Entities;
        }

        public async Task<IActionResult> GetPropertyCompleteDetails(int id)
        {
            var response = await _IPropertyDetailsRepository.GetPropertyDetail(id);
            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetail", "PropertyCompleteDetail"), response);
        }
    }
}
