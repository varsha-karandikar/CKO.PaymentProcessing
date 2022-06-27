using CKO.BankSimulator.DataContext;
using CKO.BankSimulator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKO.BankSimulator.Extensions;
using CKO.PaymentGateway.Contracts.Models;
using PaymentDetails = CKO.BankSimulator.Models.PaymentDetails;

namespace CKO.BankSimulator.Repository
{
    public class PaymentProcessingRepository : IPaymentProcessingRepository
    {
        private PaymentDBContext _dbContext;
        private const string ProcessorName = "CKO.BankSimulator.MockProcessor";
            
        public PaymentProcessingRepository(PaymentDBContext dataContext) 
        {
            _dbContext = dataContext;
        }
        public async Task<Payment> CreatePaymentAsync(PaymentGateway.Contracts.Interfaces.IPaymentRequest paymentRequest)
        {
            try
            {
                using var context = _dbContext;

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var newPayment = new Payment()
                {
                    MerchantId = paymentRequest.MerchantId,
                    PaymentDetails = new PaymentDetails()
                    {
                        PaymentStatus = GetRandomPaymentStatus(),
                        Amount = paymentRequest.Amount,
                        ProcessorName = ProcessorName
                    },

                    CurrencyCode = paymentRequest.CurrencyCode,
                    Card = new CardDetails()
                    {
                        CardLogo = GetRandomCardLogo(),
                        CardNumber = paymentRequest.CardNumber.GetMaskedCardNumber(6, 4, '*'),
                        ExpirationMonth = paymentRequest.ExpirationMonth,
                        ExpirationYear = paymentRequest.ExpirationYear
                    },
                    TransactionDateTime = DateTime.UtcNow

                };

                await context.AddAsync(newPayment);
                
                await context.SaveChangesAsync();
                return context.Payments.Where(x => x.MerchantId == paymentRequest.MerchantId).OrderByDescending(x => x.TransactionDateTime).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Payment> GetPaymentAsync(int paymentId)
        {

            var result = await _dbContext.Payments.Where(x => x.Id == paymentId).Include(x=> x.Card).Include(x=> x.PaymentDetails).FirstOrDefaultAsync();
            return result;

        }

        private CardLogo GetRandomCardLogo()
        {
            Array values = Enum.GetValues(typeof(CardLogo));
            var random = new Random();
            return (CardLogo)values.GetValue(random.Next(values.Length));
            
        }

        private PaymentStatus GetRandomPaymentStatus()
        {
            Array values = Enum.GetValues(typeof(PaymentStatus));
            var random = new Random();
            return (PaymentStatus)values.GetValue(random.Next(values.Length));

        }

    }
}
