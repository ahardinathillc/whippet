using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Company
{
    /// <summary>
    /// Interface that provides information about a company in Magento.
    /// </summary>
    public class CompanyInterface : IExtensionInterface, IExtensionAttributes<CompanyExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the unique ID of the company.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the company's status code.
        /// </summary>
        [JsonProperty("status")]
        public int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [JsonProperty("company_name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the company's legal name.
        /// </summary>
        [JsonProperty("legal_name")]
        public string LegalName
        { get; set; }

        /// <summary>
        /// Gets or sets the company's e-mail address.
        /// </summary>
        [JsonProperty("company_email")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the company's Value Added Tax (VAT) number.
        /// </summary>
        [JsonProperty("vat_tax_id")]
        public string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the company's reseller ID number.
        /// </summary>
        [JsonProperty("reseller_id")]
        public string ResellerID
        { get; set; }

        /// <summary>
        /// Gets or sets the comment for the company.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the company's address.
        /// </summary>
        [JsonProperty("street")]
        public string[] Street
        { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the company's address.
        /// </summary>
        [JsonProperty("city")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID of the company's address.
        /// </summary>
        [JsonProperty("country_id")]
        public string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the region of the company's address.
        /// </summary>
        [JsonProperty("region")]
        public string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID of the company's address.
        /// </summary>
        [JsonProperty("region_id")]
        public string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the company's address.
        /// </summary>
        [JsonProperty("postcode")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone associated with the company's address.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group ID the company belongs to.
        /// </summary>
        [JsonProperty("customer_group_id")]
        public int CustomerGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID of the designated sales representative.
        /// </summary>
        [JsonProperty("sales_representative_id")]
        public int SalesRepresentativeID
        { get; set; }

        /// <summary>
        /// Gets or sets the reason for the company's rejection.
        /// </summary>
        [JsonProperty("reject_reason")]
        public string RejectReason
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the company was rejected.
        /// </summary>
        [JsonProperty("rejected_at")]
        public string RejectedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID of the designated company administrator.
        /// </summary>
        [JsonProperty("super_user_id")]
        public int AdministratorID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CompanyExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyInterface"/> class with no arguments.
        /// </summary>
        public CompanyInterface()
        { }
    }
}
