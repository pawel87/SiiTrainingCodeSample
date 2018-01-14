using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiiTraining.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiiTraining.Tests.Controllers
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void TypePassedToViewIsDateTime()
        {
            //arrange
            var controller = new TestController();

            //act
            var result = controller.DateTimeAction();

            //assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
        }

        [TestMethod]
        public void ActionShouldDoRedirectPermanent()
        {
            //arrange
            var controller = new TestController();

            //act
            var result = controller.Redirect();

            //assert
            Assert.AreEqual("/Example/Index", result.Url);
            Assert.IsTrue(result.Permanent);
        }

        [TestMethod]
        public void ActionShouldDoRoutedRedirection()
        {
            //arrange
            var controller = new TestController();

            //act
            var result = controller.RedirectRoute();

            //assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("sampleId", result.RouteValues["id"]);
        }

        [TestMethod]
        public void JsonActionShouldReturnGivenArray()
        {
            //arrange
            var controller = new TestController();

            //act
            var result = controller.JsonAction();

            //arrange
            Assert.AreEqual(new[] { "Sii", "Power", "People" }, result.Value);
        }

        [TestMethod]
        public void NotFoundPageShouldReturn404StatusCode()
        {
            //arrange
            var controller = new TestController();

            //act
            var result = controller.PageNotFound();

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }



    }
}
