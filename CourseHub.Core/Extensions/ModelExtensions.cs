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

        public static string GetStudentInfromation(this IStudentModel student)
        {
            string info = student.StudentId;
            info = Regex.Replace(info, @"[a-z0-9-]", string.Empty);
            info = info + $"{student.StudentName.Replace(" ", "-")}";
            return info;
		}
    }
}
