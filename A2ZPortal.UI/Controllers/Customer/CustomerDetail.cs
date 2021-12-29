using A2ZPortal.Core.Entities.Customers;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers.Customer
{
    [BreadcrumbActionFilter]
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
        public IActionResult Register(CustomerDetails model)
        {
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("Customer", "RegisterUser"), model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDetails model, string returnUrl)
        {
            model.ReturnUrl = returnUrl;
            model.Password = PasswordEncryptor.Instance.Encrypt(model.Password, "SQYPAYROLLLEADMANAGEMENT");
            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var response = await _ICustomerRepository.CreateEntity(createModel);

            ModelState.Clear();

            model.Message = response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error ?
                "Something wents wrong, Please contact admin." :
                "Thanks for registring in A2Z portal, Login to start your session.";

            return RedirectToAction("Index", "CustomerDetail", model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(CustomerDetails model, string returnUrl)
        {
            var password= PasswordEncryptor.Instance.Encrypt(model.Password, "SQYPAYROLLLEADMANAGEMENT");
            var responseData = await _ICustomerRepository.GetSingle(x => x.IsActive && !x.IsDeleted && x.CustomerEmail == model.CustomerEmail && x.Password ==  password);

            if (responseData.Entity != null)
            {

                HttpContext.Session.SetString("UserPhone", responseData.Entity.CustomerPhone);
                HttpContext.Session.SetString("UserEmail", responseData.Entity.CustomerEmail);
                HttpContext.Session.SetString("CustomerId", responseData.Entity.Id.ToString());


                if (string.IsNullOrEmpty(returnUrl))
                    return await Task.Run(() => RedirectToAction("Index", "Home"));


                return await Task.Run(() => Redirect(returnUrl));
            }
            ModelState.Clear();

            model.PlaceAddress = responseData.ResponseStatus == Core.Entities.Common.ResponseStatus.Error ?
                "Something wents wrong, Please contact admin." :
                "Invalid Login Credential !!!!!.";

            return RedirectToAction("Index", "CustomerDetail", model);
        }
        [HttpGet, CustomAuthenticate]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
             


            
            return RedirectToAction("Index", "CustomerDetail");
        }

    }
}
