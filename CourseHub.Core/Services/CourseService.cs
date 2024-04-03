using CourseHub.Core.Contracts;
using CourseHub.Core.Enumerations;
using CourseHub.Core.Models.Course;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CourseHub.Core.Services
{
	public class CourseService : ICourseService
    {
        private readonly CourseHubDbContext _data;

        public CourseService(CourseHubDbContext data)
        {
            _data = data;
        }

		public async Task<CourseQueryServiceModel> AllAsync(string? category = null, 
            string? searchTerm = null,
            CourseSorting sorting = CourseSorting.Newest, 
            CourseFiltering filterng = CourseFiltering.All,
            int currentPage = 1, 
            int coursesPerPage = 1)
		{
            var coursesShowing = _data.Courses.AsQueryable();

            if(!string.IsNullOrEmpty(category) )
            {
                coursesShowing = _data
                    .Courses
                    .Where(c => c.Category.Name == category);
            }

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                coursesShowing = coursesShowing
                    .Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    c.City.ToLower().Contains(searchTerm.ToLower()));
            }

            coursesShowing = filterng switch
            {
                CourseFiltering.Started => coursesShowing =
                coursesShowing.Where(c => c.StartDate < DateTime.Now),
                CourseFiltering.Future => coursesShowing =
                coursesShowing.Where(c => c.StartDate > DateTime.Now),
                CourseFiltering.Ended => coursesShowing =
                coursesShowing.Where(c => c.EndDate < DateTime.Now),
                _ => coursesShowing
            };

            coursesShowing = sorting switch
            {
                CourseSorting.Oldest => coursesShowing
                .OrderBy(c => c.Id),
                CourseSorting.Price => coursesShowing
                .OrderBy(c => c.Price),
                _ => coursesShowing
                .OrderByDescending(c => c.Id)
            };

            var courses = await coursesShowing
                .Skip((currentPage - 1) * coursesPerPage)
                .Take(coursesPerPage)
                .Select(c => new CourseServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Frequency = c.Frequency,
                    Price = c.Price
                })
                .ToListAsync();

            int totalCourses = await coursesShowing.CountAsync();

            return new CourseQueryServiceModel()
            {
                TotalCoursesCount = totalCourses,
                Courses = courses
            };
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

		public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
		{
            return await _data.Categories
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseServiceModel>> AllCoursesByTeacherIdAsync(int teacherId)
        {
            var courses = await _data
                .Courses
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

            return ProjectToModel(courses);
        }

        private List<CourseServiceModel> ProjectToModel(List<Course> courses)
        {
            var resultCourses = courses
                .Select(c => new CourseServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Frequency = c.Frequency,
                    Price = c.Price
                })
                .ToList();

            return resultCourses;
        }

        public async Task<IEnumerable<CourseServiceModel>> AllCoursesByUserIdAsync(string userId)
        {
            var courses = await _data
                .Courses
                .Where(c => c.CourseParticipants.Any(cp => cp.ParticipantId == userId))
                .ToListAsync();
          
            return ProjectToModel(courses);
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
