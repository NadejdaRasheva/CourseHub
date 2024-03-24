using CourseHub.Core.Models.Course;

namespace CourseHub.Core.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(string name, string description,
            DateTime startDate, DateTime endDate, int frequency,
            decimal price, int categoryId, int teacherId);

    }
}
