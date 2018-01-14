using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class ProfileAsyncAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var timer = Stopwatch.StartNew();

            await next();

            timer.Stop();

            var result = $"<div>Elapsed time: {timer.Elapsed.TotalMilliseconds} ms</div>";
            var bytes = Encoding.ASCII.GetBytes(result);
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}
