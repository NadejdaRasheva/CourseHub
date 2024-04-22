using System.ComponentModel.DataAnnotations;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;
using static CourseHub.Core.Constants.MessageConstants;

namespace CourseHub.Core.Models.Review
{
	public class ReviewFormViewModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[Range(ReviewMinRating, ReviewMaxRating, ErrorMessage = RatingMessage)]
		public int Rating { get; set; }


		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ReviewCommentsMaxLength, MinimumLength = ReviewCommentsMinLength,
			ErrorMessage = LengthMessage)]
		public string Comment { get; set; } = string.Empty;
		public int CourseId { get; set; }
	}
}
