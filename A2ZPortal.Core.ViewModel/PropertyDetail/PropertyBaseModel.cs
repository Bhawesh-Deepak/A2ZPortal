using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    public abstract class PropertyBaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int LocationId { get; set; }
        public int SubLocationId { get; set; }
        public string PropertyName { get; set; }

        [DataType(DataType.MultilineText)]
        public string ProprtyDescription { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public string PlaceAddress { get; set; }
        public decimal Price { get; set; }
        public int AreaDisplay { get; set; }
        public int NoOfBedRooms { get; set; }
        public int AdditionalBedRooms { get; set; }
        public int NoOfBathRooms { get; set; }
        public int PossessionStatus { get; set; }
        public int FurnishingStatus { get; set; }
        public int AgeOfProperty { get; set; }
        public int NoOfParking { get; set; }
        public int ViewFacing { get; set; }
        public int FloarNumber { get; set; }
        public int Tower_Block { get; set; }
        public int TotalFloarCount { get; set; }
        public int UnitNumber { get; set; }
        public int TarkeshiNumber { get; set; }
    }
}
