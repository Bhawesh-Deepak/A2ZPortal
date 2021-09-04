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
    [Table("SizeAndStructure", Schema = "Master")]
    public class SizeAndStructure : BaseModel<int>
    {
        [Required(ErrorMessage = "Size And Structure is Required.")]
        [Display(Prompt = "Enter Size And Structure.")]
        public string Name { get; set; }
    }
    
}
