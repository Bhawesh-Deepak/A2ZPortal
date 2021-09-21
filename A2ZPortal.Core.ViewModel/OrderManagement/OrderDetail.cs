using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.OrderManagement
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PlaceAddress { get; set; }
        public string CategoryName { get; set; }
        public string PropertyTypeName { get; set; }
        public string Image { get; set; }
        public int PropertyId { get; set; }
    }
}
