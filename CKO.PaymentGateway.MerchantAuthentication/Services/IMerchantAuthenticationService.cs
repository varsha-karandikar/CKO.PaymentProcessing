using CKO.PaymentGateway.Contracts.MerchantAuthentication;

namespace CKO.PaymentGateway.MerchantAuthentication
{
    public interface IMerchantAuthenticationService
    {
        public Merchant Get(MerchantLogin merchantLogin);

    }
}
