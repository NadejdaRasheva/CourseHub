using CourseHub.Core.Contracts;
using CourseHub.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseHub.Attributes
{
    public class NotTeacherAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ITeacherService? teacherService = context.HttpContext.RequestServices.GetService<ITeacherService>();

            if(teacherService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
            if(teacherService != null && teacherService.ExistsByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
