using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTraining.Models.Binding;

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
        public IActionResult Sample([Bind("Title,AppointmentDate")] Appointment appointment)
        {
            if(ModelState.IsValid)
            {
                //some logic here...

                return RedirectToAction("Sample");
            }

            return View(appointment);
        }
    }
}