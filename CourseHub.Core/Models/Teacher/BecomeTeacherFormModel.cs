using System.ComponentModel.DataAnnotations;
using static CourseHub.Core.Constants.MessageConstants;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Models.Teacher
{
	public class BecomeTeacherFormModel
	{
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TeacherPhoneNumberMaxLength,
            MinimumLength = TeacherPhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
