using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Code.Services;
using SiiTraining.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Tests.Caching
{
    [TestClass]
    public class CacheExample
    {
        [TestMethod]
        public void GivenResultAlreadyRetrieved_ShouldNotCallRepositoryAgain()
        {
            //assert
            var cache = new MemoryCache(new MemoryCacheOptions());
            var repository = new Mock<IRepository>();
            repository.Setup(x => x.GetAllProducts()).Returns(new List<Code.DomainModels.Product>()
            {
                new Code.DomainModels.Product()
                {
                    ProductId = 1,
                    Name = "iPhone"
                }
            });

            var sut = new CachingController(cache, repository.Object);

            //act
            var result = sut.SomeExample();
            var nextResult = sut.SomeExample();

            //assert
            repository.Verify(x => x.GetAllProducts(), Times.Once);
        }
    }
}
