using CourseHub.Core.Contracts;
using CourseHub.Core.Services;
using CourseHub.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Tests.UnitTests
{
	[TestFixture]
	public class CourseServiceTests : UnitTestsBase
	{
		private IUserService userService;
		private ICourseService courseService;

		[OneTimeSetUp]
		public void SetUp()
		{
			userService = new UserService(_data);
			courseService = new CourseService(_data);
		}

		[Test]
		public async Task AllCategoriesAsync_ShouldReturnCorrectCourses()
		{
			var result = await courseService.AllCategoriesAsync();

			var dbCategories = _data.Categories;
			Assert.That(result.Count(), Is.EqualTo(dbCategories.Count()));

			var categoryNames = dbCategories.Select(c => c.Name);
			Assert.That(categoryNames.Contains(result.FirstOrDefault().Name));
		}

		[Test]
		public async Task AllCoursesByTeacherIdAsync_ShouldReturnCorrectCourses()
		{
			var teacherId = Teacher.Id;

			var result = await courseService.AllCoursesByTeacherIdAsync(teacherId);

			Assert.IsNotNull(result);

			var coursesInDb = _data.Courses
				.Where(c => c.TeacherId == teacherId);

			Assert.That(result.Count(), Is.EqualTo(coursesInDb.Count()));
		}

		[Test]
		public async Task AllCoursesByUserIdAsync_ShouldReturnCorrectCourses()
		{
			var studentId = Student.Id;

			var result = await courseService.AllCoursesByUserIdAsync(studentId);
			Assert.IsNotNull(result);

			var coursesInDb = _data.Courses
				.Where(c => c.CourseParticipants.Any(cp => cp.ParticipantId == studentId))
				.ToList();

			Assert.That(result.Count(), Is.EqualTo(coursesInDb.Count()));
		}

		[Test]
		public async Task ExistsAsync_ShouldReturnCorrectTrue_WithValidId()
		{
			var courseId = Course.Id;

			var result = await courseService.ExistsAsync(courseId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CourseDetailsByIdAsync_ShouldReturnCorrectCourseData()
		{
			var courseId = Course.Id;

			var result = await courseService.CourseDetailsByIdAsync(courseId);

			Assert.IsNotNull(result);

			var courseInDb = _data.Courses.Find(courseId);
			Assert.That(result.Id, Is.EqualTo(courseInDb.Id));
			Assert.That(result.Name, Is.EqualTo(courseInDb.Name));
		}

		[Test]
		public async Task CreateAsync_ShouldCreateCourse()
		{
			var coursesInDbBefore = _data.Courses.Count();

			var newCourse = new Course()
			{
				Name = "New Course",
				Description = "New course description. Some description",
				City = "Stara Zagora",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Frequency = 2,
				Price = 2550
			};

			var newCourseId = await courseService.CreateAsync(newCourse.Name,
				newCourse.Description, newCourse.City, 
				newCourse.StartDate, newCourse.EndDate, 
				newCourse.Frequency, newCourse.Price, 1, Teacher.Id);

			var coursesInDbAfter = _data.Courses.Count();
			Assert.That(coursesInDbAfter, Is.EqualTo(coursesInDbBefore + 1));

			var newCourseInDb = _data.Courses.Find(newCourseId);
			Assert.That(newCourseInDb.Name, Is.EqualTo(newCourse.Name));
		}

		[Test]
		public async Task HasTeacherWithIdAsync_ShouldReturnTrue_WithValidId()
		{
			var courseId = Course.Id;
			var userId = Course.Teacher.User.Id;

			var result = await courseService.HasTeacherWithIdAsync(courseId, userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task EditAsync_ShouldEditCourseCorrectly()
		{
			var course = new Course()
			{
				Name = "Course Edit",
				Description = "This course should be edited",
				City = "Sofia",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Frequency = 5,
				Price = 1550,
				CategoryId = 2,
				TeacherId = Teacher.Id
			};

			await _data.Courses.AddAsync(course);
			await _data.SaveChangesAsync();

			var changedCity = "Plovdiv";

			await courseService.EditAsync(course.Id, course.Name, course.Description,
				changedCity, course.StartDate, course.EndDate,
				course.Frequency, course.Price, course.CategoryId);

			var newCourseInDb = await _data.Courses.FindAsync(course.Id);
			Assert.IsNotNull(newCourseInDb);
			Assert.That(newCourseInDb.Name, Is.EqualTo(course.Name));
			Assert.That(newCourseInDb.City, Is.EqualTo(changedCity));
		}


		[Test]
		public async Task DeleteAsync_ShouldDeleteCourseSuccessfully()
		{
			var course = new Course()
			{
				Name = "Course to delete",
				Description = "This course should be deleted",
				City = "Sofia",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Frequency = 3,
				Price = 1500,
				CategoryId = 4,
				TeacherId = Teacher.Id
			};

			await _data.Courses.AddAsync(course);
			await _data.SaveChangesAsync();

			var coursesCountBefore = _data.Courses.Count();

			await courseService.DeleteAsync(course.Id);

			var coursesCountAfter = _data.Courses.Count();
			Assert.That(coursesCountAfter, Is.EqualTo(coursesCountBefore - 1));

			var courseInDb = await _data.Courses.FindAsync(course.Id);
			Assert.IsNull(courseInDb);
		}

		[Test]
		public async Task JoinAsync_ShouldJoinCourseSuccessfully()
		{
			var course = new Course()
			{
				Name = "Course to join",
				Description = "This is a course to join",
				City = "Haskovo",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Frequency = 1,
				Price = 1000,
				CategoryId = 3,
				TeacherId = Teacher.Id
			};

			await _data.Courses.AddAsync(course);
			await _data.SaveChangesAsync();

			var studentId = Student.Id;

			var participantsCountBefore = _data.CoursesParticipants
				.Where(c => c.CourseId == course.Id).Count();

			await courseService.JoinAsync(course.Id, studentId);

			var newCourseInDb = _data.Courses.Find(course.Id);
			var newCourseParticipant = newCourseInDb.CourseParticipants
				.FirstOrDefault(c => c.ParticipantId == Student.Id);

			var participantsCountAfter = _data.CoursesParticipants
				.Where(c => c.CourseId == course.Id).Count();

			Assert.IsNotNull(newCourseInDb);
			Assert.That(participantsCountAfter, Is.EqualTo(participantsCountBefore + 1));
			Assert.IsNotNull(newCourseParticipant);
		}

		[Test]
		public async Task Leave_ShouldLeaveCourseSuccessfully()
		{
			var course = new Course()
			{
				Name = "Course to leave",
				Description = "This is a course to leave",
				City = "Haskovo",
				StartDate = DateTime.Today,
				EndDate = DateTime.Today,
				Frequency = 2,
				Price = 2900,
				CategoryId = 4,
				TeacherId = Teacher.Id
			};

			await _data.Courses.AddAsync(course);
			await _data.SaveChangesAsync();

			await courseService.JoinAsync(course.Id, Student.Id);
			var participantsCountBefore = _data.CoursesParticipants
				.Where(c => c.CourseId == course.Id).Count();

			var newCourseInDb = _data.Courses.Find(course.Id);
			var newCourseParticipant = newCourseInDb.CourseParticipants
				.FirstOrDefault(c => c.ParticipantId == Student.Id);

			await courseService.LeaveAsync(course.Id, Student.Id);
			var leftCourseParticipant = newCourseInDb.CourseParticipants
				.FirstOrDefault(c => c.ParticipantId == Student.Id);

			var participantsCountAfter = _data.CoursesParticipants
				.Where(c => c.CourseId == course.Id).Count();

			Assert.IsNotNull(newCourseInDb);
			Assert.That(participantsCountAfter, Is.EqualTo(participantsCountBefore - 1));
			Assert.IsNull(leftCourseParticipant);
		}

		[Test]
		public async Task StudentHasJoinedAsync_ShouldReturnCorrectValue()
		{
			var course = new Course()
			{
				Name = "New Course",
				Description = "New course description. Some description",
				City = "Stara Zagora",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Frequency = 2,
				Price = 2550,
				CategoryId = 4,
				TeacherId = Teacher.Id
			};

			await _data.Courses.AddAsync(course);
			await _data.SaveChangesAsync();

			var newCourseInDb = _data.Courses.Find(course.Id);
			Assert.IsNotNull(newCourseInDb);

			var hasJoined = await courseService.StudentHasJoinedAsync(course.Id, Student.Id);
			Assert.IsFalse(hasJoined);

			await courseService.JoinAsync(course.Id, Student.Id);
			hasJoined = await courseService.StudentHasJoinedAsync(course.Id, Student.Id);
			Assert.IsTrue(hasJoined);
		}
	}
}
