
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
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public void User_is_valid(string name, string email, string address)
        {


        }

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        [DataRow("", "", "")]
        public void User_is_invalid(string name, string email, string address)
        {


        }

       

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Product_is_valid(string name)
        {


        }

        [TestMethod]
        [TestCategory("Domain")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Product_is_invalid()
        {



        }


}
}
