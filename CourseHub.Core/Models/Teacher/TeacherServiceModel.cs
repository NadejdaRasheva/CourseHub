using System.ComponentModel.DataAnnotations;

namespace CourseHub.Core.Models.Teacher
{
	public class TeacherServiceModel
	{
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
