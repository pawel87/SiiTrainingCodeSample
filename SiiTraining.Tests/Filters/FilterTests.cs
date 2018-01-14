using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Code.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.Tests.Filters
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void TestHttpsFilter()
        {
            //arrange
            var httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(m => m.IsHttps).Returns(true)
                                                     .Returns(false);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpRequest.Object);

            var actionContext = new ActionContext(httpContext.Object, new RouteData(), new ActionDescriptor());
            var authorizationContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());

            var filter = new HttpsOnlyAttribute();

            //act & assert
            filter.OnAuthorization(authorizationContext);
            Assert.IsNull(authorizationContext.Result);

            filter.OnAuthorization(authorizationContext);
            Assert.IsInstanceOfType(authorizationContext.Result, typeof(StatusCodeResult));
            Assert.AreEqual(StatusCodes.Status403Forbidden, (authorizationContext.Result as StatusCodeResult).StatusCode);


        }


    }
}
