
using BackendTest.API.Data.Repositories;
using BackendTest.API.Models;
using BackendTest.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
        [DataRow("batata")]
        [DataRow("fruta")]
        [DataRow("coxinha")]
        public async Task Product_shlould_be_added(string name)
        {
            ProductModel model = new ProductModel();
            model.Name = name;

            var product = await _productService.AddProduct(model);
            
            Assert.IsNotNull( await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id));
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("a")]
        [DataRow("b")]
        [DataRow("as")]
        public async Task Product_shold_not_be_added(string name)
        {
            ProductModel model = new ProductModel();
            model.Name = name;

            var product = await _productService.AddProduct(model);

            Assert.IsNull(await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id));
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_get_a_product_by_id(string id)
        {
            var product = Guid.Parse(id);

            var result =await _productService.GetProduct(product);

           Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_find_a_product_with_id(string id)
        {
            var product = Guid.Parse(id);

            var result =await _productService.GetProduct(product);

            Assert.IsNull(result);

        }


        [TestMethod]
        [TestCategory("Services")]
        [DataRow("","")]
        [DataRow("","")]
        [DataRow("", "")]
        public async Task Should_update_a_product_name(string id, string name)
        {
            var product = Guid.Parse(id);
            ProductModel model = new ProductModel();
            model.Name = name;



            var result = _productService.UpdateProduct(model,product);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("", "")]
        [DataRow("", "")]
        [DataRow("", "")]
        public async Task Should_not_update_a_product_name(string id, string name)
        {
            var product = Guid.Parse(id);
            ProductModel model = new ProductModel();
            model.Name = name;


            var result = await _productService.UpdateProduct(model, product);

            Assert.IsNull(result);

        }


        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_delete_a_product(string id)
        {
            var product = Guid.Parse(id);
            var result = await _productService.DeleteProduct(product);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("Services")]
        [DataRow("")]
        [DataRow("")]
        [DataRow("")]
        public async Task Should_not_delete_a_prduct(string id)
        {
            var product = Guid.Parse(id);
            var result = await _productService.DeleteProduct(product);

            Assert.IsFalse(result);
        }
    }
}
