using CourseHub.Core.Contracts;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly CourseHubDbContext _data;

        public TeacherService(CourseHubDbContext data)
        {
            _data = data;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await _data.Teachers.AnyAsync(t => t.UserId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await _data.Teachers.AnyAsync(t => t.PhoneNumber == phoneNumber);
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
			var teacher = new Teacher()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };
            await _data.Teachers.AddAsync(teacher);
			await _data.SaveChangesAsync();
        }

        public async Task<int?> GetTeacherIdAsync(string userId)
        {
            return (await _data.Teachers.FirstOrDefaultAsync(t => t.UserId == userId))?.Id;
        }
    }
}
