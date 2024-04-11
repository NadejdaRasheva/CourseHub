using CourseHub.Core.Contracts;
using CourseHub.Core.Enumerations;
using CourseHub.Core.Models.Course;
using CourseHub.Core.Models.Teacher;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
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
            string city, DateTime startDate, DateTime endDate, int frequency, 
            decimal price, int categoryId, int teacherId)
        {

            var course = new CourseHub.Infrastructure.Data.Models.Course()
            {
                Name = name,
                Description = description,
                City = city,
                StartDate = startDate,
                EndDate = endDate,
                Frequency = frequency,
                Price = price,
                CategoryId = categoryId,
                TeacherId = teacherId
            };

            await _data.Courses.AddAsync(course);
            await _data.SaveChangesAsync();

            return course.Id;
        }

		public async Task<bool> ExistsAsync(int id)
		{
			return await _data
                .Courses
                .AnyAsync(c => c.Id == id);
		}

		public async Task<CourseDetailsServiceModel> CourseDetailsByIdAsync(int id)
		{
            return await _data
                .Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseDetailsServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    City = c.City,
                    StartDate = c.StartDate.Date.ToShortDateString(),
                    EndDate = c.EndDate.Date.ToShortDateString(),
                    Frequency = c.Frequency,
                    Price = c.Price,
                    Category = c.Category.Name,
                    Teacher = new TeacherServiceModel()
                    {
                        FullName = $"{c.Teacher.User.FirstName} {c.Teacher.User.LastName}",
                        PhoneNumber = c.Teacher.PhoneNumber,
                        Email = c.Teacher.User.Email
                    }
                })
                .FirstAsync();
		}

		public async Task EditAsync(int courseId, string name, string description, string city, DateTime startDate, DateTime endDate, int frequency, decimal price, int categoryId)
		{
            var course = _data.Courses.Find(courseId);

            course.Name = name;
            course.Description = description;
            course.City = city;
            course.StartDate = startDate;
            course.EndDate = endDate;
            course.Frequency = frequency;
            course.Price = price;
            course.CategoryId = categoryId;

            await _data.SaveChangesAsync();
		}

		public async Task<bool> HasTeacherWithIdAsync(int courseId, string currentUserId)
		{
			var course = await _data.Courses.FindAsync(courseId);
            var teacher = await _data.Teachers.FirstOrDefaultAsync(t => t.Id == course.TeacherId);

            if(teacher == null)
            {
                return false;
            }

            if(teacher.UserId !=  currentUserId)
            {
                return false;
            }

            return true;
		}

		public async Task<CourseFormModel?> GetCourseFormByIdAsync(int id)
		{
            var course = await _data.Courses.Where(c => c.Id == id)
                .Select(c => new CourseFormModel()
                {
                    Name = c.Name,
                    Description = c.Description,
                    City = c.City,
                    StartDate = c.StartDate.ToString(DateFormat),
                    EndDate = c.EndDate.ToString(DateFormat),
                    Frequency = c.Frequency,
                    Price = c.Price,
                    CategoryId = c.CategoryId
                })
                .FirstOrDefaultAsync();

            if(course != null)
            {
                course.Categories = await AllCategoriesAsync();
            }

            return course;
		}

		public async Task DeleteAsync(int courseId)
		{
			var course = await _data.Courses.FindAsync(courseId);
            var participants = await _data.CoursesParticipants.Where(c => c.CourseId == courseId).ToListAsync();

            foreach (var pid in participants)
            {
                _data.CoursesParticipants.Remove(pid);
            }

            if (course != null)
            {
				_data.Remove(course);
			}
            await _data.SaveChangesAsync();
		}

        public async Task JoinAsync(int courseId, string userId)
        {
            var course = await _data.Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.CourseParticipants)
                .FirstAsync();

            var cp = course.CourseParticipants
                .FirstOrDefault(cp => cp.ParticipantId == userId);

            if (course != null)
            {
                if (cp == null)
                {
                    course.CourseParticipants.Add(new CourseParticipant()
                    {
                        CourseId = courseId,
                        ParticipantId = userId
                    });

                    await _data.SaveChangesAsync();
                }
            }
        }

        public async Task LeaveAsync(int courseId, string participantId)
        {
            var course = await _data.Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.CourseParticipants)
                .FirstAsync();

            var cp = course.CourseParticipants
                .FirstOrDefault(cp => cp.ParticipantId == participantId);

            course.CourseParticipants.Remove(cp);

            await _data.SaveChangesAsync();

        }

        public async Task<bool> StudentHasJoinedAsync(int courseId, string userId)
        {
            var course = await _data.Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.CourseParticipants)
                .FirstAsync();

            var cp = course.CourseParticipants
                .FirstOrDefault(cp => cp.ParticipantId == userId);

            return cp != null ? true : false;
        }
    }
}
