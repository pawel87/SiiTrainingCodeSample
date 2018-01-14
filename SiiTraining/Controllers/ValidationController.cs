using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTraining.Models.Validators;

namespace SiiTraining.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SampleForm(SampleValidatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
            //return View(model);
        }
    }
}