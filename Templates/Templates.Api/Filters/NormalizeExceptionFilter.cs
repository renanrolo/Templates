using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Templates.Api.Filters
{
    public class NormalizeExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.Clear();

            context.HttpContext.Response.StatusCode = 500;

            context.Result = new JsonResult(new { Title = "Oops", Message = "Something went wrong, but we recorded that. Hope we correct that soon." });
        }
    }
}
