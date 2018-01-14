using Microsoft.AspNetCore.Mvc;
using SiiTraining.Code.Services;
using SiiTraining.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductSummary : ViewComponent
    {
        private readonly IRepository repository;

        public ProductSummary(IRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(new ProductSummaryViewModel()
            {
                ProductsCount = repository.GetAllProducts().Count,
                CategoriesCount = 5
            });
        }
    }
}
