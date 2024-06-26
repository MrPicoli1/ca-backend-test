using BackendTest.API.Models;
using BackendTest.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        /// <summary>
        /// Get a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the product is found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct(Guid id)
        {
           var result = await _productService.GetProduct(id);

            if (result == null) 
            {
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If and product is added</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostProduct([FromBody] ProductModel model)
        {

            var result = await _productService.AddProduct(model);

            if (result.IsValid() != null)
            {
                return BadRequest(result.IsValid());
            }

            return Ok(result);
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and product is found</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProduct([FromBody ]ProductModel model, Guid id)
        {
            var result = await _productService.UpdateProduct(model, id);

            if(result == null)
            {
                return NotFound();
            }

            if(result.IsValid() != null)
                return BadRequest(result.IsValid());

            return NoContent();
        }



        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and product is deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result == false)
                return NotFound();

            return NoContent();
        }

    }
}
