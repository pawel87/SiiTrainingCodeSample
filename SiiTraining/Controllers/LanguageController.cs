using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SiiTraining.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IStringLocalizer<LanguageController> _localizer;

        public LanguageController(IStringLocalizer<LanguageController> localizer)
        {
            _localizer = localizer;
        }

        public string SampleGet()
        {
            return _localizer["Welcome"];
        }


        public IActionResult Example()
        {
            return View();
        }
    }
}