using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Store
{
    /// <summary>
    /// Interface that provides information about a Magento store.
    /// </summary>
    public class StoreConfigurationInterface : IExtensionInterface, IExtensionAttributes<StoreConfigurationExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the website ID.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the store locale.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code of the store.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the default display currency code.
        /// </summary>
        [JsonProperty("default_display_currency_code")]
        public string DefaultDisplayCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the timezone of the store.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone
        { get; set; }

        /// <summary>
        /// Gets or sets the unit of weight used in the store.
        /// </summary>
        [JsonProperty("weight_unit")]
        public string WeightUnit
        { get; set; }

        /// <summary>
        /// Gets or sets the base URL of the store.
        /// </summary>
        [JsonProperty("base_url")]
        public string URL
        { get; set; }

        /// <summary>
        /// Gets or sets the base link URL of the store.
        /// </summary>
        [JsonProperty("base_link_url")]
        public string LinkURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base static URL of the store.
        /// </summary>
        [JsonProperty("base_static_url")]
        public string StaticURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base media URL of the store.
        /// </summary>
        [JsonProperty("base_media_url")]
        public string MediaURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base secure URL of the store.
        /// </summary>
        [JsonProperty("secure_base_url")]
        public string SecureURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base secure link URL of the store.
        /// </summary>
        [JsonProperty("secure_base_link_url")]
        public string SecureLinkURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base secure static URL of the store.
        /// </summary>
        [JsonProperty("secure_static_url")]
        public string SecureStaticURL
        { get; set; }

        /// <summary>
        /// Gets or sets the base secure media URL of the store.
        /// </summary>
        [JsonProperty("secure_base_media_url")]
        public string SecureMediaURL
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StoreConfigurationExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreConfigurationInterface"/> class with no arguments.
        /// </summary>
        public StoreConfigurationInterface()
        { }
    }
}
