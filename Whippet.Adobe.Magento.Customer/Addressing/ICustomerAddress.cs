using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory;

namespace Athi.Whippet.Adobe.Magento.Customer.Addressing
{
    /// <summary>
    /// Represents an <see cref="ICustomer"/> address entity.
    /// </summary>
    public interface ICustomerAddress : IMagentoEntity, IEqualityComparer<ICustomerAddress>, IMagentoRestEntity, IMagentoCustomAttributesEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> associated with the address.
        /// </summary>
        ICustomer Parent
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
        /// Specifies whether the address is the default shipping address.
        /// </summary>
        bool IsDefaultShipping
        { get; set; }

        /// <summary>
        /// Specifies whether the address is the default billing address.
        /// </summary>
        bool IsDefaultBilling
        { get; set; }
    }
}
