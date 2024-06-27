
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
        [DataRow("08dc962d-6459-4052-8c1d-902135d75d8d")]
        [DataRow("c8d5de7d-7c11-4b77-841c-775af7cc48a3")]
        [DataRow("fd473f39-d356-46ce-aa86-7cd33ac8e6c3")]
        public async Task Should_return_200_and_product_if_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/product/{id}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [DataRow("1618f231-d68c-4f12-9a77-ecdc502093b6")]
        [DataRow("54a4b476-687a-4804-b975-02760e74847a")]
        [DataRow("26032037-2c90-472d-9f96-b119cf8ed6c5")]
        [TestCategory("Controller")]
        public async Task Should_return_404_if_product_not_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/product/{id}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("fd473f39-d356-46ce-aa86-7cd33ac8e6c3", "batata")]
        [DataRow("c8d5de7d-7c11-4b77-841c-775af7cc48a3", "banana")]
        [DataRow("08dc962d-6459-4052-8c1d-902135d75d8d", "salgadinho")]
        public async Task Should_return_204_if_product_updated(string id,string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync($"/product/{id}", new
            {
                Name = $"{name}"
            });
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("fd473f39-d356-46ce-aa86-7cd33ac8e6c3", "")]
        [DataRow("c8d5de7d-7c11-4b77-841c-775af7cc48a3", "a")]
        [DataRow("08dc962d-6459-4052-8c1d-902135d75d8d", "ab")]
        public async Task Should_return_400_if_product_not_updated(string id, string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync($"/product/{id}", new
            {
                Name = $"{name}"
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("26032037-2c90-472d-9f96-b119cf8ed6c5", "")]
        [DataRow("54a4b476-687a-4804-b975-02760e74847a", "a")]
        [DataRow("1618f231-d68c-4f12-9a77-ecdc502093b6", "ab")]
        public async Task Should_return_404_if_product_not_found_to_updated(string id, string name)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync($"/product/{id}", new
            {
                Name = $"{name}"
            });
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("fd473f39-d356-46ce-aa86-7cd33ac8e6c3")]
        [DataRow("c8d5de7d-7c11-4b77-841c-775af7cc48a3")]
        [DataRow("08dc962d-6459-4052-8c1d-902135d75d8d")]
        public async Task Should_return_204_if_product_deleted(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/product/{id}");
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("fd473f39-d356-46ce-aa86-7cd33ac8e6c3")]
        [DataRow("c8d5de7d-7c11-4b77-841c-775af7cc48a3")]
        [DataRow("08dc962d-6459-4052-8c1d-902135d75d8d")]
        public async Task Should_return_404_if_product_not_deleted(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/product/{id}");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }

    }
}
