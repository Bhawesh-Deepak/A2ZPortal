using A2ZPortal.Core.ViewModel.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.CustomerRepository
{
    public interface IOrderTransactionRepository
    {
        Task<List<OrderDetail>> GetCustomerOrderDetail(int customerId);
    }
}
