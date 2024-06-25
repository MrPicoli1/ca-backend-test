
using BackendTest.API.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace BackendTest.Test.Controllers
{
    [TestClass]
    public class ProductControllerTest 
    {

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("Product 1")]
        [DataRow("Product 2")]
        [DataRow("Product 3")]
        public async Task Should_return_200_if_product_added(string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response =  await httpClient.PostAsJsonAsync("/product", new 
            {
                Name = $"{name}"
            });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("")]
        [DataRow("a")]
        [DataRow("ba")]
        public async Task Should_return_400_if_product_not_added(string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/product", new
            {
                Name = $"{name}"
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        public async Task Should_return_200_and_product_if_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/product/{id}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [TestCategory("Controller")]
        public async Task Should_return_400_if_product_not_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/product/{id}");

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "batata")]
        [DataRow("", "banana")]
        [DataRow("", "salgadinho")]
        public async Task Should_return_204_if_product_updated(string id,string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync("/product", new
            {
                Id = $"{id}",
                Name = $"{name}"
            });
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "")]
        [DataRow("", "a")]
        [DataRow("", "ab")]
        public async Task Should_return_400_if_product_not_updated(string id, string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync("/product", new
            {
                Id = $"{id}",
                Name = $"{name}"
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        public async Task Should_return_204_if_product_deleted(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/product/{id}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        [DataRow("01349e49-639a-41c0-90d1-f356b4c3b669")]
        public async Task Should_return_400_if_product_not_deleted(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/product/{id}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

    }
}
