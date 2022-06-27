using CKO.PaymentGateway.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Models
{
    public class PaymentDetails
    {

        public int Id { get; set; }
        public string ProcessorName { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal? Amount { get; set; }
    }
}
