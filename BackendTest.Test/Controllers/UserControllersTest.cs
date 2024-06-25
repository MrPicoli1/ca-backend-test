
using System.Net.Http.Json;
using System.Net;
using BackendTest.API.Domain.Entities;

namespace BackendTest.Test.Controllers
{
    [TestClass]
    public class UserControllersTest
    {
        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public async Task Should_return_200_if_user_added(string name, string email,string address)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/user", new
            {
                Name = $"{name}",
                Email= $"{email}",
                address= $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public async Task Should_return_400_if_user_not_added(string name, string email, string address)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/user", new
            {
                Name = $"{name}",
                Email = $"{email}",
                address = $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_return_200_and_user_if_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/user/{id}");

            var user = await response.Content.ReadFromJsonAsync<User>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_return_400_if_user_not_found(Guid id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/user/{id}");

            await response.Content.ReadFromJsonAsync<User>();
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);


            Assert.Fail();
            

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public async Task Should_return_204_if_user_updated(string name, string email, string address)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync("/user", new
            {
                Name = $"{name}",
                Email = $"{email}",
                address = $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public async Task Should_return_500_if_user_not_updated(string name, string email, string address)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync("/user", new
            {
                Name = $"{name}",
                Email = $"{email}",
                address = $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public async Task Should_return_204_if_user_deleted(Guid id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/user/{id}");

            
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
           

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_return_204_if_user_not_deletedAsync(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/user/{id}");


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


    }
}
