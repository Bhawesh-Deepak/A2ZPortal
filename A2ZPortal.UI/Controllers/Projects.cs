using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace A2ZPortal.UI.Controllers
{
    public class Projects : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
