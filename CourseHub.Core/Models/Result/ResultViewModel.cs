using System.ComponentModel.DataAnnotations;
using static CourseHub.Core.Constants.MessageConstants;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Models.Result
{
	public class ResultViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[Range(ResultMinGrade, ResultMaxGrade, ErrorMessage = GradeMessage)]
		public decimal Grade { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ResultFeedbackMaxLength, MinimumLength = ResultFeedbackMinLength,
			ErrorMessage = LengthMessage)]
		public string Feedback { get; set; } = string.Empty;
		public int CourseId { get; set; }
		public string CourseName { get; set; } = string.Empty;
		public string StudentId { get; set; } = string.Empty;
	}
}
