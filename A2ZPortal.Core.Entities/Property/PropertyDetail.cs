using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("PropertyDetail", Schema = "Property")]
    public class PropertyDetail: BaseModel<int>
    {
		public int LocationId { get; set; }
		public int SubLocationId { get; set; }
		public int PropertyTypeId { get; set; }
		public int PropertyStatusId { get; set; }
		public int BudgetId { get; set; }
		public decimal AreaCovered { get; set; }
		public decimal TotalArea { get; set; }
		public string PropertyName { get; set; }
		public string ProprtyDescription { get; set; }
		public string Longitude { get; set; }
		public string Lattitude { get; set; }
		public string PlaceAddress { get; set; }
		public string PlaceId { get; set; }
		public int AgentId { get; set; }
		public decimal Price { get; set; }
		public string AreaDisplay { get; set; }
		public int NoOfBedRoomsId { get; set; }
		public int NoOfBathroomsId { get; set; }
		public int AdditionalRoomId { get; set; }
		public int PossessionStatusId { get; set; }
		public int FurnishingStatusId { get; set; }
		public int AgeOfPropertyId { get; set; }
		public int NoOfParkingId { get; set; }
		public int ViewFacingId { get; set; }
		public string FloorNumber { get; set; }
		public string TowerBlock { get; set; }
		public string TotalFloorCount { get; set; }
		public string UnitNumber { get; set; }
		public string TrakheesiNumber { get; set; }
		public int DefiningLocationId { get; set; }
		public int ExplainingPriceId { get; set; }
		public int ExplainingThePropertyId { get; set; }
		public int DefiningSizeStructureId { get; set; }
		public int SuitableForId { get; set; }
		public string SpaceType { get; set; }
		public decimal Maintaince { get; set; }
		public string Security_Deposit { get; set; }
		public int NoOfChecks { get; set; }
		public string LandLordDetails { get; set; }
		public string Nameoftheowner { get; set; }
		public string OwnersEmaiAddress { get; set; }
		public string MobileNoOftheOwner { get; set; }

	}
}