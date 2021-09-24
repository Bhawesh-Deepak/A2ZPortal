using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace A2ZPortal.UI.Controllers
{
    public class AboutUs : Controller
    {
        private readonly IGenericRepository<Contact, int> _IContactRepository;
        public AboutUs(IGenericRepository<Contact, int> ContactRepository)
        {
            _IContactRepository = ContactRepository;
        }
        public IActionResult Index(Contact model)
        {
            ViewData["Title"] = "| AboutUs";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact model, string returnUrl)
        {
            model.ReturnUrl = returnUrl;
            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var response = await _IContactRepository.CreateEntity(createModel);

            ModelState.Clear();
            model.ErrorMessage = response.ResponseStatus == Core.Entities.Common.ResponseStatus.Error ?
                            "Something wents wrong, Please contact admin." :
                            "Thanks for contact me. i will contact you soon";

            return RedirectToAction("Index", "AboutUs", model);
        }
    }
}
