using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Result;
using CourseHub.Core.Models.Review;
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
	public class ResultServiceTests : UnitTestsBase
	{
		private IResultService _resultService;

		[OneTimeSetUp]
		public void SetUp()
			=> _resultService = new ResultService(_data);

		[Test]
		public async Task CreateAsync_ShouldCreateNewResult()
		{
			var resultsInDbBefore = _data.Results.Count();

			var resultModel = new ResultFormViewModel()
			{
				CourseId = 1,
				Feedback = "Well done!",
				Grade = 5
			};

			
			await _resultService.CreateAsync(resultModel);

			var resultsInDbAfter = _data.Results.Count();

			Assert.That(resultsInDbAfter, Is.EqualTo(resultsInDbBefore + 1));
		}

		[Test]
		public async Task CreateResultFormViewModelByIdAsync_ShouldReturnCorrectModel()
		{
			var resultModel = await _resultService.CreateResultFormViewModelByIdAsync(1);

			var result = Result;

			Assert.IsNotNull(resultModel);
			Assert.That(resultModel.Grade, Is.EqualTo(result.Grade));
			Assert.That(resultModel.Feedback, Is.EqualTo(result.Feedback));
			Assert.That(resultModel.CourseId, Is.EqualTo(result.CourseId));
		}

		[Test]
		public async Task EditAsync_ShouldEditCorrectResult()
		{

			var resultModel = new ResultFormViewModel()
			{
				Grade = 3,
				Feedback = "Poor participation",
				CourseId = Course.Id
			};


			await _resultService.EditAsync(Result.Id, resultModel);

			var editedResult = _data.Results.Find(Review.Id);

			Assert.That(resultModel.Grade, Is.EqualTo(editedResult.Grade));
			Assert.That(resultModel.Feedback, Is.EqualTo(editedResult.Feedback));
			Assert.That(resultModel.CourseId, Is.EqualTo(editedResult.CourseId));
		}

		[Test]
		public async Task GetReviewCourseIdAsync_ShouldReturnCorrectCarId()
		{
			var result = await _resultService.GetResultCourseIdAsync(Result.Id);

			Assert.That(result, Is.EqualTo(Course.Id));
		}

		[Test]
		public async Task HasTeacherWithIdAsync_ShouldReturnTrue()
		{
			var result = await _resultService.HasTeacherWithIdAsync(Result.Id, "TeacherUserId");

			Assert.True(result);

			var falseResult = await _resultService.HasTeacherWithIdAsync(2, "7a7e1653-d57f-4f41-97cb-e4bd92592fdc");

			Assert.False(falseResult);
		}

		[Test]
		public async Task ResultExistsAsync_ReturnRightValueWithValidData()
		{
			var result = await _resultService.ResultExistsAsync(Result.Id);
			Assert.That(result, Is.True);

			var falseResult = await _resultService.ResultExistsAsync(4);
			Assert.That(falseResult, Is.False);
		}

		[Test]
		public async Task GetStudentResult_ShouldReturnValidResult()
		{
			var view = new ResultViewModel()
			{
				CourseId = Course.Id,
				StudentId = Student.Id,
				Grade = Result.Grade,
				Feedback = Result.Feedback,
				CourseName = Course.Name
			};

			var resultView = await _resultService.GetStudentResult(Course.Id, Student.Id);

			Assert.IsNotNull(resultView);
			Assert.That(resultView.Grade, Is.EqualTo(view.Grade));
			Assert.That(resultView.Feedback, Is.EqualTo(view.Feedback));
			Assert.That(resultView.CourseName, Is.EqualTo(view.CourseName));
		}
	}
}
