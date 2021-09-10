using A2ZPortal.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    public class PropertyDetails : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PropertyDetail()
        {
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("PropertyDetails", "PropertyDetailIndex"));
        }
    }
}
