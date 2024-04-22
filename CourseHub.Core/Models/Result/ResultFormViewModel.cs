﻿using System.ComponentModel.DataAnnotations;
using static CourseHub.Core.Constants.MessageConstants;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Models.Result
{
	public class ResultFormViewModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[Range(ResultMinGrade, ResultMaxGrade, ErrorMessage = GradeMessage)]
		public decimal Grade { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ResultFeedbackMaxLength, MinimumLength = ResultFeedbackMinLength,
			ErrorMessage = LengthMessage)]
		public string Feedback { get; set; } = string.Empty;
		public int CourseId { get; set; }
		public string StudentId { get; set; } = string.Empty;
		public string StudentName { get; set; } = string.Empty;
	}
}
