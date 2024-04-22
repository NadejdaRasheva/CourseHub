using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Models.Review
{
	public class ReviewAllViewModel
	{
		public int Id { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; } = string.Empty;
		public int CourseId { get; set; }
		public string ReviewerId { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
	}
}
