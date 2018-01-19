using Microsoft.AspNetCore.Builder;

namespace SiiTraining.Code.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseSampleMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SampleMiddleware>();
            return builder;
        }
    }
}
