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
        public string Description { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Image { get; set; }
    }
}
