using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiiTraining.Controllers
{
    public class TestController : Controller
    {
        public ViewResult DateTimeAction()
        {
            var vm = DateTime.Now;
            return View(vm);
        }

        public ViewResult HelloWorldAction()
        {
            var vm = "Hello World";
            return View(vm);
        }

        public RedirectResult Redirect()
        {
            return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult RedirectRoute()
        {
            return RedirectToRoute(new { controller = "Example", action = "Index", id = "sampleId" });
        }

        public JsonResult JsonAction()
        {
            return Json(new[] { "Sii", "Power", "People" });
        }

        public StatusCodeResult PageNotFound()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult PingTest()
        {
            return Ok();
        }
    }
}