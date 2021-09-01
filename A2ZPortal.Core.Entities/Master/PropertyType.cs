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
    [Table("PropertyType", Schema = "Master")]
    public class PropertyType : BaseModel<int>
    {
        [Required(ErrorMessage = "Property Type Name is Required.")]
        [Display(Prompt = "Enter Property Type Name.")]
        public string PropertyTypeName { get; set; }
    }

}
