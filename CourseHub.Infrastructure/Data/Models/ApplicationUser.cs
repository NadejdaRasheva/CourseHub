using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Infrastructure.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[PersonalData]
		[MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
		
		[Required]
		[PersonalData]
		[MaxLength(UserLastNameMaxLength)]
		public string LastName { get; set; } = string.Empty;
    }
}
