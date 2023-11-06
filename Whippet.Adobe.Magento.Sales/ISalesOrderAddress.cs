using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order address entry in Magento.
    /// </summary>
    public interface ISalesOrderAddress : IMagentoEntity, IEqualityComparer<ISalesOrderAddress>
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        uint EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        string AddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Gets or sets the address company.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the two-letter country ID.
        /// </summary>
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer address.
        /// </summary>
        ICustomerAddress CustomerAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail associated with the order address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the fax phone number associated with the order address.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name on the order address.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the gift registry item.
        /// </summary>
        int? GiftRegistryItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the last name on the order address.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name on the order address.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="SalesOrder"/> object.
        /// </summary>
        ISalesOrder Order
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the order address.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the name on the order address.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        IQuoteAddress QuoteAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the address region.
        /// </summary>
        string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. The region ID is stored in Magento configuration.
        /// </summary>
        string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the address telephone number.
        /// </summary>
        string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the validated VAT number for the customer.
        /// </summary>
        string ValidatedValueAddedTaxNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT ID.
        /// </summary>
        string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT supplied is valid.
        /// </summary>
        bool? ValueAddedTaxIsValid
        { get; set; }

        /// <summary>
        /// Gets or sets the date the VAT was requested.
        /// </summary>
        string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the VAT request.
        /// </summary>
        string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT request was successful.
        /// </summary>
        bool? ValueAddedTaxRequestSuccess
        { get; set; }
    }
}

