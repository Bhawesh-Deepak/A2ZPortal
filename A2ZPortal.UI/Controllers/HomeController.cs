using System;
using System.Diagnostics;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using A2ZPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A2ZPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<ModuleMaster, int> _moduleMasterRepository;
        public HomeController(ILogger<HomeController> logger, IGenericRepository<ModuleMaster, int> moduleMasterRepository)
        {
            _logger = logger;
            _moduleMasterRepository = moduleMasterRepository;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _moduleMasterRepository.CreateEntity(new ModuleMaster()
            {
                ModuleName = "Home",
                CreatedBy = 1,
                IconImagePath = string.Empty,
                SortOrder = 1,
                CreatedDate = DateTime.Now

            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}