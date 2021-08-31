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
    [Table("PropertyFeature", Schema = "Master")]
    public class PropertyFeature : BaseModel<int>
    {
        [Required(ErrorMessage = "Feature Name is Required.")]
        [Display(Prompt = "Enter Feature Name.")]
        public string FeatureName { get; set; }
    }
    
}
