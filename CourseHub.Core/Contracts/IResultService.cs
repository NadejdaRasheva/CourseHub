using CourseHub.Core.Models.Result;
using CourseHub.Infrastructure.Data.Models;

namespace CourseHub.Core.Contracts
{
	public interface IResultService
	{
		Task<IEnumerable<ResultTeacherViewModel>> GetCourseStudents(int courseId);
		Task CreateAsync(ResultFormViewModel model);
		Task<bool> ResultExistsAsync(int resultId);
		Task<ResultViewModel> GetStudentResult(int courseId, string studentId);
		Task<bool> HasTeacherWithIdAsync(int resultId, string teacherId);

		Task<int> GetResultCourseIdAsync(int resultId);

		Task<ResultFormViewModel> CreateResultFormViewModelByIdAsync(int id);

		Task EditAsync(int id, ResultFormViewModel model);
	}
}
