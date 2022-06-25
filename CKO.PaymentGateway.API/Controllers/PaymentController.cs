using CKO.BankSimulator.Repository;
using CKO.PaymentGateway.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CKO.PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    { 
        private IPaymentProcessingRepository _paymentProcessingRepository;
        public PaymentController(IPaymentProcessingRepository paymentProcessingRepository)
        {
            _paymentProcessingRepository = paymentProcessingRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            await _paymentProcessingRepository.CreatePaymentAsync();
            return Ok(new PaymentResponse());
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
           var result = await _paymentProcessingRepository.GetPaymentAsync();
            return Ok(result);

        }

    }
}
