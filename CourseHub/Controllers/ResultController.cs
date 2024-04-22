using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Result;
using CourseHub.Core.Models.Review;
using CourseHub.Core.Services;
using CourseHub.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultService resultService;
        private readonly ICourseService courseService;

        public ResultController(
            IResultService _resultService,
            ICourseService _courseService)
        {
            resultService = _resultService;
            courseService = _courseService;
        }

        [HttpGet]
        public async Task<IActionResult> AllStudents(int id)
        {
            if (await courseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await resultService.GetCourseStudents(id);

            ViewData["courseId"] = id;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id, string studentId)
        {
            if (await courseService.HasTeacherWithIdAsync(id, User.Id()) == false)
            {
                return RedirectToAction(nameof(AllStudents), new { id = id });
            }

			if (await resultService.GetStudentResult(id, studentId) != null)
			{
				var result = await resultService.GetStudentResult(id, studentId);
				var resultId = result.Id;
				return RedirectToAction(nameof(Edit), new { id = resultId });
			}

			var model = new ResultFormViewModel()
            {
                CourseId = id,
                StudentId = studentId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ResultFormViewModel model)
        {
            if (await courseService.HasTeacherWithIdAsync(model.CourseId, User.Id()) == false)
            {
                return RedirectToAction(nameof(AllStudents), new { id = model.CourseId });
            }
            
            if(await resultService.GetStudentResult(model.CourseId, model.StudentId) != null)
            {
                var result = await resultService.GetStudentResult(model.CourseId, model.StudentId);
                var resultId = result.Id;
				return RedirectToAction(nameof(Edit), new {id = resultId});
			}

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await resultService.AddAsync(model);

            TempData["message"] = "Result successfully added.";
            TempData["messageType"] = "success";

            return RedirectToAction(nameof(AllStudents), new { id = model.CourseId });
        }


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (await resultService.ResultExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await resultService.HasTeacherWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = await resultService.CreateResultFormViewModelByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, ResultFormViewModel model)
		{
			if (await resultService.ResultExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await resultService.HasTeacherWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await resultService.EditAsync(id, model);

			TempData["message"] = "Result successfully edited.";
			TempData["messageType"] = "success";

			return RedirectToAction(nameof(AllStudents), new { id = model.CourseId });
		}

        [HttpGet]
        public async Task<IActionResult> StudentResult(int courseId, string studentId)
        {
			var model = await resultService.GetStudentResult(courseId, studentId);

            return View(model);
        }
	}
}
