using CourseHub.Core.Contracts;
using CourseHub.Core.Services;

namespace CourseHub.Tests.UnitTests
{
	[TestFixture]
	public class TeacherServiceTests : UnitTestsBase
	{
		private ITeacherService _teacherService;

		[OneTimeSetUp]
		public void SetUp()
			=> _teacherService = new TeacherService(_data);

		[Test]
		public async Task GetTeacherIdAsync_ShouldReturnCorrectUserId()
		{
			var resultTeacherId = await _teacherService.GetTeacherIdAsync(Teacher.UserId);

			Assert.That(Convert.ToInt32(resultTeacherId), Is.EqualTo(Teacher.Id));
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidIdAsync()
		{
			var result = await _teacherService.ExistsByIdAsync(Teacher.UserId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task UserWithPhoneNumberExists_ShouldReturnTrue_WithValidData()
		{
			var result = await _teacherService.UserWithPhoneNumberExistsAsync(Teacher.PhoneNumber);
			Assert.IsTrue(result);
		}

		//[Test]
		//public async Task CreateAsync_ShouldWorkProperly()
		//{
		//	var teachersCountBefore = _data.Teachers.Count();
		//	await _teacherService.CreateAsync(Teacher.UserId, Teacher.PhoneNumber);

		//	var teachersCountAfter = _data.Teachers.Count();
		//	Assert.That(teachersCountAfter, Is.EqualTo(teachersCountBefore + 1)); ;
		//}
	}
}
