using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiiTraining.IntegrationTests
{
    [TestClass]
    public class PingTests
    {
        private readonly TestContext sut;

        public PingTests()
        {
            sut = new TestContext();
        }

        [TestMethod]
        public async Task PingShouldReturnOkResponse()
        {
            //act
            var response = await sut.Client.GetAsync("/ping");

            //assert
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
