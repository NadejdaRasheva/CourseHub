using CourseHub.Core.Models.Teacher;
using System.ComponentModel.DataAnnotations;

namespace CourseHub.Core.Models.Course
{
	public class CourseDetailsServiceModel : CourseServiceModel
	{
		public string Description { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		[Display(Name = "Start Date")]
		public string StartDate { get; set; }
		[Display(Name = "End Date")]
		public string EndDate { get; set; }
		public TeacherServiceModel Teacher { get; set; } = null!;
    }
}
