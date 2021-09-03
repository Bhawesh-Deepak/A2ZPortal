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
    [Table("FurnishedStatus", Schema = "Master")]
    public class FurnishedStatus : BaseModel<int>
    {
        [Required(ErrorMessage = "Furnished Status is Required.")]
        [Display(Prompt = "Enter Furnished Status.")]
        public string StatusName { get; set; }
    }
    
}
