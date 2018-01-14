using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SiiTraining.Code.Routes
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private static string[] days = new[] { "mon", "tue", "wed", "thu", "fri" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var isMatch = days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
            return isMatch;
        }
    }
}
