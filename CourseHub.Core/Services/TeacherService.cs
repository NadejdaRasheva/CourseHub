using CourseHub.Core.Contracts;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _data.Teachers.AllAsync(t => t.PhoneNumber == phoneNumber);
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
    }
}
