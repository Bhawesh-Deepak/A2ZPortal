using A2ZPortal.Core.ViewModel.PropertyDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    public class SellCommercialVm: PropertyBaseModel
    {
        public string SpaceType { get; set; }
        public string FloorNo { get; set; }
    }
}
