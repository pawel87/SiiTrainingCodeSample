using Microsoft.AspNetCore.Mvc.Filters;
using SiiTraining.Code.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private Stopwatch timer;
        private IFilterDiagnostics diagnostics;

        public TimeFilter(IFilterDiagnostics filterDiagnostics)
        {
            diagnostics = filterDiagnostics;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            diagnostics.AddMessage($"Action time: {timer.Elapsed.TotalMilliseconds}");
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            diagnostics.AddMessage($"Result time: {timer.Elapsed.TotalMilliseconds}");
        }
    }
}
