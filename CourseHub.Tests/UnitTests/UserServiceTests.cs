using CourseHub.Core.Contracts;
using CourseHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Tests.UnitTests
{
	public class UserServiceTests : UnitTestsBase
	{
		private IUserService _userService;

		[OneTimeSetUp]
		public void SetUp()
			=> _userService = new UserService(_data);

		[Test]
		public async Task UserFullNameAsync_ShouldReturnCorrectResult()
		{
			var result = await _userService.UserFullNameAsync(Student.Id);

			var studentFullName = Student.FirstName + " " + Student.LastName;
			Assert.That(result, Is.EqualTo(studentFullName));
		}

		[Test]
		public async Task AllAsync_ShouldReturnCorrectUsersAndTeachers()
		{
			var result = await _userService.AllAsync();

			var usersCount = _data.Users.Count();
			var resultUsers = result.ToList();
			Assert.That(resultUsers.Count(), Is.EqualTo(usersCount));

			var teachersCount = _data.Teachers.Count();
			var resultTeachers = resultUsers.Where(us => us.PhoneNumber != null);
			Assert.That(resultTeachers.Count(), Is.EqualTo(teachersCount));

			var teacherUser = resultTeachers
				.FirstOrDefault(t => t.Email == Teacher.User.Email);
			Assert.IsNotNull(teacherUser);
			Assert.That(teacherUser.PhoneNumber, Is.EqualTo(Teacher.PhoneNumber));
		}
	}
}
