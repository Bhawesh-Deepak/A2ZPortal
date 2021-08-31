using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("PropertyStatus",Schema = "Master")]
    public class PropertyStatusModel:BaseModel<int>
    {
        [Required(ErrorMessage = "Property status is required.")]
        [MaxLength(500, ErrorMessage = "Property Status too large.")]
        [Column("PropertyStatus")]
        public string PropertyStatus { get; set; }
    }
}
