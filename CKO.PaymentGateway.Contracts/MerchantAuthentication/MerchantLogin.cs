using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts.MerchantAuthentication
{
    public class MerchantLogin
    {
        public string MerchantId { get; set; }

        public string Secret { get; set; }
    }
}
