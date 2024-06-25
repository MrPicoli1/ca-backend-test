using AutoMapper;
using BackendTest.API.Data.Repositories;
using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.API.Services
{
    public class ProductService : IProductService
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductService(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> AddProduct(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);

            if (product.IsValid() != null)
            {
                return product;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return false;
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }

        public async Task<Product> UpdateProduct(ProductModel model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (product == null)
            {
                return null;
            }
            product.Update(model.Name);

            var error = product.IsValid();

            if (error != null)
            {
                return product;
            }

            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
