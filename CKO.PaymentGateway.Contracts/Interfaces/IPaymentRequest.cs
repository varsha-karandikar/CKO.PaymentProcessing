using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Interfaces
{
    public interface IPaymentRequest : IRequest
    {
        public decimal Amount { get; set; } 

        public string MerchantId { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public string Cvv { get; set; }

        public string CurrencyCode { get; set; }

    }
}
