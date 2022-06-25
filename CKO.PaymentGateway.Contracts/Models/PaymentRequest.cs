namespace CKO.PaymentGateway.Contracts.Models
{
    public class PaymentRequest
    {
        public string MerchantId { get; set; }

        public string MarketCode { get; set; }

        public bool CheckForDuplicateTransactions { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public string Cvv { get; set; }

        public string CurrencyCode { get; set; }
    }
}