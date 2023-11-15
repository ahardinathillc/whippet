using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Interface that provides information about a Magento customer.
    /// </summary>
    public class CustomerInterface : IExtensionInterface, IExtensionAttributes<CustomerExtensionInterface>, ICustomAttributes
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's group ID.
        /// </summary>
        [JsonProperty("group_id")]
        public int GroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's default billing address ID.
        /// </summary>
        [JsonProperty("default_billing")]
        public string DefaultBillingAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's default shipping address ID.
        /// </summary>
        [JsonProperty("default_shipping")]
        public string DefaultShippingAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's confirmation number.
        /// </summary>
        [JsonProperty("confirmation")]
        public string Confirmation
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the customer was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the customer was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the area where the customer was created.
        /// </summary>
        [JsonProperty("created_in")]
        public string CreatedIn
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's full date of birth.
        /// </summary>
        /// <remarks>In keeping with current security and privacy best practices, be sure you are aware of any potential legal and security risks associated with the storage of customers’ full date of birth (month, day, year) along with other personal identifiers (e.g., full name) before collecting or processing such data.</remarks>
        [JsonProperty("dob")]
        public string DateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's gender.
        /// </summary>
        [JsonProperty("gender")]
        public int Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the store ID the customer is associated with.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's Value Added Tax (VAT) number.
        /// </summary>
        [JsonProperty("taxvat")]
        public string VAT
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's website ID.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the addresses associated with the customer.
        /// </summary>
        [JsonProperty("addresses")]
        public CustomerAddressInterface[] Addresses
        { get; set; }

        /// <summary>
        /// Flag that disables auto group change flag. Value is <see langword="true"/> if it is greater than zero; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("disable_auto_group_change")]
        public int DisableAutoGroupChange
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CustomerExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom attributes applied to the current instance.
        /// </summary>
        [JsonProperty("custom_attributes")]
        public CustomAttributeInterface[] CustomAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerInterface"/> class with no arguments.
        /// </summary>
        public CustomerInterface()
        { }
    }
}
