using CKO.PaymentGateway.Contracts.MerchantAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.MerchantAuthentication.Repositories
{
    public  class MerchantRepository
    {
        public static List<Merchant> Merchants = new()
        {
            new()
            {
                MerchantId = "1001", MerchantStoreName = "Apple Store India", Secret = "mySecret1001" ,
            },
            new()
            {
                MerchantId = "1002", MerchantStoreName = "Apple Store UK", Secret = "mySecret1002" ,
            },
            new()
            {
                MerchantId = "1003", MerchantStoreName = "Apple Store US", Secret = "mySecret1003" ,
            },
            new()
            {
                MerchantId = "1004", MerchantStoreName = "Apple Store France", Secret = "mySecret1004" ,
            },
            new()
            {
                MerchantId = "1005", MerchantStoreName = "Apple Store Canada", Secret = "mySecret1005" ,
            },
            new()
            {
                MerchantId = "1006", MerchantStoreName = "Apple Store Australia", Secret = "mySecret1006" ,
            }
        };
    }
}
