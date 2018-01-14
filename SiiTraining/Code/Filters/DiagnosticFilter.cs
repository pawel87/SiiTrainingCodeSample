using Microsoft.AspNetCore.Mvc.Filters;
using SiiTraining.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Code.Filters
{
    public class DiagnosticFilter : IAsyncResultFilter
    {
        private IFilterDiagnostics diagnostics;

        public DiagnosticFilter(IFilterDiagnostics filterDiagnostics)
        {
            diagnostics = filterDiagnostics;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();

            foreach(var message in diagnostics?.Messages)
            {
                var bytes = Encoding.ASCII.GetBytes($"<div>{message}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
