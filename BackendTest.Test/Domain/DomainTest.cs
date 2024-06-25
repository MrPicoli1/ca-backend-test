
using BackendTest.API.Domain.Entities;
using System.Xml.Linq;

namespace BackendTest.Test.Domain
{

    /*
     
     [DataRow("", "", "", true)]
     [DataRow("src", "", "", true)]
     [DataRow("src", "med", "", true)]
     [DataRow("src", "med", "nme", false)]
    
     */

    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("Joao", "email@email.com", "Rua 1")]
        [DataRow("Maria", "gmail@gmail.com.br", "Rua 2")]
        [DataRow("Jose", "teste@teste.com", "Rua 3")]
        public void User_is_valid(string name, string email, string address)
        {
            var user = new User(name, email, address);
            var list = new List<string>();
            list = user.IsValid();

            int errors = list.Count();

            Assert.AreEqual(0, errors);
        }

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("a", "email@email.com", "Rua 1")]
        [DataRow("a", "email@email.com", "rua 2")]
        [DataRow("b", "email@email.com", "rua 3")]
        [DataRow("Jose", "emailemail.com", "rua 1")]
        [DataRow("Maria", "email@emailcom", "rua 2")]
        [DataRow("Joao", "a", "rua 3")]
        [DataRow("Joao", "email@email.com", "a")]
        [DataRow("maria", "email@email.com", "a")]
        [DataRow("Jose", "email@email.com", "ab")]
        public void User_is_invalid(string name, string email, string address)
        {
            var user = new User(name, email, address);
            var list = new List<string>();
            list = user.IsValid();

            Assert.IsNotNull(list);

        }

       

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("batata")]
        [DataRow("coxinha")]
        [DataRow("frango")]
        public void Product_is_valid(string name)
        {
            Product product = new Product(name);

            var list = new List<string>();
            list = product.IsValid();

            Assert.IsNull(list);

        }

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("b")]
        [DataRow("a")]
        [DataRow("ab")]

        public void Product_is_invalid(string name)
        {

            Product product = new Product(name);
            var list = new List<string>();
            list = product.IsValid();

            Assert.IsTrue(list.Any());

        }


}
}
