using CKO.BankSimulator.Repository;
using CKO.PaymentGateway.API.Services;
using CKO.PaymentGateway.Contracts.DTO;
using CKO.PaymentGateway.Contracts.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CKO.PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    { 
        private readonly IPaymentProcessingService _paymentProcessingService;
        public PaymentController(IPaymentProcessingService paymentProcessingService)
        {
            _paymentProcessingService = paymentProcessingService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create(PaymentRequest paymentRequest)
        {
            IActionResult response = null;

            try
            {
                var result = await _paymentProcessingService.CreatePaymentAsync(paymentRequest);
                if (result != null)
                    response = Created(new Uri("/Payment", UriKind.Relative), result); 

            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet("{paymentId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int paymentId)
        {
            try
            {
                var result = await _paymentProcessingService.GetPaymentResponseAsync(paymentId);
                if (result == null)
                    return NotFound(new { PaymentId = paymentId, Error = "This paymentId does not exist" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
