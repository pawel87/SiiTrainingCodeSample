using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Code.Routes;

namespace SiiTraining.Tests.Routing
{
    [TestClass]
    public class CustomRouteTests
    {
        [TestMethod]
        public void GivenWeekDayShouldMatchRouteConstraint()
        {
            //assert
            var context = new Mock<HttpContext>();
            var route = new RouteCollection();
            var parameterName = "fake";
            var value = "mon";
            var values = new RouteValueDictionary() { { parameterName, value } };
            var constraint = new WeekDayConstraint();
            var routeDirection = RouteDirection.IncomingRequest;

            //act
            var match = constraint.Match(context.Object, route, parameterName, values, routeDirection);

            //assert
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void GivenWeekDayShouldNotMatchRouteConstraint()
        {
            //assert
            var context = new Mock<HttpContext>();
            var route = new RouteCollection();
            var parameterName = "fake";
            var value = "monday";
            var values = new RouteValueDictionary() { { parameterName, value } };
            var constraint = new WeekDayConstraint();
            var routeDirection = RouteDirection.IncomingRequest;

            //act
            var match = constraint.Match(context.Object, route, parameterName, values, routeDirection);

            //assert
            Assert.IsFalse(match);
        }

    }
}
