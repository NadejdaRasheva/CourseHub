using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
	{
        public IActionResult DashBoard()
        {
            return View();
        }

    }
}
