using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about an address associated with a Magento sales order.
    /// </summary>
    public class SalesOrderAddressInterface : IExtensionInterface, IExtensionAttributes<SalesOrderAddressExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        [JsonProperty("address_type")]
        public string AddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        [JsonProperty("city")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or sets the company line of the address.
        /// </summary>
        [JsonProperty("company")]
        public string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID of the address.
        /// </summary>
        [JsonProperty("country_id")]
        public string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer address ID.
        /// </summary>
        [JsonProperty("customer_address_id")]
        public int CustomerAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail associated with the address.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the order address ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the facsimile number for the address.
        /// </summary>
        public string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of the address.
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name of the address.
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the address.
        /// </summary>
        [JsonProperty("middlename")]
        public string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the parent ID.
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the address postal code.
        /// </summary>
        [JsonProperty("postcode")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the occupant at the address.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the address region.
        /// </summary>
        [JsonProperty("region")]
        public string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region code of the address.
        /// </summary>
        [JsonProperty("region_code")]
        public string RegionCode
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID.
        /// </summary>
        [JsonProperty("region_id")]
        public int RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the components that make up the street address.
        /// </summary>
        [JsonProperty("street")]
        public string[] Street
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix of the address occupant.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the Value Added Tax (VAT) number for the address.
        /// </summary>
        [JsonProperty("vat_id")]
        public string VAT
        { get; set; }

        /// <summary>
        /// Flag that specifies whether the value in <see cref="VAT"/> is valid. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("vat_is_valid")]
        public int ValueAddedTaxNumberValid
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request date.
        /// </summary>
        [JsonProperty("vat_request_date")]
        public string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request ID.
        /// </summary>
        [JsonProperty("vat_request_id")]
        public string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the requesting of a <see cref="VAT"/> number was successful. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("vat_request_success")]
        public int ValueAddedTaxRequestSuccess
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        public SalesOrderAddressExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddressInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderAddressInterface()
        { }
    }
}
