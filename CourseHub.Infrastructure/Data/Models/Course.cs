using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
    [Comment("Course")]
    public class Course
    {
        [Key]
        [Comment("Course identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CourseNameMaxLength)]
        [Comment("Course name")]
        public string Name { get; set; }  = string.Empty;

        [Required]
        [MaxLength(CourseDescriptionMaxLength)]
        [Comment("Course description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("City address")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Comment("Course start date")]
        public DateTime StartDate { get; set;}

        [Required]
        [Comment("Course end date")]
        public DateTime EndDate { get; set;}

        [Required]
        [Comment("Course frequency")]
        [Range(1, 7)]
        public int Frequency { get; set;}

        [Required]
        //[Range(typeof(decimal), CourseMinPrice, CourseMaxPrice, ConvertValueInInvariantCulture = true)]
        [Comment("Course price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))] 
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Teacher identifier")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; } = null!;
    }
}
