using CourseHub.Core.Models.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Controllers
{
	[Authorize]
	public class TeacherController : Controller
	{
		public async Task<IActionResult> Become()
		{
			var model = new BecomeTeacherFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeTeacherFormModel model)
		{
			return RedirectToAction(nameof(CourseController.All), "Course");
		}
	}
}
