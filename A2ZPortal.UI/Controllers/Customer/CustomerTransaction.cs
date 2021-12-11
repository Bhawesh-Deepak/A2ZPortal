using A2ZPortal.Core.Entities.Customers;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.Customer
{
    [CustomAuthenticate]
    [BreadcrumbActionFilter]
    public class CustomerTransaction : Controller
    {
        private readonly IGenericRepository<OrderManagement, int> _IOrderRepository;
        private readonly IGenericRepository<CustomerDetails, int> _ICustomerRepository;
        private readonly IOrderTransactionRepository _IOrderTransactionRepository;
        private readonly string APIURL;
        public CustomerTransaction(IGenericRepository<OrderManagement, int> orderRepository, 
            IGenericRepository<CustomerDetails, int> customerRepository, 
            IOrderTransactionRepository orderTransactionRepository, IConfiguration configuration)
        {
            _IOrderRepository = orderRepository;
            _ICustomerRepository = customerRepository;
            _IOrderTransactionRepository = orderTransactionRepository;
            APIURL = configuration.GetSection("APIURL").Value;
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

            var response = await _IOrderTransactionRepository.GetCustomerOrderDetail(1002);

            response.ForEach(item =>
            {
                item.Image = APIURL + item.Image;
            });

            return View(ViewPageHelper.InstanceHelper.GetPathDetail("Customer", "OrderManagement"),response);
        }

        public async Task<IActionResult> DeleteCartProperty(int id)
        {
            var model = await _IOrderRepository.GetSingle(x=>x.Id==id);

            var updateModel = CommonCrudHelper.CommonUpdateCode(model.Entity, 1);

            var response = await _IOrderRepository.Update(updateModel);

            if (response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error)
                return Json(-1);

            return Json(1);

        }
    }
}
