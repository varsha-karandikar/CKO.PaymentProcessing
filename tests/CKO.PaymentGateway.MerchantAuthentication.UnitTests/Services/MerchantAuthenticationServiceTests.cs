using CKO.PaymentGateway.Contracts.MerchantAuthentication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.MerchantAuthentication.UnitTests.Services
{
    [TestFixture]
    internal class MerchantAuthenticationServiceTests
    {
       
        [Test]
        public void Get_MerchantDetails_Empty_Should_Return_Null()
        {
            var merchantLogin = new MerchantLogin()
            {
                MerchantId = String.Empty,
                Secret = String.Empty
            };
            var service = new MerchantAuthenticationService();
            var result = service.Get(merchantLogin);
            Assert.IsNull(result);
        }

        [Test]
        public void Get_MerchantDetails_SecretAsNull_Should_Return_Null()
        {
            var merchantLogin = new MerchantLogin()
            {
                MerchantId = String.Empty,
                Secret = null
            };
            var service = new MerchantAuthenticationService();
            var result = service.Get(merchantLogin);
            Assert.IsNull(result);
        }

        [Test]
        public void Get_MerchantDetails_Valid_Should_Return_Merchant()
        {
            var merchantLogin = new MerchantLogin()
            {
                MerchantId = "1001",
                Secret = "mySecret1001"
            };
            var service = new MerchantAuthenticationService();
            var result = service.Get(merchantLogin);
            Assert.IsNotNull(result);
        }
    }
}
