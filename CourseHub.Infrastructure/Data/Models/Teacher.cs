using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Course teacher")]
    public class Teacher
    {
        [Key]
        [Comment("Teacher Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TeacherPhoneNumberMaxLength)]
        [Comment("Teacher's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

    }
}
