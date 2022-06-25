using CKO.BankSimulator.DataContext;
using CKO.BankSimulator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Repository
{
    public class PaymentProcessingRepository : IPaymentProcessingRepository
    {
        private PaymentDBContext _dbContext;
            
        public PaymentProcessingRepository(PaymentDBContext dataContext) 
        {
            _dbContext = dataContext;
        }
        public async Task CreatePaymentAsync()
        {
            using var context = _dbContext;

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //context.AddRange(
            //    new Blog { Name = "Blog1", Url = "http://blog1.com" },
            //    new Blog { Name = "Blog2", Url = "http://blog2.com" });

            //context.SaveChanges();

            await context.AddAsync(new Payment()
            {
                Id = 1000,
                MerchantId = "1",
                Card = new CardDetails()
                {
                    Id = 123,
                    CardLogo = PaymentGateway.Contracts.Models.CardLogo.MasterCard,
                    MaskedCardNumber = "1234****"
                }

            });
            await context.SaveChangesAsync();
        }

        public async Task<Payment> GetPaymentAsync()
        {
            var result = await _dbContext.Payments.Where(x => x.Id == 1000).FirstOrDefaultAsync();
            return result;

        }

    }
}
