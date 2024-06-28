

namespace BackendTest.Test.Services
{
    [TestClass]
    public class BillingServices
    {
        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("")]
        [DataRow("2")]
        [DataRow("3")]
        public async Task Billing_should_be_Added(string id)
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Controller")]
        [DataRow("1")]
        [DataRow("")]
        [DataRow("")]
        public async Task Billing_should_not_be_Added(string id)
        {

        Assert.Fail(); 
        }
    }
}
