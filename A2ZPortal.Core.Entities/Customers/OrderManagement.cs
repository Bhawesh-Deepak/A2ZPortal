using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Customers
{
    [Table("OrderManagement", Schema = "Customer")]
    public class OrderManagement: BaseModel<int>
    {
        public int CustomerId { get; set; }
        public int PropertyId { get; set; }
        public bool IsAddToCart { get; set; } = false;
        public bool IsAddToWishList { get; set; } = false;
        public bool IsOrdered { get; set; } = false;
    }
}
