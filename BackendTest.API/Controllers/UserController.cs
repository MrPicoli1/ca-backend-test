using BackendTest.API.Models;
using BackendTest.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

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

            var result = await _userService.GetUser(id);

            if (result == null)
                return NotFound();

            return Ok(result);
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
            var result = await _userService.AddUser(model);

            if (result == null)
                return BadRequest();

            if(result.IsValid().Count()>0)
                return BadRequest(result.IsValid());

            return Ok(result);
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If and User is updated</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model, Guid id)
        {
            var result = await _userService.UpdateUser(model, id);

            if (result == null)
                return BadRequest();
            if(result.IsValid().Count() >0)
                return BadRequest(result.IsValid());

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
            var result = await _userService.DeleteUSer(id);

            if(result ==  false)
                return NotFound();

            return NoContent();
        }
    }
}
