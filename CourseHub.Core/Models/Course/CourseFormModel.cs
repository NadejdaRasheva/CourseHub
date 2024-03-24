using System.ComponentModel.DataAnnotations;
using static CourseHub.Core.Constants.MessageConstants;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Models.Course
{
	public class CourseFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CourseNameMaxLength,
			MinimumLength = CourseNameMinLength,
			ErrorMessage = LengthMessage)]
		public string Name { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
        [StringLength(CourseDescriptionMaxLength,
            MinimumLength = CourseDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityNameMaxLength,
            MinimumLength = CityNameMinLength,
            ErrorMessage = LengthMessage)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; } = null!;
        
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "End Date")]
        public string EndDate { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(CourseMinFrequency, CourseMaxFrequency, ErrorMessage = FrequencyMessage)]
        [Display(Name = "Times per week")]
        public int Frequency { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),CourseMinPrice, CourseMaxPrice, 
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PriceMessage)]
        [Display(Name = "Price of the course")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CourseCategoryServiceModel> Categories { get; set; }
        = new List<CourseCategoryServiceModel>();
    }
}
