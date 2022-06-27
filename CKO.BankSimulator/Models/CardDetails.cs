using CKO.PaymentGateway.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Models
{
    public class CardDetails
    {
        public int Id { get; set; }
        public CardLogo CardLogo { get; set; }
        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

    }
}
