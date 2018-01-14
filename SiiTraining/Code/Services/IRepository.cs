using SiiTraining.Code.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Services
{
    public interface IRepository
    {
        List<Product> GetAllProducts();
        void RemoveProduct(int id);

    }
}
