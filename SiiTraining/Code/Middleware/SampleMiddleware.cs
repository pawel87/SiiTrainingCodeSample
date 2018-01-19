using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var sw = new Stopwatch();
            sw.Start();

            await _next(context);

            if(context.Response.StatusCode == 200)
            {
                sw.Stop();

                using(var writer = new StreamWriter(context.Response.Body))
                {
                    var text = $"<div>Elapsed:{sw.ElapsedMilliseconds}</div>";
                    writer.Write(text);
                }

            }
        }
    }
}
