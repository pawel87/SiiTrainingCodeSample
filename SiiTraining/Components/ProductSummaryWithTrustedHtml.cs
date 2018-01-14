using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductSummaryWithTrustedHtml : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return new HtmlContentViewComponentResult(
               new HtmlString("This is <strong>call to action</strong> button with HTML markup")
            );
        }
    }
}
