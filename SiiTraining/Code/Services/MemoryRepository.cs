using SiiTraining.Code.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Services
{
    public class MemoryRepository : IRepository
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "iPhone 5",
                    CategoryId = 1,
                    Price = 1999,
                    IsPromo = false
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Samsung S8",
                    CategoryId = 1,
                    Price = 2399,
                    IsPromo = true
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "PowerBank",
                    CategoryId = 2,
                    Price = 99,
                    IsPromo = false
                }
            };

            throw new NotImplementedException();
        }

        public void RemoveProduct(int id)
        {
            //todo: some logic...
        }
    }
}
