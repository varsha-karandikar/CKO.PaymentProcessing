using CKO.BankSimulator.Models;
using CKO.PaymentGateway.Contracts.DTO;
using CKO.PaymentGateway.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Repository
{
    public interface IPaymentProcessingRepository
    {
        public Task<Payment> CreatePaymentAsync(IPaymentRequest paymentRequest);

        public Task<Payment> GetPaymentAsync(int paymentId);
    }
}
