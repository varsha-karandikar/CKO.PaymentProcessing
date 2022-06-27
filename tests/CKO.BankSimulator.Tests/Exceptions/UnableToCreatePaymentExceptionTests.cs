using CKO.BankSimulator.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.BankSimulator.Tests.Exceptions
{
    [TestFixture]
    internal class UnableToCreatePaymentExceptionTests
    {
        [Test]
        public void Constructor_Empty_ShouldSucceed()
        {
            var ex = new UnableToCreatePaymentException("Test Message");
            Assert.NotNull(ex);
            Assert.NotNull(ex.Message);
        }

        [TestCase("")]
        public void InnerException_Set_ShouldSucceed(string testArgument)
        {
            var innerException = new ArgumentNullException(testArgument);
            var ex = new UnableToCreatePaymentException(testArgument, innerException);
            Assert.NotNull(ex);
            Assert.AreEqual(innerException, ex.InnerException);
        }

        [TestCase("")]
        public void InnerExceptionAndMessage_Set_ShouldSucceed(string testArgument)
        {
            var testMessage = "Test Message";
            var innerException = new ArgumentNullException(testArgument);
            var ex = new UnableToCreatePaymentException(testMessage, innerException);
            Assert.NotNull(ex);
            Assert.AreEqual(innerException, ex.InnerException);
            Assert.AreEqual(testMessage, ex.Message);
        }
    }
}
