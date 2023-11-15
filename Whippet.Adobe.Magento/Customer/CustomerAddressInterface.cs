using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides information about a Magento customer's address.
    /// </summary>
    public class CustomerAddressInterface : IExtensionInterface, IExtensionAttributes<CustomerAddressExtensionInterface>, ICustomAttributes
    {
        /// <summary>
        /// Gets or sets the address ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public CustomerRegionInterface[] Addresses
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID.
        /// </summary>
        [JsonProperty("region_id")]
        public int RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID in ISO_3166-2 format.
        /// </summary>
        [JsonProperty("country_id")]
        public string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the street component of the address.
        /// </summary>
        [JsonProperty("street")]
        public string[] Street
        { get; set; }

        /// <summary>
        /// Gets or sets the company line of the address.
        /// </summary>
        [JsonProperty("company")]
        public string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number of the address.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the address.
        /// </summary>
        [JsonProperty("fax")]
        public string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        [JsonProperty("postcode")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        [JsonProperty("city")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or sets the first name component of the address.
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name component of the address.
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name component of the address.
        /// </summary>
        [JsonProperty("middlename")]
        public string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix component of the address.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix component of the address.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Value Added Tax (VAT) number of the address.
        /// </summary>
        [JsonProperty("vat_id")]
        public string VAT
        { get; set; }

        /// <summary>
        /// Specifies whether the address is the default shipping address.
        /// </summary>
        [JsonProperty("default_shipping")]
        public bool IsDefaultShipping
        { get; set; }

        /// <summary>
        /// Specifies whether the address is the default billing address.
        /// </summary>
        [JsonProperty("default_billing")]
        public bool IsDefaultBilling
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CustomerAddressExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Gets or sets custom attributes applied to the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttributeInterface[] CustomAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddressInterface"/> class with no arguments.
        /// </summary>
        public CustomerAddressInterface()
        { }
    }
}
