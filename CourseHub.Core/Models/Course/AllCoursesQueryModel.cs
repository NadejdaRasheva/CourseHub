using CourseHub.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CourseHub.Core.Models.Course
{
	public class AllCoursesQueryModel
	{
		public const int CoursesPerPage = 6;
		public string Category { get; init; } = null!;

		[Display(Name = "Search by text")]
		public string SearchTerm { get; init; } = null!;
		public CourseSorting Sorting { get; init; }
		public CourseFiltering Filtering { get; init; }
		public int CurrentPage { get; init; } = 1;
		public int TotalCoursesCount { get; set; }
		public IEnumerable<string> Categories { get; set; } = null!;
		public IEnumerable<CourseServiceModel> Courses { get; set; }
		=new List<CourseServiceModel>();
	}
}
