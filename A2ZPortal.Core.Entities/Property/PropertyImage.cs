using System.ComponentModel.DataAnnotations.Schema;
using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("PropertyImage", Schema = "Property")]
    public class PropertyImage: BaseModel<int>
    {
        public int PropertyDetailId { get; set; }
        public string ImagePath { get; set; }
        public bool IsPrimaryImage { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsRecent { get; set; }
    }
}