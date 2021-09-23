using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("PropertyBrochure", Schema = "Property")]
    public class Brochure: BaseModel<int>
    {
        public int PropertyId { get; set; }
        public string BrochurePath { get; set; }
    }
}
