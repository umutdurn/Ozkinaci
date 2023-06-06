using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace B7.Filter
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies["AdminLogin"] == null)
            {
                context.Result = new RedirectResult("/Admin/Index");
            }

            base.OnActionExecuting(context);
        }
    }
}
