using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.SalesRule;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Provides information about a Magento customer's address that is associated with a cart.  
    /// </summary>
    public class CartAddressInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the ID of the 
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
        /// Gets or sets one or more <see cref="String"/> values that comprise the street address.
        /// </summary>
        [JsonProperty("street")]
        public string[] Street
        { get; set; }

        /// <summary>
        /// Gets or sets the company address line.
        /// </summary>
        [JsonProperty("company")]
        public string Company
        { get; set; }
        
        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the fax number associated with the address.
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
        /// Gets or sets the city of the address.
        /// </summary>
        [JsonProperty("city")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's first name.
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's middle name.
        /// </summary>
        [JsonProperty("middlename")]
        public string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's last name.
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's prefix.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient's suffix.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Billing/shipping e-mail address associated with the address.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the shipping address is the same as the billing address. Any value that is not zero (0) is considered <see langword="true"/>. 
        /// </summary>
        [JsonProperty("same_as_billing")]
        public int SameAsBilling
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's address ID.
        /// </summary>
        [JsonProperty("customer_address_id")]
        public int CustomerAddressID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the shipping address should be saved in the customer's address book. Any value that is not zero (0) is considered <see langword="true"/>. 
        /// </summary>
        [JsonProperty("save_in_address_book")]
        public int SaveInAddressBook
        { get; set; }

        /// <summary>
        /// Gets or sets extension data that is applied to the Magento object.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartAddressExtensionDataInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom attributes that are applied to the Magento object.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttribute[] CustomAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartAddressInterface"/> class with no arguments.
        /// </summary>
        public CartAddressInterface()
        { }
    }
}
