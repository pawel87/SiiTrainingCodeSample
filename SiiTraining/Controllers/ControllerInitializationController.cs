using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTraining.Code.ControllerInitialization;

namespace SiiTraining.Controllers
{
    public class ControllerInitializationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Message", "Hello Desktop!");
        }

        [HttpGet]
        [ActionName("Index")]
        [IsMobile]
        public IActionResult IndexMobile()
        {
            return View("Message", "Hello Mobile!");
        }

    }
}