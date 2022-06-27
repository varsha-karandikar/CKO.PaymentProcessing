using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using CKO.PaymentGateway.API.Controllers;
using CKO.PaymentGateway.API.Services;
using CKO.PaymentGateway.Contracts.DTO;
using CKO.PaymentGateway.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using CKO.BankSimulator.Exceptions;

namespace CKO.PaymentGateway.API.Tests.Controllers
{
    [TestFixture]
    internal class PaymentControllerTests
    {
        [Test]
        public async Task CreatePayment_ValidRequest_ShouldSucceed()
        {
            var mockRequest = new Mock<HttpRequest>();
            var mockProcessingService = new Mock<IPaymentProcessingService>();
            var paymentApi = new PaymentController(mockProcessingService.Object);

            var paymentRequest = new PaymentRequest()
            {
                MerchantId = "1001",
                CardNumber = "5521370103998437",
                ExpirationMonth = 12,
                ExpirationYear = 2025,
                CurrencyCode = "USD",
                Amount = 5
            };


            var expectedPaymentResponse = new PaymentResponse()
            {
                Id = 1,
                CurrencyCode = "USD",
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    PaymentStatus = Enum.GetName(PaymentStatus.Approved)
                }
            };

            mockProcessingService.Setup(x => x.CreatePaymentAsync(paymentRequest)).ReturnsAsync(expectedPaymentResponse);

            var result = (ObjectResult) await paymentApi.Create(paymentRequest);
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
            Assert.AreEqual(expectedPaymentResponse.GetType(), result.Value.GetType());

        }

        [Test]
        public async Task CreatePayment_InValidRequest_ShouldReturnBadResult()
        {
            var mockRequest = new Mock<HttpRequest>();
            var mockProcessingService = new Mock<IPaymentProcessingService>();
            var paymentApi = new PaymentController(mockProcessingService.Object);

            var paymentRequest = new PaymentRequest()
            {
                MerchantId = "1001",
                CardNumber = "5521370103998437",
                ExpirationMonth = 12,
                ExpirationYear = 2020,
                CurrencyCode = "USD",
                Amount = 5
            };


            var expectedPaymentResponse = new PaymentResponse()
            {
                Id = 1,
                CurrencyCode = "USD",
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    PaymentStatus = Enum.GetName(PaymentStatus.Approved)
                }
            };

            mockProcessingService.Setup(x => x.CreatePaymentAsync(paymentRequest)).ReturnsAsync(expectedPaymentResponse);

            var result = (ObjectResult)await paymentApi.Create(paymentRequest);
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public async Task CreatePayment_ValidRequest_Fails_ReturnsServerError()
        {
            var mockRequest = new Mock<HttpRequest>();
            var mockProcessingService = new Mock<IPaymentProcessingService>();
            var paymentApi = new PaymentController(mockProcessingService.Object);

            var paymentRequest = new PaymentRequest()
            {
                MerchantId = "1001",
                CardNumber = "5521370103998437",
                ExpirationMonth = 12,
                ExpirationYear = 2025,
                CurrencyCode = "USD",
                Amount = 5
            };

            mockProcessingService.Setup(x => x.CreatePaymentAsync(paymentRequest)).ThrowsAsync(new UnableToCreatePaymentException("Could not save payment details"));

            var result = (ObjectResult)await paymentApi.Create(paymentRequest);
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Test]
        public async Task GetPayment_ValidRequest_Fails_ReturnsServerError()
        {
            var mockRequest = new Mock<HttpRequest>();
            var mockProcessingService = new Mock<IPaymentProcessingService>();
            var paymentApi = new PaymentController(mockProcessingService.Object);

            var paymentRequest = new PaymentRequest()
            {
                MerchantId = "1001",
                CardNumber = "5521370103998437",
                ExpirationMonth = 12,
                ExpirationYear = 2025,
                CurrencyCode = "USD",
                Amount = 5
            };
            var mockPaymentId = 1;

            mockProcessingService.Setup(x => x.GetPaymentResponseAsync(mockPaymentId)).ThrowsAsync(new UnableToRetrievePaymentException("Database error"));

            var result = (ObjectResult)await paymentApi.Get(mockPaymentId);
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Test]
        public async Task GetPayment_ValidRequest_ShouldSucceed()
        {
            var mockRequest = new Mock<HttpRequest>();
            var mockProcessingService = new Mock<IPaymentProcessingService>();
            var paymentApi = new PaymentController(mockProcessingService.Object);

            var expectedPaymentResponse = new PaymentResponse()
            {
                Id = 1,
                CurrencyCode = "USD",
                PaymentDetails = new Contracts.Models.PaymentDetails()
                {
                    PaymentStatus = Enum.GetName(PaymentStatus.Approved)
                }
            };
            var mockPaymentId = 1;

            mockProcessingService.Setup(x => x.GetPaymentResponseAsync(mockPaymentId)).ReturnsAsync(expectedPaymentResponse);

            var result = (ObjectResult)await paymentApi.Get(mockPaymentId);
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
