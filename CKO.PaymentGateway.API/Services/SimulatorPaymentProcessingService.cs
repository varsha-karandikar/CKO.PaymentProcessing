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
            //var newPaymentRequest = new Payment()
            //{
            //    Amount = paymentRequest.Amount,
            //    MerchantId = paymentRequest.MerchantId
               
            //};

            var newPayment = await _paymentProcessingRepository.CreatePaymentAsync(paymentRequest);

            return new PaymentResponse()
            {
                TransactionTime = newPayment.TransactionDateTime,
                Id = newPayment.Id,
                Card = new Contracts.Models.Card()
                {
                    CardLogo = newPayment.Card.CardLogo,
                    MaskedCardNumber = newPayment.Card.CardNumber
                    
                },
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    ApprovedAmount = newPayment.PaymentDetails.ApprovedAmount,
                    PaymentStatus = newPayment.PaymentDetails.PaymentStatus,
                    ApprovalNumber = newPayment.PaymentDetails.ApprovalNumber,
                    ProcessorName = newPayment.PaymentDetails.ProcessorName
                },
                CurrencyCode = newPayment.CurrencyCode,
                MerchantId = newPayment.MerchantId

            };
        }

        public async Task<PaymentResponse> GetPaymentResponseAsync(int paymentId)
        {
            var paymentResponse = await _paymentProcessingRepository.GetPaymentAsync(paymentId);
            return new PaymentResponse()
            {
                TransactionTime = paymentResponse.TransactionDateTime,
                Id = paymentResponse.Id,
                Card = new Contracts.Models.Card()
                {
                    CardLogo = paymentResponse.Card.CardLogo,
                    MaskedCardNumber = paymentResponse.Card.CardNumber

                },
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    ApprovedAmount = paymentResponse.PaymentDetails.ApprovedAmount,
                    PaymentStatus = paymentResponse.PaymentDetails.PaymentStatus,
                    ApprovalNumber = paymentResponse.PaymentDetails.ApprovalNumber,
                    ProcessorName = paymentResponse.PaymentDetails.ProcessorName
                },
                CurrencyCode = paymentResponse.CurrencyCode,
                MerchantId = paymentResponse.MerchantId

            };
        }
    }
}
