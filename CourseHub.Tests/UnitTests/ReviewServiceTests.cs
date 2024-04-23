using CourseHub.Core.Contracts;
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
	public class ReviewServiceTests : UnitTestsBase
	{
		private  IReviewService _reviewService;
		private  List<Review> _reviews;

		[OneTimeSetUp]
		public void SetUp()
		{
			_reviewService = new ReviewService(_data);
			_reviews = new List<Review>()
			{
				new Review()
				{
					Id = 1,
					Rating = 5,
					Comment = "Very useful course!",
					Course = Course,
					CourseId = Course.Id,
					Reviewer = Student,
					ReviewerId = Student.Id,
				}
			};
				
		}

		[Test]
		public async Task GetForCourseAsync_ShouldReturnValidReviews()
		{
			var result = await _reviewService.GetForCourseAsync(Course.Id);

			Assert.IsNotNull(result);
			Assert.That(result.Any(r => r.Id == 1));
			Assert.That(result.Any(r => r.Rating == 5));
			Assert.That(result.Any(r => r.Comment == "Very useful course!"));
		}


		[Test]
		public async Task CreateAsync_ShouldAddCorrectReview()
		{
			var reviewsInDbBefore = _data.Reviews.Count();
			var reviewModel = new ReviewFormViewModel()
			{
				CourseId = 1,
				Comment = "Very nice and fun course!",
				Rating = 5
			};

			var reviewerId = "572f859b-0afa-4112-aa5b-23a6d9560fca";

			await _reviewService.CreateAsync(reviewModel, reviewerId);

			var reviewsnDbAfter = _data.Reviews.Count();

			Assert.That(reviewsnDbAfter, Is.EqualTo(reviewsInDbBefore + 1));
		}

		[Test]
		public async Task ReviewExistsAsync_ReturnRightValueWithValidData()
		{
			var result = await _reviewService.ReviewExistsAsync(1);
			Assert.That(result, Is.True);

			var falseResult = await _reviewService.ReviewExistsAsync(4);
			Assert.That(falseResult, Is.False);
		}

		[Test]
		public async Task HasReviewerWithIdAsync_ShouldReturnTrue()
		{
			var result = await _reviewService.HasReviewerWithIdAsync(1, "StudentUserId");

			Assert.True(result);

			var falseResult = await _reviewService.HasReviewerWithIdAsync(2, "7a7e1653-d57f-4f41-97cb-e4bd92592fdc");

			Assert.False(falseResult);
		}

		[Test]
		public async Task RemoveReviewAsync_ShouldRemoveCorrectReview()
		{
			var review = new Review()
			{
				Id = 2,
				Rating = 5,
				Comment = "Amazing course.",
				ReviewerId = Student.Id,
				CourseId = Course.Id
			};

			await _data.Reviews.AddAsync(review);
			await _data.SaveChangesAsync();

			var reviewsCountBefore = _data.Reviews.Count();

			await _reviewService.RemoveReviewAsync(review.Id);

			var coursesCountAfter = _data.Reviews.Count();
			Assert.That(coursesCountAfter, Is.EqualTo(reviewsCountBefore - 1));

			var courseInDb = await _data.Reviews.FindAsync(review.Id);
			Assert.IsNull(courseInDb);
		}

		[Test]
		public async Task GetReviewCourseIdAsync_ShouldReturnCorrectCarId()
		{
			var result = await _reviewService.GetReviewCourseIdAsync(1);

			Assert.That(result, Is.EqualTo(Course.Id));
		}


		[Test]
		public async Task CreateReviewFormViewModelByIdAsync_ShouldReturnCorrectModel()
		{
			var reviewModel = await _reviewService.CreateReviewFormViewModelByIdAsync(1);

			var review = _reviews.FirstOrDefault(r => r.Id == 1);

			Assert.IsNotNull(reviewModel);
			Assert.That(reviewModel.Rating, Is.EqualTo(review.Rating));
			Assert.That(reviewModel.Comment, Is.EqualTo(review.Comment));
			Assert.That(reviewModel.CourseId, Is.EqualTo(review.CourseId));
		}

		[Test]
		public async Task EditAsync_ShouldEditCorrectReview()
		{
			var review = new Review()
			{
				Rating = 5,
				Comment = "Very useful course!",
				Course = Course,
				CourseId = Course.Id,
				Reviewer = Student,
				ReviewerId = Student.Id,
			};
			await _data.Reviews.AddAsync(review);
			await _data.SaveChangesAsync();

			var reviewModel = new ReviewFormViewModel()
			{
				Rating = 3,
				Comment = "Quite good course",
				CourseId = Course.Id
			};


			await _reviewService.EditAsync(review.Id, reviewModel);

			var editedReview = _data.Reviews.Find(review.Id);

			Assert.That(reviewModel.Rating, Is.EqualTo(editedReview.Rating));
			Assert.That(reviewModel.Comment, Is.EqualTo(editedReview.Comment));
			Assert.That(reviewModel.CourseId, Is.EqualTo(editedReview.CourseId));
		}
	}
}
