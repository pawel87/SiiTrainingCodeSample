﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTraining.Code.Filters;
using Microsoft.Extensions.Logging;

namespace SiiTraining.Controllers
{
    
    public class FiltersController : Controller
    {
        private ILogger logger;

        public FiltersController(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<FiltersController>();
        }

        public IActionResult DummyForLog()
        {
            this.logger.LogInformation("test");
            return View();
        }

        [HttpsOnly]
        public IActionResult OnlyHttps()
        {
            return View();
        }

        [Profile]
        public IActionResult Stopwatch()
        {
            return View();
        }

        [ProfileAsync]
        public IActionResult StopwatchAsync()
        {
            return View();
        }

        [ViewResultDetails]
        public ViewResult ViewResultOne()
        {
            return View("Message", "This is ViewResultOne on Filters Controller");
        }

        [ViewResultDetails]
        public ViewResult ViewResultTwo()
        {
            return View("Message", "This is ViewResultTwo on Filters Controller");
        }

        [RangeException]
        public ViewResult RaiseException(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if(id > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", $"The given value is {id}");
            }
        }

        [TypeFilter(typeof(DiagnosticFilter))]
        [TypeFilter(typeof(TimeFilter))]
        public IActionResult FilterWithDependency()
        {
            return View("Message", "This is action result with some filters");
        }

        [FilterWithOrder(Order = 1)]
        public IActionResult FilterOrder()
        {
            return View("Message", "Some result");
        }

        [SampleActionFilter("abc")]
        public IActionResult FilterFactorySample()
        {
            return View("Message", "Example of IFilterFactory");
        }
    }
}