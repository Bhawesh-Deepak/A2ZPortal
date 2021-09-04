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
    [Table("DefiningLocation", Schema = "Master")]
    public class DefiningLocation : BaseModel<int>
    {
        [Required(ErrorMessage = "Defining Location is Required.")]
        [Display(Prompt = "Enter Defining Location.")]
        public string DLocationName { get; set; }
    }
    
}
