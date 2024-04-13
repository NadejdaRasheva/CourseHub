using CourseHub.Core.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Models.Admin
{
    public class MyCoursesViewModel
    {
        public IEnumerable<CourseServiceModel> AddedCourses { get; set; } = new List<CourseServiceModel>();
        public IEnumerable<CourseServiceModel> JoinedCourses { get; set; } = new List<CourseServiceModel>();
    }
}
