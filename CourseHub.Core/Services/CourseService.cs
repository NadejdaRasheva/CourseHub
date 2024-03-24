using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Course;
using CourseHub.Infrastructure.Data.Constants;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CourseHub.Infrastructure.Data.Constants.DataConstants;

namespace CourseHub.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseHubDbContext _data;

        public CourseService(CourseHubDbContext data)
        {
            _data = data;
        }
        public async Task<IEnumerable<CourseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await _data
                .Categories
                .Select(c => new CourseCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _data.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(string name, string description, 
            DateTime startDate, DateTime endDate, int frequency, 
            decimal price, int categoryId, int teacherId)
        {

            var course = new CourseHub.Infrastructure.Data.Models.Course()
            {
                Name = name,
                Description = description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Frequency = frequency,
                Price = price,
                CategoryId = categoryId,
                TeacherId = teacherId
            };

            await _data.Courses.AddAsync(course);
            await _data.SaveChangesAsync();

            return course.Id;
        }
    }
}
