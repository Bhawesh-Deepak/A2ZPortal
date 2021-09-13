using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Customers
{
    public class CustomerDetails:BaseModel<int>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string PlaceId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PlaceAddress { get; set; }
    }
}
