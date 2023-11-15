using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides information about a Magento customer's company.
    /// </summary>
    public class CustomerCompanyInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        [JsonProperty("company_id")]
        public int CompanyID
        { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle
        { get; set; }

        /// <summary>
        /// Gets or sets the customer status.
        /// </summary>
        [JsonProperty("status")]
        public int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the customer telephone.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CustomerCompanyExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyInterface"/> class with no arguments.
        /// </summary>
        public CustomerCompanyInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCompanyInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="companyId">Company ID.</param>
        /// <param name="jobTitle">Job title.</param>
        /// <param name="status">Customer status.</param>
        /// <param name="telephone">Customer telephone.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CustomerCompanyInterface(int customerId, int companyId, string jobTitle, int status, string telephone, CustomerCompanyExtensionInterface extensionAttributes)
            : this()
        {
            CustomerID = customerId;
            CompanyID = companyId;
            JobTitle = jobTitle;
            Status = status;
            Telephone = telephone;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
