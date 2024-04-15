using CourseHub.Core.Models.Home;
using CourseHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Course");
            }
            else
            {
                var model = new IndexViewModel();
                return View(model);
            }
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
	            return View("Error404");
            }

            if (statusCode == 500)
            {
	            return View("Error500");
            }

			return View();
        }
    }
}