using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Middleware
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<div> Hello from Middleware </div>");
            await _next(context);
            await context.Response.WriteAsync("<div> Bye from Middleware </div>");
        }
    }
}
