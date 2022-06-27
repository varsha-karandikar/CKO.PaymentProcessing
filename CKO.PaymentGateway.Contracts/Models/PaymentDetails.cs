using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Models
{
    public class PaymentDetails
    {
        public string ApprovalNumber { get; set; }

        public string ProcessorName { get; set; }

        public string PaymentStatus { get; set; }

        public decimal ApprovedAmount { get; set; }
    }
}
