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
    [Table("ExplaningProperty", Schema = "Master")]
    public class ExplaningProperty : BaseModel<int>
    {
        [Required(ErrorMessage = "Explaning Property is Required.")]
        [Display(Prompt = "Enter Explaning Property.")]
        public string Name{ get; set; }
    }
    
}
