using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Interface that provides information about a Magento tax class.
    /// </summary>
    public class TaxRateInterface : IExtensionInterface, IExtensionAttributes<TaxRateExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the tax rate ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate's country ID.
        /// </summary>
        [JsonProperty("tax_country_id")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate's region ID.
        /// </summary>
        [JsonProperty("tax_region_id")]
        public int Region
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate's region name.
        /// </summary>
        [JsonProperty("region_name")]
        public string RegionName
        { get; set; }
            
        /// <summary>
        /// Gets or sets the tax rate's postal code.
        /// </summary>
        [JsonProperty("tax_postcode")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Flag that indicates whether <see cref="PostalCode"/> is a ZIP code and should be treated as a range with <see cref="PostalCodeFrom"/> and <see cref="PostalCodeTo"/>. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("zip_is_range")]
        public int PostalCodeIsRange
        { get; set; }

        /// <summary>
        /// Lower bound ZIP code value.
        /// </summary>
        [JsonProperty("zip_from")]
        public int PostalCodeFrom
        { get; set; }

        /// <summary>
        /// Upper bound ZIP code value.
        /// </summary>
        [JsonProperty("zip_to")]
        public int PostalCodeTo
        { get; set; }

        /// <summary>
        /// Gets or sets the tax percentage rate.
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate titles.
        /// </summary>
        [JsonProperty("titles")]
        public TaxRateTitleInterface[] Titles
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance. 
        /// </summary>
        [JsonProperty("extension_attributes")]
        public TaxRateExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateInterface"/> class with no arguments.
        /// </summary>
        public TaxRateInterface()
        { }
    }
}
