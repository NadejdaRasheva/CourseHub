using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Course;
using CourseHub.Extensions;
using CourseHub.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CourseHub.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		private readonly ICourseService _courses;
		private readonly ITeacherService _teachers;
        public CourseController(ICourseService courses,
			ITeacherService teachers)
        {
            _courses = courses;
			_teachers = teachers;
        }

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
		public async Task<IActionResult> Add()
		{
			if(await _teachers.ExistsByIdAsync(User.Id()) == false)
			{
				return RedirectToAction(nameof(TeacherController.Become), "Agent");
			}

			return View(new CourseFormModel
			{
				Categories = await _courses.AllCategoriesAsync()
			});

		}

		[HttpPost]
		public async Task<IActionResult> Add(CourseFormModel model)
		{
            DateTime _startDate = DateTime.Now;
            DateTime _endDate = DateTime.Now;
            if (!DateTime.TryParseExact(
                model.StartDate,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _startDate))
            {
                ModelState.AddModelError(nameof(_startDate), $"Invalid date! Format is: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.EndDate,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _endDate))
            {
                ModelState.AddModelError(nameof(_endDate), $"Invalid date! Format is: {DataConstants.DateFormat}");
            }

			if(await _teachers.ExistsByIdAsync(User.Id()) == false)
			{
				return RedirectToAction(nameof(TeacherController.Become), "Teacher");
			}

			if(await _courses.CategoryExistsAsync(model.CategoryId) == false)
			{
				this.ModelState.AddModelError(nameof(model.CategoryId),
					"Category does not exist.");
			}

			if(!ModelState.IsValid)
			{
				model.Categories = await _courses.AllCategoriesAsync();
				return View(model);
			}

			int? teacherId = await _teachers.GetTeacherIdAsync(User.Id());

			var newCourseId = await _courses.CreateAsync(model.Name, model.Description,
				_startDate, _endDate, model.Frequency, 
				model.Price, model.CategoryId, teacherId ?? 0); //not breaking because we have checked

			return RedirectToAction(nameof(Details), new { id = newCourseId });
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
