using CKO.PaymentGateway.Contracts.MerchantAuthentication;

namespace CKO.PaymentGateway.API.Services
{
    public interface IMerchantAuthenticationService
    {
        public Merchant Get(MerchantLogin merchantLogin);

    }
}
