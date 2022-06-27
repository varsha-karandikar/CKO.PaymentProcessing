using CKO.BankSimulator.Models;
using CKO.BankSimulator.Repository;
using CKO.PaymentGateway.Contracts.DTO;
using CKO.PaymentGateway.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.API.Services
{
    public class SimulatorPaymentProcessingService : IPaymentProcessingService
    {
        private IPaymentProcessingRepository _paymentProcessingRepository;
        public SimulatorPaymentProcessingService(IPaymentProcessingRepository paymentProcessingRepository)
        {
            _paymentProcessingRepository = paymentProcessingRepository;
        }

        public async Task<PaymentResponse> CreatePaymentAsync<T>(T paymentRequest) where T : IPaymentRequest
        {
            var newPayment = await _paymentProcessingRepository.CreatePaymentAsync(paymentRequest);

            return GenerateResponseFromService(newPayment);
        }

        public async Task<PaymentResponse> GetPaymentResponseAsync(int paymentId)
        {
            var paymentResponse = await _paymentProcessingRepository.GetPaymentAsync(paymentId);
            return GenerateResponseFromService(paymentResponse);
        }

        private PaymentResponse GenerateResponseFromService(Payment payment)
        {
            return new PaymentResponse()
            {
                TransactionTime = payment.TransactionDateTime,
                Id = payment.Id,
                Card = new Contracts.Models.Card()
                {
                    CardLogo = payment.Card.CardLogo,
                    MaskedCardNumber = payment.Card.CardNumber

                },
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    Amount = payment.PaymentDetails.Amount,
                    PaymentStatus = Enum.GetName(payment.PaymentDetails.PaymentStatus),
                    ProcessorName = payment.PaymentDetails.ProcessorName
                },
                CurrencyCode = payment.CurrencyCode,
                MerchantId = payment.MerchantId

            };
        }
    }
}
