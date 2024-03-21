using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
    [Comment("Course category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
