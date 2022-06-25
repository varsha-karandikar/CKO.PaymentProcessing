using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }

        public string ApprovalNumber { get; set; }

        public string ProcessorName { get; set; }

        public PaymentStatus TransactionStatus { get; set; }

        public decimal ApprovedAmount { get; set; }
    }
}
