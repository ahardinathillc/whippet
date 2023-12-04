using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Customer.Addressing;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;

namespace Athi.Whippet.Adobe.Magento.Sales.Addressing
{
    /// <summary>
    /// Represents an address for an <see cref="ISalesOrder"/>.
    /// </summary>
    public interface ISalesOrderAddress : IMagentoEntity, IEqualityComparer<ISalesOrderAddress>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="ISalesOrder"/> associated with the address.
        /// </summary>
        ISalesOrder Parent
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address associated with the order address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the parent customer address.
        /// </summary>
        ICustomerAddress CustomerAddress
        { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> address.
        /// </summary>
        IRegion Region
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> address.
        /// </summary>
        ICountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the street address portion address.
        /// </summary>
        IEnumerable<string> Street
        { get; set; }
        
        /// <summary>
        /// Gets or sets the company line address.
        /// </summary>
        string Company
        { get; set; }
        
        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        string Telephone
        { get; set; }
        
        /// <summary>
        /// Gets or sets the facsimile number associated with the address.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of the recipient.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name of the recipient.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the recipient.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the recipient.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix of the recipient.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Value Added Tax (VAT) identification number of the address.
        /// </summary>
        string VAT
        { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VAT"/> value is valid.
        /// </summary>
        bool ValueAddedTaxIsValid
        { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request date.
        /// </summary>
        LocalDate? ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="VAT"/> request ID.
        /// </summary>
        string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="VAT"/> request was successful.
        /// </summary>
        bool ValueAddedTaxSuccessfullyRequested
        { get; set; }
    }
}
