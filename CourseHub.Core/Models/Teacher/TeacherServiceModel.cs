using System.ComponentModel.DataAnnotations;

namespace CourseHub.Core.Models.Teacher
{
	public class TeacherServiceModel
	{
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
