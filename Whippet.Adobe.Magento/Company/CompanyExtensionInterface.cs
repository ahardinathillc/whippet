using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Interface that provides extra information about a company in Magento.
    /// </summary>
    public class CompanyExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the applicable payment method ID.
        /// </summary>
        [JsonProperty("applicable_payment_method")]
        public int ApplicablePaymentMethod
        { get; set; }

        /// <summary>
        /// Gets or sets a list of available payment methods delimited by comma.
        /// </summary>
        [JsonProperty("available_payment_methods")]
        public string AvailablePaymentMethods
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the Magento configuration settings should be used instead of custom values for the company. Any value that is not zero (0) is considered <see langword="true"/>. 
        /// </summary>
        [JsonProperty("use_config_settings")]
        public int UseConfigurationSettings
        { get; set; }

        /// <summary>
        /// Gets or sets the company's quote configuration.
        /// </summary>
        [JsonProperty("quote_config")]
        public CompanyQuoteConfigurationInterface QuoteConfiguration
        { get; set; }

        /// <summary>
        /// Specifies whether purchase orders are enabled for the company.
        /// </summary>
        [JsonProperty("is_purchase_order_enabled")]
        public bool PurchaseOrdersEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the applicable shipping method ID.
        /// </summary>
        [JsonProperty("applicable_shipping_method")]
        public int ApplicableShippingMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the available shipping methods delimited by comma.
        /// </summary>
        [JsonProperty("available_shipping_methods")]
        public string AvailableShippingMethods
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the Magento configuration settings should be used instead of custom values for the company. Any value that is not zero (0) is considered <see langword="true"/>. 
        /// </summary>
        [JsonProperty("use_config_settings_shipping")]
        public int UseShippingConfigurationSettings
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyExtensionInterface"/> class with no arguments.
        /// </summary>
        public CompanyExtensionInterface()
        { }
    }
}
