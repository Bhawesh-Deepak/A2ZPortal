using A2ZPortal.Core.ViewModel.PropertyDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    public class RentCommercialVM : PropertyBaseModel
    {
        public string Nameoftheowner { get; set; }
        public string OwnersEmaiAddress { get; set; }
        public string MobileNoOftheOwner { get; set; }
    }
}
