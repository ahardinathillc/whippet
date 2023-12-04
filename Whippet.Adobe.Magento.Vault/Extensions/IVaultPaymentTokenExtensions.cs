using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Vault.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IVaultPaymentToken"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IVaultPaymentTokenExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IVaultPaymentToken"/> object to a <see cref="VaultPaymentToken"/> object.
        /// </summary>
        /// <param name="token"><see cref="IVaultPaymentToken"/> object to convert.</param>
        /// <returns><see cref="VaultPaymentToken"/> object.</returns>
        public static VaultPaymentToken ToVaultPaymentToken(this IVaultPaymentToken token)
        {
            VaultPaymentToken vpt = null;

            if (token is VaultPaymentToken)
            {
                vpt = (VaultPaymentToken)(token);
            }
            else if (token != null)
            {
                vpt = new VaultPaymentToken();
                vpt.ID = token.ID;
                vpt.Active = token.Active;
                vpt.Customer = token.Customer.ToCustomer();
                vpt.Type = token.Type;
                vpt.Visible = token.Visible;
                vpt.CreatedTimestamp = token.CreatedTimestamp;
                vpt.ExpiresTimestamp = token.ExpiresTimestamp;
                vpt.GatewayToken = token.GatewayToken;
                vpt.PublicHash = token.PublicHash;
                vpt.TokenDetails = token.TokenDetails;
                vpt.PaymentMethodCode = token.PaymentMethodCode;
                vpt.Server = token.Server.ToMagentoServer();
                vpt.RestEndpoint = token.RestEndpoint.ToMagentoRestEndpoint();
            }

            return vpt;
        }
    }
}
