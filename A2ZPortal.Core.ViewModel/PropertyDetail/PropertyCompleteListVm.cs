using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class PropertyCompleteListVm
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string PlaceAddress { get; set; }
        public string CategoryName { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public decimal Area { get; set; }
        public int TotalCount { get; set; }
    }
}
