using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class CompletePropertyDetailsVm
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string PropertyTypeId { get; set; }
        public decimal Price { get; set; }
        public string LocationName { get; set; }
        public string SubLocationName { get; set; }
        public decimal Budgets { get; set; }
        public decimal AreaCovered { get; set; }
        public decimal TotalArea { get; set; }
        public string PropertyName { get; set; }
        public string ProprtyDescription { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceId { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public string RoomName { get; set; }
        public string PossesionStatus { get; set; }
        public string FurnishingStatus { get; set; }
        public int Age { get; set; }
        public int TotalParking { get; set; }
        public string Facing { get; set; }
        public string FloorNumber { get; set; }
        public string TowerBlock { get; set; }
        public string UnitNumber { get; set; }
        public string TrakheesiNumber { get; set; }
        public string DLocationName { get; set; }
        public string PriceName { get; set; }
        public string ExplaningName { get; set; }
        public string DefiningStructure { get; set; }
        public string SuitabelName { get; set; }
        public string SpaceType { get; set; }
        public decimal Maintaince { get; set; }
        public string Security_Deposit { get; set; }
        public int NoOfChecks { get; set; }
        public string LandLordDetails { get; set; }
        public string Nameoftheowner { get; set; }
        public string OwnersEmaiAddress { get; set; }
        public string MobileNoOftheOwner { get; set; }
        public string MeasurementType { get; set; }
        public string AreaTypeName { get; set; }

        public List<ImageDetails> ImageDetails { get; set; }
        public List<Features> FeatureDetails { get; set; }
    }

    public class ImageDetails
    {
        public string ImagePath { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsRecent { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class Features
    {
        public string Feature { get; set; }

    }
}
