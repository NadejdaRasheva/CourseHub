using System.Security.Claims;
using static CourseHub.Core.Constants.RoleConstants;

namespace CourseHub.Extensions
{
    public static class ClaimsPrinciplalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

		public static bool IsAdmin(this ClaimsPrincipal user)
		{
            return user.IsInRole(AdminRole);
		}
	}
}
