
using BackendTest.API.Data.Repositories;
using BackendTest.API.Models;
using BackendTest.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Test.Services
{
    [TestClass]
    public class UserServicesTest
    {
        private readonly IUserService _userService;
        private readonly MySqlContext _context;

        public UserServicesTest(IUserService userService, MySqlContext context)
        {
            _userService = userService;
            _context = context;
        }



        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_add_an_user(string name, string email, string address)
        {
            UserModel model = new UserModel();
            model.Name = name;
            model.Address = address;
            model.Email = email;

            var result = await _userService.AddUser(model);

            Assert.IsNotNull(await _context.Users.FirstOrDefaultAsync(x => x.Id == result.Id));


        }
        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_add_an_user(string name, string email, string address)
        {
            UserModel model = new UserModel();
            model.Name = name;
            model.Address = address;
            model.Email = email;

            var result = await _userService.AddUser(model);

            Assert.IsNull(await _context.Users.FirstOrDefaultAsync(x => x.Id == result.Id));
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_update_an_user(string name, string email, string address, string id)
        {
            var user = Guid.Parse(id);
            UserModel model = new UserModel();
            model.Name = name;
            model.Address = address;
            model.Email = email;


            var result =await  _userService.UpdateUser(model, user);

            Assert.IsNotNull(await _context.Users.FirstOrDefaultAsync(x => x.Id == result.Id));

        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_update_an_user(string name, string email, string address, string id)
        {
            var user = Guid.Parse(id);
            UserModel model = new UserModel();
            model.Name = name;
            model.Address = address;
            model.Email = email;


            var result = await _userService.UpdateUser(model,user);

            Assert.IsNull(await _context.Users.FirstOrDefaultAsync(x => x.Id == result.Id));

        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_return_an_user(string id)
        {
            var user = Guid.Parse(id);
           

            var result = await _userService.GetUser(user);

            Assert.IsNotNull(result);

        }
        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_return_an_user(string id)
        {
            var user = Guid.Parse(id);

            var result = await _userService.GetUser(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_delete_an_ser(string id)
        {
            var user = Guid.Parse(id);

            var result = await _userService.DeleteUSer(user);

            Assert.IsTrue(result);

        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_delete_an_user(string id)
        {
            var user = Guid.Parse(id);

            var result = await _userService.DeleteUSer(user);

            Assert.IsFalse(result);

        }

    }
}
