using BackendTest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Get a User
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the user is found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(Guid id)
        {

            return Ok();
        }


        /// <summary>
        /// Add a User
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If and user is added</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostUser([FromBody] UserModel model)
        {

            return Ok();
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and User is updated</response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {

            return NoContent();
        }



        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and user is deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {

            return NoContent();
        }
    }
}
