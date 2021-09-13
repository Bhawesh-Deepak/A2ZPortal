using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class FeaturedPropertyVm
    {
        public string ImagePath { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string PlaceAddress { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public decimal TotalArea { get; set; }
        public string CategoryName { get; set; }
        public string PropertyType { get; set; }
        public decimal Price { get; set; }
        public int PropertyId { get; set; }
    }
}
