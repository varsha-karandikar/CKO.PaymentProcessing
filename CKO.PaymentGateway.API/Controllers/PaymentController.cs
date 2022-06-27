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
        public async Task<ActionResult> Create(PaymentRequest paymentRequest)
        {
            var result = await _paymentProcessingService.CreatePaymentAsync(paymentRequest);
            return Ok(result);
        }

        [HttpGet()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(int paymentId)
        {
           var result = await _paymentProcessingService.GetPaymentResponseAsync(paymentId);
            return Ok(result);

        }

    }
}
