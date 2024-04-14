using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using CourseHub.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Tests.UnitTests
{
	public class UnitTestsBase
	{
		protected CourseHubDbContext _data;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			_data = DatabaseMock.Instance;
			SeedDatabase();
		}

		public ApplicationUser Student { get; private set; }
		public Teacher Teacher { get; private set; }
		public Course Course { get; private set; }

		private void SeedDatabase()
		{
			Student = new ApplicationUser()
			{
				Id = "StudentUserId",
				Email = "student@mail.bg",
				FirstName = "Student",
				LastName = "User"
			};
			_data.Users.Add(Student);

			Teacher = new Teacher()
			{
				PhoneNumber = "+359111111111",
				User = new ApplicationUser()
				{
					Id = "TeacherUserId",
					Email = "teacher@test.bg",
					FirstName = "Teacher",
					LastName = "User"
				}
			};
			_data.Teachers.Add(Teacher);

			Course = new Course()
			{
				Name = "First Test Course",
				Description = "Some test description for the first test course",
				City = "Test City",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Price = 1000,
				Frequency = 3,
				Teacher = Teacher,
				Category = new Category() { Name = "Academic Subjects" }
			};
			_data.Courses.Add(Course);

			var secondCourse = new Course()
			{
				Name = "Second Test Course",
				Description = "Some test description for the second test course",
				City = "Test City",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Price = 2000,
				Frequency = 2,
				Teacher = Teacher,
				Category = new Category() { Name = "Personal Development" }
			};
			_data.Courses.Add(secondCourse);
			_data.SaveChanges();
		}

		[OneTimeTearDown]
		public void TearDownBase()
			=> _data.Dispose();
	}
}
