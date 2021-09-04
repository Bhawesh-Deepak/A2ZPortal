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
    [Table("SuitableFor", Schema = "Master")]
    public class SuitableFor : BaseModel<int>
    {
        [Required(ErrorMessage = "Suitable For is Required.")]
        [Display(Prompt = "Enter Suitable For.")]
        public string SuitableName { get; set; }
    }
    
}
