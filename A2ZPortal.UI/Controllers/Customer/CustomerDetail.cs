using A2ZPortal.Core.Entities.Customers;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.Customer
{
    public class CustomerDetail : Controller
    {
        private readonly IGenericRepository<CustomerDetails, int> _ICustomerRepository;

        public CustomerDetail(IGenericRepository<CustomerDetails, int> customerRepository)
        {
            _ICustomerRepository = customerRepository;
        }
        public IActionResult Index(CustomerDetails model)
        {

            return View(ViewPageHelper.InstanceHelper.GetPathDetail("Customer", "Authenticate"), model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDetails model)
        {
            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var response = await _ICustomerRepository.CreateEntity(createModel);

            ModelState.Clear();

            model.Message = response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error ?
                "Something wents wrong, Please contact admin." :
                "Thanks for registring in A2Z portal, Login to start your session.";

            return RedirectToAction("Index", "CustomerDetail", model);
        }

        //public async Task<IActionResult> Login(Models.LoginModel model)
        //{
        //    if (model.UserName == "admin" && model.Password == "admin")
        //    {
        //        HttpContext.Session.SetString("UserName", model.UserName);
        //    }
        //}

    }
}
