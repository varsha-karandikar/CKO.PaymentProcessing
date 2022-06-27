using CKO.PaymentGateway.API.Repositories;
using CKO.PaymentGateway.Contracts.MerchantAuthentication;

namespace CKO.PaymentGateway.API.Services
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
