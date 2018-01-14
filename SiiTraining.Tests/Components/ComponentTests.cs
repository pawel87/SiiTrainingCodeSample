using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Code.DomainModels;
using SiiTraining.Code.Services;
using SiiTraining.Components;
using SiiTraining.Models.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiiTraining.Tests.Components
{
    [TestClass]
    public class ComponentTests
    {
        [TestMethod]
        public void CallingComponentShouldResultWithValidModelValues()
        {
            //arrange
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllProducts()).Returns(new List<Product>()
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
            });

            var viewCompoment = new ProductSummary(repositoryMock.Object);

            //act
            var result = viewCompoment.Invoke() as ViewViewComponentResult;

            //assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(ProductSummaryViewModel));
            Assert.AreEqual(2, ((ProductSummaryViewModel)result.ViewData.Model).ProductsCount);
        }
    }
}
