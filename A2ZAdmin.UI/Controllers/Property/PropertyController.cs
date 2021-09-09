using A2ZAdmin.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Property
{
    [CustomAuthenticate]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
