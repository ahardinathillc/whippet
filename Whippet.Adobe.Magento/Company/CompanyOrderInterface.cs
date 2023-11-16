using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Interface that provides company attributes to sales orders in Magento.
    /// </summary>
    public class CompanyOrderInterface : IExtensionInterface, IExtensionAttributes<CompanyOrderExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        [JsonProperty("order_id")]
        public int OrderID
        { get; set; }

        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        [JsonProperty("company_id")]
        public int CompanyID
        { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current object.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CompanyOrderExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyOrderInterface"/> class with no arguments.
        /// </summary>
        public CompanyOrderInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyOrderInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="companyId">Company ID.</param>
        /// <param name="companyName">Company name.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CompanyOrderInterface(int orderId, int companyId, string companyName, CompanyOrderExtensionInterface extensionAttributes)
            : this()
        {
            OrderID = orderId;
            CompanyID = companyId;
            CompanyName = companyName;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
