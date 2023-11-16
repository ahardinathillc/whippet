using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Payments.Vault
{
    /// <summary>
    /// Interface that represents the gateway vault payment token information in Magento.
    /// </summary>
    public class PaymentVaultTokenInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")] 
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the public hash value.
        /// </summary>
        [JsonProperty("public_hash")]
        public string PublicHash
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method code.
        /// </summary>
        [JsonProperty("payment_method_code")]
        public string PaymentMethodCode
        { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the token expires.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt
        { get; set; }

        /// <summary>
        /// Gets or sets the gateway token ID.
        /// </summary>
        [JsonProperty("gateway_token")]
        public string GatewayToken
        { get; set; }

        /// <summary>
        /// Gets or sets the token details.
        /// </summary>
        [JsonProperty("token_details")]
        public string TokenDetails
        { get; set; }

        /// <summary>
        /// Specifies whether the token is active.
        /// </summary>
        [JsonProperty("is_active")]
        public bool Active
        { get; set; }

        /// <summary>
        /// Specifies whether the token is currently visible.
        /// </summary>
        [JsonProperty("is_visible")]
        public bool Visible
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentVaultTokenInterface"/> class with no arguments.
        /// </summary>
        public PaymentVaultTokenInterface()
        { }
    }
}
