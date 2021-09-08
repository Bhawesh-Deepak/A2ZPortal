using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("PropertyBanner", Schema = "Property")]
    public class PropertyBanner:BaseModel<int>
    {
        public int PropertyId { get; set; }
        public bool IsExclusiveProperty { get; set; }
        public bool IsRecentProperty { get; set; }
    }
}
