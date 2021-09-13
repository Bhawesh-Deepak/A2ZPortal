using A2ZPortal.Core.ViewModel.RequestFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class PropertySearchVm: PropertyRequestModel
    {
        public int? PropertyType { get; set; }
        public int? PropertyStatus { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxArea { get; set; }
        public int? MinArea { get; set; }
    }
}
