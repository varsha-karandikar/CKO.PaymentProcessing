namespace CKO.PaymentGateway.Contracts.Models
{
    public class PaymentResponse
    {
        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public DateTime TransactionTime { get; set; }

        public Transaction Transaction { get; set; }
        public Card Card { get; set; }

        public string MerchantId { get; set; }

        public string IndustryCode { get; set; }

        public bool CheckForDuplicateTransactions { get; set; }

        
        public string CurrencyCode { get; set; }
    }
}