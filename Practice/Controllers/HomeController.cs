using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System.Diagnostics;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PracticeContext _practiceContext;

        public HomeController(ILogger<HomeController> logger, PracticeContext practiceContext)
        {
            _logger = logger;
            _practiceContext = practiceContext;
        }

        public IActionResult Index()
        {
            var users = _practiceContext.Users.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}