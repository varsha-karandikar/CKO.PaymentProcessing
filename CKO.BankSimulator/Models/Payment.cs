using CKO.PaymentGateway.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Models
{
    public class Payment
    {
        public string MerchantId { get; set; }

        public int Id { get; set; }
        public string ProcessorName { get; set; }

        public PaymentStatus TransactionStatus { get; set; }

        public CardDetails Card { get; set; }

        public decimal ApprovedAmount { get; set; }
    }
}
