using CourseHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CourseHub.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> All()
        {
            var model = await _userService.AllAsync();

            return View(model);
        }
    }
}
