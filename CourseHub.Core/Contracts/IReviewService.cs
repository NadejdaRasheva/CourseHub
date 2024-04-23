using CourseHub.Core.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Contracts
{
	public interface IReviewService
	{
		Task<IEnumerable<ReviewAllViewModel>> GetForCourseAsync(int id);

		Task CreateAsync(ReviewFormViewModel model, string reviewerId);

		Task<bool> ReviewExistsAsync(int reviewId);

		Task<bool> HasReviewerWithIdAsync(int reviewId, string reviewerId);

		Task RemoveReviewAsync(int reviewId);

		Task<int> GetReviewCourseIdAsync(int reviewId);

		Task<ReviewFormViewModel> CreateReviewFormViewModelByIdAsync(int id);

		Task EditAsync(int id, ReviewFormViewModel model);
	}
}
