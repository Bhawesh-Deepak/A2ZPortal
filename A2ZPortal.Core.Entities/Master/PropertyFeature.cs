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
    [Table("PropertyFeature", Schema = "Property")]
    public class PropertyFeature : BaseModel<int>
    {
        [Required(ErrorMessage = "Feature Name is Required.")]
        public int FeatureId { get; set; }
        public int PropertyDetailId { get; set; }
    }
    
}
