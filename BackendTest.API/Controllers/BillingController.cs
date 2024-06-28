using BackendTest.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    [ApiController]
    [Route("billing")]
    public class BillingController : Controller
    {

        private readonly IBillingServices _billingServices;

        public BillingController(IBillingServices billingServices)
        {
            _billingServices = billingServices;
        }

        /// <summary>
        /// Get a Product
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the product is found</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct([FromBody]string id)
        {
            var billing = _billingServices.AddBilling(id);
               

            return Ok(billing);
        }
    }
}
