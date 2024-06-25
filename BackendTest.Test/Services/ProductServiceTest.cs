
using BackendTest.API.Data.Repositories;
using BackendTest.API.Models;
using BackendTest.API.Services.Product;

namespace BackendTest.Test.Services
{

    [TestClass]
    public class ProductServiceTest
    {

        private readonly IProductService _productService;
        private readonly MySqlContext _context;

        public ProductServiceTest(IProductService productService, MySqlContext context)
        {
            _productService = productService;
            _context = context;
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Product_shlould_be_added(ProductModel model)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Product_shold_not_be_added(ProductModel model)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_get_a_product_by_id(Guid id)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_find_a_product_with_id(Guid Id)
        {


        }


        [TestMethod]
        [TestCategory("Services")]
        [DataRow("","")]
        [DataRow("","")]
        [DataRow("", "")]
        public void Should_update_a_product_name(ProductModel model)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("", "")]
        [DataRow("", "")]
        [DataRow("", "")]
        public void Should_not_update_a_product_name(ProductModel model)
        {


        }


        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_delete_a_product(Guid id)
        {


        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public void Should_not_delete_a_prduct(Guid id)
        {


        }
    }
}
