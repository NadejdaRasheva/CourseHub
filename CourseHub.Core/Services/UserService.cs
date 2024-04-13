using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Admin.User;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Core.Services
{
    public class UserService : IUserService
    {
        private readonly CourseHubDbContext _data;

        public UserService(CourseHubDbContext data)
        {
            _data = data;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await _data.Users
                .Include(u => u.Teacher)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Teacher.PhoneNumber,
                    IsTeacher = u.Teacher != null
                }).ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;

            var user = await _data.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if(user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
