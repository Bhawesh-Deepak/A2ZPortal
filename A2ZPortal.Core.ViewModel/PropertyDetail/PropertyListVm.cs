using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class PropertyListVm
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string PlaceAddress { get; set; }
        public decimal Price { get; set; }
    }
}
