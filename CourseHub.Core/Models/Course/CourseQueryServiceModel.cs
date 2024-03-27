namespace CourseHub.Core.Models.Course
{
	public class CourseQueryServiceModel
	{
        public int TotalCoursesCount { get; set; }
        public IEnumerable<CourseServiceModel> Courses { get; set; }
        = new List<CourseServiceModel>();
    }
}
