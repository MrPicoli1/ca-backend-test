
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
        [DataRow("Joao", "email@email.com", "rua 1")]
        [DataRow("Maria", "teste@teste.com.br", "rua 2")]
        [DataRow("Jose", "teste@email.com", "rua 3")]
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
        [DataRow("Jo", "email@email.com", "rua 1")]
        [DataRow("a", "teste@teste.com.br", "rua 2")]
        [DataRow("", "teste@email.com", "rua 3")]
        [DataRow("Joao", "emailemail.com", "rua 1")]
        [DataRow("Maria", "teste@testcom", "rua 2")]
        [DataRow("Jose", "", "rua 3")]
        [DataRow("Joao", "email@email.com", "r")]
        [DataRow("Maria", "teste@teste.com.br", "ru")]
        [DataRow("Jose", "teste@email.com", "")]
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
        [DataRow("f186a041-4326-44de-872e-52ed80ad1d2f")]
        [DataRow("82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        public async Task Should_return_200_and_user_if_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/user/{id}");


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("26032037-2c90-472d-9f96-b119cf8ed6c5")]
        [DataRow("1618f231-d68c-4f12-9a77-ecdc502093b6")]
        [DataRow("54a4b476-687a-4804-b975-02760e74847a")]
        public async Task Should_return_404_if_user_not_found(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.GetAsync($"/user/{id}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("Guilherme", "gmail@gmail.com", "rua1", "5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        [DataRow("Maria", "teste@yahoo.com.br", "rua2", "82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("Jose", "teste@email.com", "rua3", "f186a041-4326-44de-872e-52ed80ad1d2f")]
        public async Task Should_return_204_if_user_updated(string name, string email, string address, string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync($"/user/{id}", new
            {
                Name = $"{name}",
                Email = $"{email}",
                address = $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("Gu", "gmail@gmail.com", "rua1", "5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        [DataRow("M", "teste@yahoo.com.br", "rua2", "82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("", "teste@email.com", "rua3", "f186a041-4326-44de-872e-52ed80ad1d2f")]
        [DataRow("Guilherme", "gmailgmail.com", "rua1", "5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        [DataRow("Maria", "teste", "rua2", "82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("Jose", "", "rua3", "f186a041-4326-44de-872e-52ed80ad1d2f")]
        [DataRow("Guilherme", "gmail@gmail.com", "", "5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        [DataRow("Maria", "teste@yahoo.com.br", "a2", "82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("Jose", "teste@email.com", "r", "f186a041-4326-44de-872e-52ed80ad1d2f")]
        public async Task Should_return_400_if_user_not_updated(string name, string email, string address,string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PatchAsJsonAsync($"/user/{id}", new
            {
                Name = $"{name}",
                Email = $"{email}",
                address = $"{address}"
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("f186a041-4326-44de-872e-52ed80ad1d2f")]
        [DataRow("82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        public async Task Should_return_204_if_user_deleted(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/user/{id}");

            
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
           

        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("f186a041-4326-44de-872e-52ed80ad1d2f")]
        [DataRow("82a914ce-7499-4338-8a3a-e813e83df5d2")]
        [DataRow("5de1855f-ab8a-42ea-b20c-1beae09a0ca6")]
        public async Task Should_return_404_if_user_not_deletedAsync(string id)
        {
            var api = new ApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.DeleteAsync($"/user/{id}");


            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }


    }
}
