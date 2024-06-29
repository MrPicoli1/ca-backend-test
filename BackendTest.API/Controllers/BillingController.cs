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
        /// Add a Billing
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the Billing is added</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct([FromBody]string id)
        {
            var billing = _billingServices.AddBilling(id);

            if (billing == null) { return BadRequest("Billing API is Offline"); }
            if (billing.Details.Customer.IsValid().Count() > 0) { return BadRequest(billing.Details.Customer.IsValid()); }

            return Ok(billing);
        }
    }
}
