using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
	public class Result
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public decimal Grade { get; set; }

		[Required]
		[MaxLength(ResultFeedbackMaxLength)]
		public string Feedback { get; set; } = string.Empty;

		[Required]
		public int CourseId { get; set; }

		[Required]
		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;

		[Required]
		public string StudentId { get; set; } = string.Empty;

		[Required]
		[ForeignKey(nameof(StudentId))]
		public ApplicationUser Student { get; set; } = null!;
	}
}
