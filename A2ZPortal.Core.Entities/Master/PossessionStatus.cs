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
    [Table("PossessionStatus", Schema = "Master")]
    public class PossessionStatus : BaseModel<int>
    {
        [Required(ErrorMessage = "Possession Status is Required.")]
        [Display(Prompt = "Enter Possession Status.")]
        public string StatusName { get; set; }
    }
    
}
