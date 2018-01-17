using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Linq;

namespace SiiTraining.Code.ControllerInitialization
{
    public class IsMobileAttribute : Attribute, IActionConstraint
    {
        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var isMobile = context.RouteContext.HttpContext.Request.Headers["User-Agent"]
                .Any(agent => agent.Contains("Android") || agent.Contains("iPhone"));

            return isMobile;
        }
    }
}
