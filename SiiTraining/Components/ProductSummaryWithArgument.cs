using Microsoft.AspNetCore.Mvc;
using SiiTraining.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductSummaryWithArgument : ViewComponent
    {
        public IViewComponentResult Invoke(string manufacturer)
        {
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
