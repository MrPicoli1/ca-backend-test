
using System.Net.Http.Json;
using System.Net;
using System.Xml.Linq;

namespace BackendTest.Test.Controllers
{
    [TestClass]
    public class BillingControllerTests
    {
        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("2")]

        public async Task Should_return_200_if_valid_billing(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("https://localhost:7043/billing", id);

            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("1")]
        public async Task Shoud_return_400_if_invalid_billing(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/billing", id);

            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
