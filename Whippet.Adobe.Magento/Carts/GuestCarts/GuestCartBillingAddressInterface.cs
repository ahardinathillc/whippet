using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts.GuestCarts
{
    /// <summary>
    /// Interface that provides information about a Magento cart's billing address.
    /// </summary>
    public class GuestCartBillingAddressInterface : IExtensionInterface, IExtensionAttributes<CartAddressExtensionInterface>, ICustomAttributes
    {
        /// <summary>
        /// Gets or sets the ID of the cart billing address.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        [JsonProperty("region")]
        public string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID.
        /// </summary>
        [JsonProperty("region_id")]
        public int RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        [JsonProperty("region_code")]
        public string RegionCode
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID.
        /// </summary>
        [JsonProperty("country_id")]
        public string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the street components of the address.
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
        /// Gets or sets the telephone number.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the facsimile number.
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
        /// Gets or sets the first name of the recipient.
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name of the recipient.
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the recipient.
        /// </summary>
        [JsonProperty("middlename")]
        public string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the recipient.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix of the recipient.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Value Added Tax (VAT) number.
        /// </summary>
        [JsonProperty("vat_id")]
        public string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the billing/shipping e-mail address.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the address is the same as the billing address where any number greater than zero (0) is <see langword="true"/>.
        /// </summary>
        [JsonProperty("same_as_billing")]
        public int SameAsBilling
        { get; set; }

        /// <summary>
        /// Gets or sets the customer address ID.
        /// </summary>
        [JsonProperty("customer_address_id")]
        public int CustomerAddressID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the address to be saved in the address book where any number greater than zero (0) is <see langword="true"/>.
        /// </summary>
        [JsonProperty("save_in_address_book")]
        public int SaveInAddressBook
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartAddressExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes of the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttributeInterface[] CustomAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartBillingAddressInterface"/> class with no arguments.
        /// </summary>
        public GuestCartBillingAddressInterface()
        { }
    }
}
