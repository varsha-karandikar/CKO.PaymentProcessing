using CKO.BankSimulator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.DataContext
{
    
        public class PaymentDBContext : DbContext
        {
            public DbSet<Payment> Payments { get; set; }

            public PaymentDBContext(DbContextOptions<PaymentDBContext> options)
                : base(options)
            {

            }
        }

    
}
