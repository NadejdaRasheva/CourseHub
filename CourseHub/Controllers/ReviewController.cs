using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Review;
using CourseHub.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly ICourseService courseService;

        public ReviewController(
            IReviewService _reviewService,
            ICourseService _courseService)
        {
            reviewService = _reviewService;
            courseService = _courseService;
        }

        [HttpGet]
        public async Task<IActionResult> AllForCourse(int id)
        {
            if (await courseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await reviewService.GetForCourseAsync(id);

            ViewData["courseId"] = id;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            if (await courseService.HasTeacherWithIdAsync(id, User.Id()))
            {
                return RedirectToAction(nameof(AllForCourse), new { id = id });
            }

            var model = new ReviewFormViewModel()
            {
                CourseId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormViewModel model)
        {
            if (await courseService.HasTeacherWithIdAsync(model.CourseId, User.Id()) == true)
            {
                return RedirectToAction(nameof(AllForCourse), new { id = model.CourseId });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await reviewService.AddAsync(model, User.Id());

            TempData["message"] = "Review successfully added.";
            TempData["messageType"] = "success";

            return RedirectToAction(nameof(AllForCourse), new { id = model.CourseId });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            if (await reviewService.ReviewExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await reviewService.HasReviewerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            int carId = await reviewService.GetReviewCourseIdAsync(id);

            await reviewService.RemoveReviewAsync(id);

            TempData["message"] = "Review successfully removed.";
            TempData["messageType"] = "success";

            return RedirectToAction(nameof(AllForCourse), new { id = carId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await reviewService.ReviewExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await reviewService.HasReviewerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await reviewService.CreateReviewFormViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReviewFormViewModel model)
        {
            if (await reviewService.ReviewExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await reviewService.HasReviewerWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await reviewService.EditAsync(id, model);

            TempData["message"] = "Review successfully edited.";
            TempData["messageType"] = "success";

            return RedirectToAction(nameof(AllForCourse), new { id = model.CourseId });
        }
    }
}
