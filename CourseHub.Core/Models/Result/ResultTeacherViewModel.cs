using CourseHub.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Models.Result
{
	public class ResultTeacherViewModel : IStudentModel
	{
		public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
		public int CourseId { get; set; }

    }
}
