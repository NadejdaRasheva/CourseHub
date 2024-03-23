using CourseHub.Core.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = new AllCoursesQueryModel();
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = new CourseDetailsViewModel();
			return View(model);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CourseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = new CourseFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, CourseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = new CourseDetailsViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, CourseDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			return RedirectToAction(nameof(All));
		}
	}
}
