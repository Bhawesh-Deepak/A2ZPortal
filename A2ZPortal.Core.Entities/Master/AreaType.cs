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
    [Table("AreaType", Schema = "Master")]
    public class AreaType : BaseModel<int>
    {
        [Required(ErrorMessage = "Area Type is Required.")]
        [Display(Prompt = "Enter Area Type.")]
        public string AreaTypeName { get; set; }
    }
    
}
