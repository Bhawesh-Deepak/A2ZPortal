using A2ZPortal.Core.Entities.Customers;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.Customer
{
    [CustomAuthenticate]
    public class CustomerTransaction : Controller
    {
        private readonly IGenericRepository<OrderManagement, int> _IOrderRepository;
        private readonly IGenericRepository<CustomerDetails, int> _ICustomerRepository;
    

        public CustomerTransaction(IGenericRepository<OrderManagement, int> orderRepository, IGenericRepository<CustomerDetails, int> customerRepository)
        {
            _IOrderRepository = orderRepository;
            _ICustomerRepository = customerRepository;
        }
        public async Task<IActionResult> AddToFavourite(int propId)
        {
            var customerPhone = HttpContext.Session.GetString("UserPhone");

            var customer = (await _ICustomerRepository.GetSingle(x => x.CustomerPhone == customerPhone)).Entity;

            var orderDetail = new OrderManagement()
            {
                PropertyId = propId,
                CustomerId = customer.Id,
                IsAddToWishList = true
            };
            var createModel = CommonCrudHelper.CommonCreateCode(orderDetail, 1);
            var response = await _IOrderRepository.CreateEntity(createModel);

            return RedirectToAction("GetCartDetail");
        }
        public async Task<IActionResult> GetCartDetail() 
        {
            var customerPhone = HttpContext.Session.GetString("UserPhone");

            var customer = (await _ICustomerRepository.GetSingle(x => x.CustomerPhone == customerPhone)).Entity;

            return View(ViewPageHelper.InstanceHelper.GetPathDetail("Customer", "OrderManagement"));
        }
    }
}
