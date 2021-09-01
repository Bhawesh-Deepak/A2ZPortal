using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.PropertyDetail
{
    public class PropertyDetailVm
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string SubLocation { get; set; }
        public string PropertyTypeName { get; set; }
        public string PropertyStatus { get; set; }
        public int BedRoom { get; set; }
        public int BathRoom { get; set; }
        public decimal Budget { get; set; }
        public decimal TotalArea { get; set; }
        public decimal AreaCovered { get; set; }
        public string PropertyName { get; set; }
        public string PlaceAddress { get; set; }
        public string PlaceId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Images { get; set; }
        public string Features { get; set; }
    }
}
