using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Models
{
    public class Card
    {
        public CardLogo CardLogo { get; set; }
        public string MaskedCardNumber { get; set; }

    }
}
