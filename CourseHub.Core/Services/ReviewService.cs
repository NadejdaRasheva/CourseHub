using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Review;
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
	public class ReviewService : IReviewService
	{
		private readonly CourseHubDbContext _data;

		public ReviewService(CourseHubDbContext data)
		{
			_data = data;
		}

		public async Task<IEnumerable<ReviewAllViewModel>> GetForCourseAsync(int id)
		{
			var reviews = await _data
				.Reviews
				.Where(r => r.CourseId == id)
				.Select(r => new ReviewAllViewModel()
				{
					Id = r.Id,
					Rating = r.Rating,
					Comment = r.Comment,
					CourseId = r.CourseId,
					ReviewerId = r.ReviewerId,
					Username = $"{r.Reviewer.FirstName} {r.Reviewer.LastName}"
				}).ToListAsync();

			return reviews;
		}

		public async Task CreateAsync(ReviewFormViewModel model, string reviewerId)
		{
			var review = new Review()
			{
				Rating = model.Rating,
				Comment = model.Comment,
				CourseId = model.CourseId,
				ReviewerId = reviewerId
			};

			await _data.AddAsync(review);
			await _data.SaveChangesAsync();
		}

		public async Task<bool> ReviewExistsAsync(int reviewId)
		{
			return await _data.Reviews.AnyAsync(r => r.Id == reviewId);
		}

		public async Task<bool> HasReviewerWithIdAsync(int reviewId, string reviewerId)
		{
			return await _data.Reviews.AnyAsync(r => r.Id == reviewId && r.ReviewerId == reviewerId);
		}

		public async Task RemoveReviewAsync(int reviewId)
		{
			var review = await _data.Reviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();

			if (review != null)
			{
				_data.Remove(review);
				await _data.SaveChangesAsync();
			}
		}

		public async Task<int> GetReviewCourseIdAsync(int reviewId)
		{
			var review = await _data.Reviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();

			return review.CourseId;
		}

		public async Task<ReviewFormViewModel> CreateReviewFormViewModelByIdAsync(int id)
		{
			return await _data.Reviews.Where(r => r.Id == id).Select(r => new ReviewFormViewModel()
			{
				Rating = r.Rating,
				Comment = r.Comment,
				CourseId = r.CourseId
			}).FirstAsync();
		}

		public async Task EditAsync(int id, ReviewFormViewModel model)
		{
			var reviewToEdit = await _data.Reviews.Where(r => r.Id == id).FirstOrDefaultAsync();

			if (reviewToEdit != null)
			{
				reviewToEdit.Rating = model.Rating;
				reviewToEdit.Comment = model.Comment;

				await _data.SaveChangesAsync();
			}
		}
	}
}
