using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyList
{
    public class PropertyDetailListVm
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string LocationName { get; set; }
        public string SubLocationName { get; set; }
        public string Budget { get; set; }
        public decimal AreaCovered { get; set; }
        public decimal TotalArea { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string longitude { get; set; }

        public string Latitude { get; set; }
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
        public string TarkeshiNumber { get; set; }
        public string DefiningLocation { get; set; }
        public string PriceName { get; set; }
        public string ExplaningName { get; set; }
        public string DefiningStructure { get; set; }
        public string SuitableName { get; set; }
        public string SpaceType { get; set; }
        public decimal Maintainence { get; set; }
        public string SecurityDeposit { get; set; }
        public int NoOfChecks { get; set; }
        public string LandLoardDetails { get; set; }
        public string NameofOwner { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
        public List<string> Amenities { get; set; }
    }

    public class PropertyImage
    {
        public string ImagePath { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsRecent { get; set; }
        public bool IsExclusive { get; set; }

    }
}
