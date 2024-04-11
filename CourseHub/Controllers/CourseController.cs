using CourseHub.Core.Contracts;
using CourseHub.Core.Extensions;
using CourseHub.Core.Models.Course;
using CourseHub.Extensions;
using CourseHub.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

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
		public async Task<IActionResult> All([FromQuery]AllCoursesQueryModel query)
		{
			var queryResult = await _courses.AllAsync(
				query.Category,
				query.SearchTerm,
				query.Sorting,
				query.Filtering,
				query.CurrentPage,
				AllCoursesQueryModel.CoursesPerPage);

			query.TotalCoursesCount = queryResult.TotalCoursesCount;
			query.Courses = queryResult.Courses;

			var courseCategories = await _courses.AllCategoriesNamesAsync();
			query.Categories = (IEnumerable<string>)courseCategories;

			return View(query);
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			IEnumerable<CourseServiceModel> myCourses = null;

			var userId = User.Id();

			var currentTeacherId = await _teachers.GetTeacherIdAsync(userId);
			myCourses = await _courses.AllCoursesByTeacherIdAsync(currentTeacherId ?? 0);

			return View(myCourses);
		}

        [HttpGet]
        public async Task<IActionResult> Join()
        {
            IEnumerable<CourseServiceModel> joinedCourses = null;

            var userId = User.Id();

            joinedCourses = await _courses.AllCoursesByUserIdAsync(userId);

            return View(joinedCourses);
        }

        [HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			if (await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			var courseModel = await _courses.CourseDetailsByIdAsync(id);

			if(information != courseModel.GetInformation())
			{
				return BadRequest();
			}

			return View(courseModel);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			if(await _teachers.ExistsByIdAsync(User.Id()) == false)
			{
				return RedirectToAction(nameof(TeacherController.Become), "Teacher");
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
                String.Format(model.StartDate, DateFormat),
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _startDate))
            {
                ModelState.AddModelError(nameof(_startDate), $"Invalid date! Format is: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
				String.Format(model.EndDate, DateFormat),
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

			var newCourseId = await _courses.CreateAsync(model.Name, model.Description, model.City,
				_startDate, _endDate, model.Frequency, 
				model.Price, model.CategoryId, teacherId ?? 0); //not breaking because we have checked

			return RedirectToAction(nameof(Details), new { id = newCourseId, information = model.GetInformation() }); ;
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if(await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if(await _courses.HasTeacherWithIdAsync(id, this.User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = await _courses.GetCourseFormByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, CourseFormModel course)
		{
            DateTime _startDate = DateTime.Today;
            DateTime _endDate = DateTime.Today;
            if (!DateTime.TryParseExact(
                String.Format(course.StartDate, DateFormat),
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _startDate))
            {
                ModelState.AddModelError(nameof(_startDate), $"Invalid date! Format is: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
				String.Format(course.EndDate, DateFormat),
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _endDate))
            {
                ModelState.AddModelError(nameof(_endDate), $"Invalid date! Format is: {DataConstants.DateFormat}");
            }
            if (await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await _courses.HasTeacherWithIdAsync(id, this.User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if(await _courses.CategoryExistsAsync(course.CategoryId) == false)
			{
				this.ModelState.AddModelError(nameof(course.CategoryId),
					"Category does not exist.");
			}

			if(!ModelState.IsValid)
			{
				course.Categories = await _courses.AllCategoriesAsync();
			}

			await _courses.EditAsync(id, course.Name, course.Description,
				course.City,_startDate, _endDate, course.Frequency,
				course.Price, course.CategoryId);

			return RedirectToAction(nameof(Details), new { id = id, information = course.GetInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if(await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await _courses.HasTeacherWithIdAsync(id, this.User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var course = await _courses.CourseDetailsByIdAsync(id);

			var model = new CourseDetailsViewModel()
			{
				Name = course.Name,
				City = course.City
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, CourseDetailsViewModel course)
		{
			if (await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await _courses.HasTeacherWithIdAsync(id, this.User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}


			await _courses.DeleteAsync(course.Id);
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{

			if (await _courses.ExistsAsync(id) == false)
			{
				return BadRequest();
			}
			if (await _courses.HasTeacherWithIdAsync(id, this.User.Id())
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await _courses.JoinAsync(id, User.Id());

			return RedirectToAction(nameof(Join));
        }

		[HttpPost]
		public async Task<IActionResult> Leave(int id, string participantId)
		{
            if (await _courses.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

			await _courses.LeaveAsync(id, User.Id());

            return RedirectToAction(nameof(All));
		}
	}
}
