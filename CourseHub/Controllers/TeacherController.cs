using CourseHub.Attributes;
using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Teacher;
using CourseHub.Core.Services;
using CourseHub.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Controllers
{
	[Authorize]
	public class TeacherController : Controller
	{
		private readonly ITeacherService _teachers;

		public TeacherController(ITeacherService teachers)
		{
			_teachers = teachers;
		}

		[HttpGet]
		[NotTeacher]
		public IActionResult Become()
		{
			var model = new BecomeTeacherFormModel();
			return View(model);
		}

		[HttpPost]
		[NotTeacher]
		public async Task<IActionResult> Become(BecomeTeacherFormModel model)
		{
			var userId = User.Id();
			if(await _teachers.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber),
					"This number already exists. Use another one.");
			}
			if(!ModelState.IsValid)
			{
				return View(model);
			}

			await _teachers.CreateAsync(userId, model.PhoneNumber);
			return RedirectToAction(nameof(CourseController.All), "Course");
		}
	}
}
