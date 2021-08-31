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
        public int BathRoomId { get; set; }
        public int BudgetId { get; set; }
        public decimal AreaCovered { get; set; }
        public decimal TotalArea { get; set; }
        public string PropertyName { get; set; }
        public string ProprtyDescription { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public int AgentId { get; set; }
        public int BedRoomId { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceId { get; set; }

    }
}