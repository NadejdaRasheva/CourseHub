using CourseHub.Core.Contracts;

namespace CourseHub.Core.Models.Course
{
	public class CourseDetailsViewModel : ICourseModel
	{
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
    }
}
