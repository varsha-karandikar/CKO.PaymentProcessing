using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Models
{
    public class PaymentDetails
    {
        public string ProcessorName { get; set; }

        public string PaymentStatus { get; set; }

        public decimal? Amount { get; set; }
    }
}
