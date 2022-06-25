using CKO.BankSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Repository
{
    public interface IPaymentProcessingRepository
    {
        public Task CreatePaymentAsync();

        public Task<Payment> GetPaymentAsync();
    }
}
