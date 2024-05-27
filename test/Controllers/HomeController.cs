using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test.DbEntities.ViewModels;
using test.Models;
using test.Services.IServices;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminServices _adminServices;

        public HomeController(ILogger<HomeController> logger, IAdminServices adminServices)
        {
            _logger = logger;
            _adminServices = adminServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            DashboardViewModel model = _adminServices.GetUserTable();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}