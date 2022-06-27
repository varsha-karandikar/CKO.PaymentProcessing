using CKO.PaymentGateway.Contracts.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKO.PaymentGateway.Contracts
{
    public  class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(DateTime.UtcNow.Year).WithMessage("Expiration year should be equal to or greater than current year");
            RuleFor(x => x.MerchantId).Must(val => Int32.TryParse(val, out var value) && value >= 0).WithMessage("MerchantId cannot be zero or negative value");
            RuleFor(x => x.CardNumber).CreditCard().WithMessage("Credit card Number is not valid");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than zero");

        }

    }
}
