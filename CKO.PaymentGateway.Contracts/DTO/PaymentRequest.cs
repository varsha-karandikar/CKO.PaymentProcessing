using CKO.PaymentGateway.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CKO.PaymentGateway.Contracts.DTO
{
    public class PaymentRequest : IPaymentRequest
    {
        public string MerchantId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage ="Expiration month should be between 1 and 12")]
        public int ExpirationMonth { get; set; }

        [Required]
        public int ExpirationYear { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Guid RequestId { get; set; }
    }
}