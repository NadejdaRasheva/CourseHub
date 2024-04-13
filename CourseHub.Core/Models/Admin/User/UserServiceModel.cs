using System.ComponentModel.DataAnnotations;

namespace CourseHub.Core.Models.Admin.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public bool IsTeacher { get; set; } 
    }
}
