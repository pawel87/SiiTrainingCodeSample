using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductSummaryWithHtml : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return Content("This is <strong>call to action</strong> button with HTML markup");
        }
    }
}
