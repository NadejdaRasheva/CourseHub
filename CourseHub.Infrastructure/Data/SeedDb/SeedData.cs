using CourseHub.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser TeacherUser { get; set; }
        public IdentityUser StudentUser { get; set; }
        public Teacher Teacher { get; set; }
        public Category AcademicCategory { get; set; }
        public Category CreativeCategory { get; set; }
        public Category PracticalCategory { get; set; }
        public Category PersonalCategory { get; set; }
        public Category SportCategory { get; set; }
        public Category HobbiesCategory { get; set; }
        public Course MathCourse { get; set; }
        public Course GuitarCourse { get; set; }
        public Course CarCourse { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedTeacher();
            SeedCategories();
            SeedCourses();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            TeacherUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };
            TeacherUser.PasswordHash = hasher.HashPassword(TeacherUser, "teacher123teacher");
            StudentUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "student@mail.com",
                NormalizedUserName = "student@mail.com",
                Email = "student@mail.com",
                NormalizedEmail = "student@mail.com"
            };
            StudentUser.PasswordHash = hasher.HashPassword(StudentUser, "student123student");
        }

        private void SeedTeacher()
        {
            Teacher = new Teacher()
            {
                Id = 1,
                PhoneNumber = "+359876543210",
                UserId = TeacherUser.Id
            };
        }

        private void SeedCategories()
        {
            AcademicCategory = new Category()
            {
                Id = 1,
                Name = "Academic Subjects"
            };

            CreativeCategory = new Category()
            {
                Id = 2,
                Name = "Creative Arts and Performance"
            };

            PracticalCategory = new Category()
            {
                Id = 3,
                Name = "Practical Skills and Trades"
            };

            PersonalCategory = new Category()
            {
                Id = 4,
                Name = "Personal Development"
            };

            SportCategory = new Category()
            {
                Id = 5,
                Name = "Sports and Fitness"
            };

            HobbiesCategory = new Category()
            {
                Id = 6,
                Name = "Special Interests and Hobbies"
            };
        }

        private void SeedCourses()
        {
            MathCourse = new Course()
            {
                Id = 1,
                Name = "Math",
                Description = "Math lessons for all classes",
                City = "Sofia",
                StartDate = new DateTime(2024, 03, 30),
                EndDate = new DateTime(2024, 05, 30),
                Frequency = 2,
                Price = 350,
                CategoryId = AcademicCategory.Id,
                TeacherId = Teacher.Id
            };

            GuitarCourse = new Course()
            {
                Id = 2,
                Name = "Guitar",
                Description = "Guitar lessons for children",
                City = "Plovdiv",
                StartDate = new DateTime(2024, 04, 20),
                EndDate = new DateTime(2024, 05, 20),
                Frequency = 1,
                Price = 500,
                CategoryId = CreativeCategory.Id,
                TeacherId = Teacher.Id
            };

            CarCourse = new Course()
            {
                Id = 3,
                Name = "Engines",
                Description = "Autos lectures for teenagers",
                City = "Stara Zagora",
                StartDate = new DateTime(2024, 04, 01),
                EndDate = new DateTime(2024, 07, 30),
                Frequency = 1,
                Price = 700,
                CategoryId = PracticalCategory.Id,
                TeacherId = Teacher.Id
            };
        }
    }
}
