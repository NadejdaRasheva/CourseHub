using System.ComponentModel.DataAnnotations;
using static CourseHub.Core.Constants.MessageConstants;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Models.Course
{
	public class CourseServiceModel
	{
        public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CourseNameMaxLength,
			MinimumLength = CourseNameMinLength,
			ErrorMessage = LengthMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CityNameMaxLength,
			MinimumLength = CityNameMinLength,
			ErrorMessage = LengthMessage)]
		public string City { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(CourseMinFrequency, CourseMaxFrequency, ErrorMessage = FrequencyMessage)]
		[Display(Name = "Times per week")]
		public int Frequency { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal), CourseMinPrice, CourseMaxPrice,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = PriceMessage)]
		[Display(Name = "Price of the course")]
		public decimal Price { get; set; }
    }
}