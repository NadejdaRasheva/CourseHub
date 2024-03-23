using System.Security.Claims;

namespace CourseHub.Extensions
{
    public static class ClaimsPrinciplalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
