using BackendTest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
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

            return Ok();
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

            return Ok();
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and product is found</response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProduct([FromBody ]ProductModel model)
        {

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

            return NoContent();
        }

    }
}
