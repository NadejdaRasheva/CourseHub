using CourseHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Tests.Mocks
{
	public static class DatabaseMock
	{
		public static CourseHubDbContext Instance
		{
			get
			{
				var dbContextOptions = new DbContextOptionsBuilder<CourseHubDbContext>()
					.UseInMemoryDatabase("CourseHubInMemoryDb"
					+ DateTime.Now.Ticks.ToString())
					.Options;

				return new CourseHubDbContext (dbContextOptions, false);
			}
		}
	}
}
