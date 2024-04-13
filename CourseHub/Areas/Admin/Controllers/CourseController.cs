using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Admin;
using CourseHub.Extensions;
using CourseHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Xml.Linq;
using static CourseHub.Core.Constants.RoleConstants;

namespace CourseHub.Areas.Admin.Controllers
{
    public class CourseController : AdminBaseController
    {
        private readonly ICourseService _courses;
        private readonly ITeacherService _teachers;

        public CourseController(ICourseService courses,
            ITeacherService teachers)
        {
            _courses = courses;
            _teachers = teachers;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            int teacherId = await _teachers.GetTeacherIdAsync(userId) ?? 0;

            var myCourses = new MyCoursesViewModel()
            {
                AddedCourses = await _courses.AllCoursesByTeacherIdAsync(teacherId),
                JoinedCourses = await _courses.AllCoursesByUserIdAsync(userId)
            };

            return View(myCourses);
        }
    }
}
