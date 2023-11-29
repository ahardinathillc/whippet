using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Provides information about a company's quote configuration in Magento.
    /// </summary>
    public class CompanyQuoteConfigurationInterface : IExtensionInterface, IExtensionAttributes<CompanyQuoteConfigurationExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the company ID to which the configuration applies.
        /// </summary>
        [JsonProperty("company_id")]
        public string CompanyID
        { get; set; }

        /// <summary>
        /// Specifies whether quotes are enabled for the company.
        /// </summary>
        [JsonProperty("is_quote_enabled")]
        public bool QuotesEnabled
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CompanyQuoteConfigurationExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyQuoteConfigurationInterface"/> class with no arguments.
        /// </summary>
        public CompanyQuoteConfigurationInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyQuoteConfigurationInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="companyId">Company ID.</param>
        /// <param name="quotesEnabled">Specifies whether quotes are enabled for the company.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CompanyQuoteConfigurationInterface(string companyId, bool quotesEnabled, CompanyQuoteConfigurationExtensionInterface extensionAttributes)
            : this()
        {
            CompanyID = companyId;
            QuotesEnabled = quotesEnabled;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
