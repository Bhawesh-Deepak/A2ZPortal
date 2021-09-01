using A2ZPortal.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("SubLocation", Schema= "Master")]
    public class SubLocation: BaseModel<int>
    {
        [Required(ErrorMessage ="Location Id is required.")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "Sub Location is required.")]
        public string SubLocationName { get; set; }
    }
}
