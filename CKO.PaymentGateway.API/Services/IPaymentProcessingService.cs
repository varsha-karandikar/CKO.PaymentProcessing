using CKO.PaymentGateway.Contracts.DTO;
using CKO.PaymentGateway.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.API.Services
{
    public interface IPaymentProcessingService
    {
        public Task<PaymentResponse> CreatePaymentAsync<T>(T paymentRequest) where T : IPaymentRequest;

        public Task<PaymentResponse> GetPaymentResponseAsync(int paymentId);

    }
}
