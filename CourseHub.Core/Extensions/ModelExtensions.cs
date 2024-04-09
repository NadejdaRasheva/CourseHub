using CourseHub.Core.Contracts;
using System.Text.RegularExpressions;

namespace CourseHub.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICourseModel course)
        {
            string info =  course.Name.Replace(" ", "-") + course.City;

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
