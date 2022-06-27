using CKO.PaymentGateway.MerchantAuthentication.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.MerchantAuthentication.UnitTests.Repositories
{
    [TestFixture]
    internal class MerchantRepositoryTests
    {
        [Test]
        public void MerchantList_ShouldNotBeEmpty()
        {
            var merchantList = MerchantRepository.Merchants.Count;
            Assert.Greater(merchantList, 0);
        }
    }
}
