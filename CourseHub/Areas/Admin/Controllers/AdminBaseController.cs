using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CourseHub.Core.Constants.RoleConstants;

namespace CourseHub.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRole)]
	public class AdminBaseController : Controller
	{

	}
}
