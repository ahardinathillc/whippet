using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Vault
{
    /// <summary>
    /// Represents a gateway payment token in Magento.
    /// </summary>
    public interface IVaultPaymentToken : IMagentoEntity, IEqualityComparer<IVaultPaymentToken>, IMagentoRestEntity, IMagentoRestEntity<VaultPaymentTokenInterface>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the customer associated with the payment token.
        /// </summary>
        ICustomer Customer
        { get; set; }
        
        /// <summary>
        /// Gets or sets the hash value.
        /// </summary>
        string PublicHash
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method code.
        /// </summary>
        string PaymentMethodCode
        { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token was created.
        /// </summary>
        Instant? CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token expires.
        /// </summary>
        Instant? ExpiresTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the gateway token ID.
        /// </summary>
        string GatewayToken
        { get; set; }

        /// <summary>
        /// Gets or sets the token details.
        /// </summary>
        string TokenDetails
        { get; set; }

        /// <summary>
        /// Specifies whether the token is active.
        /// </summary>
        bool Active
        { get; set; }

        /// <summary>
        /// Specifies whether the token is currently visible.
        /// </summary>
        bool Visible
        { get; set; }        
    }
}
