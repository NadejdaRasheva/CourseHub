using CourseHub.Core.Models.Course;

namespace CourseHub.Core.Models.Admin
{
    public class MyCoursesViewModel
    {
        public IEnumerable<CourseServiceModel> AddedCourses { get; set; } = new List<CourseServiceModel>();
        public IEnumerable<CourseServiceModel> JoinedCourses { get; set; } = new List<CourseServiceModel>();
    }
}
