using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Models.Components
{
    public class ProductSummaryViewModel
    {
        public int ProductsCount { get; set; }
        public int CategoriesCount { get; set; }

        public string Manufacturer { get; set; }
    }
}
