using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.VirtualTour
{
    public class VirtualTourModel: BaseModel<int>
    {
        public int PropertyId { get; set; }
        public string ImageSrc { get; set; }
        public string PropertyName { get; set; }
    }
}
