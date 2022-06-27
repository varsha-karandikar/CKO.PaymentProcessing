using CKO.PaymentGateway.Contracts.MerchantAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.API.Repositories
{
    public  class MerchantRepository
    {
        public static List<Merchant> Merchants = new()
        {
            new()
            {
                MerchantId = "1001", MerchantStoreName = "Apple Store India", Secret = "l3ebUSGGaJ" ,
            },
            new()
            {
                MerchantId = "1002", MerchantStoreName = "Apple Store UK", Secret = "Qed7UOQLNn" ,
            },
            new()
            {
                MerchantId = "1003", MerchantStoreName = "Apple Store US", Secret = "nHXGH7T3zn" ,
            },
            new()
            {
                MerchantId = "1004", MerchantStoreName = "Apple Store France", Secret = "rcnQ9PDFxk" ,
            },
            new()
            {
                MerchantId = "1005", MerchantStoreName = "Apple Store Canada", Secret = "GhiMEYyH0O" ,
            },
            new()
            {
                MerchantId = "1006", MerchantStoreName = "Apple Store Australia", Secret = "h5RXPE1iZs" ,
            }
        };
    }
}
