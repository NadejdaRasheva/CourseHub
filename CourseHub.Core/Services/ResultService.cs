using CourseHub.Core.Contracts;
using CourseHub.Core.Models.Result;
using CourseHub.Core.Models.Review;
using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CourseHub.Core.Services
{
	public class ResultService : IResultService
	{
		private readonly CourseHubDbContext _data;

        public ResultService(CourseHubDbContext data)
        {
			_data = data;
        }

        public async Task CreateAsync(ResultFormViewModel model)
		{
			var result = new Result()
			{
				Grade = model.Grade,
				Feedback = model.Feedback,
				CourseId = model.CourseId,
				StudentId = model.StudentId
			};

			await _data.Results.AddAsync(result);
			await _data.SaveChangesAsync();
		}

		public async Task<ResultFormViewModel> CreateResultFormViewModelByIdAsync(int id)
		{
			return await _data.Results.Where(r => r.Id == id).Select(r => new ResultFormViewModel()
			{
				Grade = r.Grade,
				Feedback = r.Feedback,
				CourseId = r.CourseId
			}).FirstAsync();
		}

		public async Task EditAsync(int id, ResultFormViewModel model)
		{
			var resultToEdit = await _data.Results.Where(r => r.Id == id).FirstOrDefaultAsync();

			if (resultToEdit != null)
			{
				resultToEdit.Grade = model.Grade;
				resultToEdit.Feedback = model.Feedback;

				await _data.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<ResultTeacherViewModel>> GetCourseStudents(int courseId)
		{
			var courseParticipants = await _data.CoursesParticipants
				.Where(c => c.CourseId == courseId)
				.Select(c => c.ParticipantId)
				.ToListAsync();

			var studentsInCourse = await _data.Users
				.Where(u => courseParticipants.Contains(u.Id))
                .Select(s => new ResultTeacherViewModel()
                {
                    CourseId = courseId,
                    StudentId = s.Id,
                    StudentName = $"{s.FirstName} {s.LastName}"
                })
                .ToListAsync();

			return studentsInCourse;
		}

		public async Task<int> GetResultCourseIdAsync(int resultId)
		{
			var result = await _data.Results.Where(r => r.Id == resultId).FirstOrDefaultAsync();

			return result.CourseId;
		}

		public async Task<bool> HasTeacherWithIdAsync(int resultId, string teacherId)
		{
			return await _data.Results.AnyAsync(r => r.Course.Teacher.UserId == teacherId);
		}


		public async Task<bool> ResultExistsAsync(int resultId)
		{
			return await _data.Results.AnyAsync(r => r.Id == resultId);
		}

		public async Task<ResultViewModel> GetStudentResult(int courseId, string studentId)
		{
			var result = await _data.Results
				.FirstOrDefaultAsync(r => r.CourseId == courseId && r.StudentId == studentId);

			var course = await _data.Courses.FirstAsync(c => c.Id == courseId);
			var courseName = course.Name;

				var resultView = new ResultViewModel()
				{
					Id = result.Id,
					CourseId = courseId,
					StudentId = studentId,
					Grade = result.Grade,
					Feedback = result.Feedback,
					CourseName = courseName
				};
				return resultView;
		}
	}
}
