using CKO.PaymentGateway.Contracts.Models;

namespace CKO.PaymentGateway.Contracts.DTO
{
    public class PaymentResponse
    {
        public int Id { get; set; }
        //public string ResponseCode { get; set; }

        //public string ResponseMessage { get; set; }

        public DateTime TransactionTime { get; set; }

        public PaymentDetails PaymentDetails { get; set; }
        public Card Card { get; set; }

        public string MerchantId { get; set; }       

        public string CurrencyCode { get; set; }
    }
}