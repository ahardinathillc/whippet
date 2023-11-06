using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an <see cref="ICustomer"/> address entity.
    /// </summary>
    public interface ICustomerAddress : IMagentoEntity, IEqualityComparer<ICustomerAddress>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ICustomerAddress"/>.
        /// </summary>
        uint EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Gets or sets the company portion of the address.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID. Countries are defined in Magento configuration.
        /// </summary>
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets the date/time the entity was created.
        /// </summary>
        Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the fax number associated with the address.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name portion of the address.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID that is applied to the entity to distinguish its unique row.
        /// </summary>
        string IncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the last name portion of the address.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name portion of the address.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that the <see cref="ICustomerAddress"/> belongs to.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the customer name.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the region name. Regions are defined in Magento configuration.
        /// </summary>
        string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. Regions are defined in Magento configuration.
        /// </summary>
        uint RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix portion of the customer name.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the address was last updated.
        /// </summary>
        Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or setes the VAT ID.
        /// </summary>
        string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT number is valid.
        /// </summary>
        bool? ValueAddedTaxValid
        { get; set; }

        /// <summary>
        /// Gets or sets the request date of the VAT number.
        /// </summary>
        string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT request ID.
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

