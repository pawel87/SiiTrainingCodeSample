using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiiTraining.Controllers
{
    public class RoutesController : Controller
    {
        public IActionResult CustomConstraint(string day)
        {
            return View("Message", $"Constraint. Selected day: {day}");
        }

        public IActionResult CustomRouteConstraintInline(string day)
        {
            return View("Message", $"Inline constraint. Selected day: {day}");
        }
        
    }
}