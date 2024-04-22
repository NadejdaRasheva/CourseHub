using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
	public class Review
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int CourseId { get; set; }

		[Required]
		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;

		[Required]
		public string ReviewerId { get; set; } = string.Empty;

		[Required]
		[ForeignKey(nameof(ReviewerId))]
		public ApplicationUser Reviewer { get; set; } = null!;

		[Required]
		public int Rating { get; set; }

		[Required]
		[MaxLength(ReviewCommentsMaxLength)]
		public string Comment { get; set; } = string.Empty;
	}
}
