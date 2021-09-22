using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace A2ZPortal.UI.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "| AboutUs";
            return View();
        }
    }
}
