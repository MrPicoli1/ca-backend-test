
using BackendTest.API.Data.Repositories;
using BackendTest.API.Models;
using BackendTest.API.Services.User;

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
        public void Should_add_an_user(UserModel model)
        {


        }
        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_add_an_user(UserModel model)
        {

        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_update_an_user(UserModel model)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_update_an_user(UserModel model)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_return_an_user(UserModel model)
        {


        }
        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_return_an_user(UserModel model)
        {

        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_delete_an_ser(Guid id)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_delete_an_user(Guid id)
        {


        }

    }
}
