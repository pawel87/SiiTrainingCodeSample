using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SiiTraining.IntegrationTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public async Task HomePageShouldReturnContent()
        {
            var webHostBuilder = new WebHostBuilder()
                                .UseContentRoot(@"C:\Users\pawel\source\repos\SiiTraining\SiiTraining")
                                .UseEnvironment("Test")    //we can set up the environment (development, staging, production...)
                                .UseStartup<Startup>();

            using (var server = new TestServer(webHostBuilder))
            {
                using (var client = server.CreateClient())
                {
                    var result = await client.GetAsync("/");

                    //fail if non-success result
                    result.EnsureSuccessStatusCode();

                    var responseHtml = await result.Content.ReadAsStringAsync();

                    //assert expected content
                    StringAssert.Contains(responseHtml, "Learn how to build ASP.NET apps that can run anywhere");
                }
            }
        }
    }
}
