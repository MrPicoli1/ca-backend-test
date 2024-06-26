using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;

namespace BackendTest.API.Services
{
    public interface IProductService
    {
        public Task<Product> AddProduct(ProductModel model);
        public Task<Product> GetProduct(Guid id);
        public Task<Product> UpdateProduct(ProductModel model, Guid? guid);
        public Task<bool> DeleteProduct(Guid id);
    }
}
