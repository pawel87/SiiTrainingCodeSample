using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTraining.Models.Binding;
using SiiTraining.Code.Services;
using SiiTraining.Code.Binding;

namespace SiiTraining.Controllers
{
    public class BindingController : Controller
    {
        public IActionResult Sample()
        {
            var vm = new Appointment();
            return View(vm);
        }


        [HttpPost]
        public IActionResult BindExample(MyComplexViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        public IActionResult ActionFoo([FromServices] IDateService service)
        {
            var message = $"Current date is {service.GetCurrentTime()}";

            return View("Message", message);
        }

        [HttpPost]
        public IActionResult ActionCollection([FromForm]SampleViewModel model)
        {


            return View("Message", "Done");
        }
        [HttpPost]
        public IActionResult Sample([Bind("Title,AppointmentDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                //some logic here...

                return RedirectToAction("Sample");
            }

            return View(appointment);
        }
    }
}