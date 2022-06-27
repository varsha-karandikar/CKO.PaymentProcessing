using CKO.PaymentGateway.Contracts.MerchantAuthentication;
using CKO.PaymentGateway.MerchantAuthentication.Repositories;

namespace CKO.PaymentGateway.MerchantAuthentication
{
    public class MerchantAuthenticationService : IMerchantAuthenticationService
    {
        public Merchant Get(MerchantLogin merchantLogin)
        {
            Merchant merchant = MerchantRepository.Merchants.FirstOrDefault(m => m.MerchantId.Equals(merchantLogin.MerchantId, StringComparison.OrdinalIgnoreCase)
            && m.Secret.Equals(merchantLogin.Secret, StringComparison.OrdinalIgnoreCase));

            return merchant;
        }
    }
}
