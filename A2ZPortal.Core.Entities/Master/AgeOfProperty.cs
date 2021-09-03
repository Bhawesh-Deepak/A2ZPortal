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
    [Table("AgeOfProperty", Schema = "Master")]
    public class AgeOfProperty : BaseModel<int>
    {
        [Required(ErrorMessage = "Age Of Property is Required.")]
        [Display(Prompt = "Enter Age Of Property.")]
        public int Age { get; set; }
    }
   
}
