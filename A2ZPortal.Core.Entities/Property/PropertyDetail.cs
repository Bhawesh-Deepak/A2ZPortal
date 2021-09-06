using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("PropertyDetail", Schema = "Property")]
    public class PropertyDetail: BaseModel<int>
    {
        [Required(ErrorMessage ="Location is required.")]
        public int LocationId { get; set; }
        [Required(ErrorMessage ="Sub Location is required.")]
        public int SubLocationId { get; set; }
        [Required(ErrorMessage ="Property Type is required.")]
        public int PropertyTypeId { get; set; }
        [Required(ErrorMessage = "Property Status is required.")]
        public int PropertyStatusId { get; set; }
        [Required(ErrorMessage = "Bath Room is required.")]
        public int BathRoomId { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
        public int BudgetId { get; set; }

        [RegularExpression("([1-9][0-9]*)")]
        [Required(ErrorMessage ="Area covered is required.")]
        public decimal AreaCovered { get; set; }

        [RegularExpression("([1-9][0-9]*)")]
        [Required(ErrorMessage = "Total Area covered is required.")]
        public decimal TotalArea { get; set; }

        [Required(ErrorMessage = "Property Name is required.")]
        [DataType(DataType.Text)]
        
        public string PropertyName { get; set; }

        [DataType(DataType.MultilineText)]
        public string ProprtyDescription { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public int AgentId { get; set; }

        [Required(ErrorMessage = "Bed Room is required.")]
        public int BedRoomId { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceId { get; set; }

    }
}