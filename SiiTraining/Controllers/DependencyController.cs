﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiiTraining.Controllers
{
    public class DependencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}