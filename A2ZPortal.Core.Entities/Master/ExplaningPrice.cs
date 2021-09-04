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
    [Table("ExplaningPrice", Schema = "Master")]
    public class ExplaningPrice : BaseModel<int>
    {
        [Required(ErrorMessage = "Explaning Price is Required.")]
        [Display(Prompt = "Enter Explaning Price.")]
        public string PriceName { get; set; }
    }
    
}
