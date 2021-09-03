using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("Amenities", Schema = "Master")]
    public class Amenities : BaseModel<int>
    {
        [Required(ErrorMessage = "Amenities is Required.")]
        [Display(Prompt = "Enter Amenities.")]
        public string AmenitiesName { get; set; }
    }
    
}
