using SiiTraining.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Components
{
    public class ProductsSummaryViewComponent
    {
        public string Invoke()
        {
            return $"We have {repository.GetAllProducts().Count} products in our store";
        }



        private readonly IRepository repository;

        public ProductsSummaryViewComponent(IRepository repository)
        {
            this.repository = repository;
        }


    }
}
