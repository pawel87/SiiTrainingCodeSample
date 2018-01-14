using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SiiTraining.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductSummaryWithContextData : ViewComponent
    {     
        public IViewComponentResult Invoke()
        {
            var manufacturer = RouteData.Values["id"] as string;
            //some logic here...

            return View(new ProductSummaryViewModel()
            {
                CategoriesCount = 2,
                ProductsCount = 5,
                Manufacturer = manufacturer
            });
        }
    }
}
