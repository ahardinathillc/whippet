using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Addressing;
using Athi.Whippet.Adobe.Magento.Store;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an individual customer in Magento.
    /// </summary>
    public interface ICustomer : IMagentoEntity, IEqualityComparer<ICustomer>, IMagentoRestEntity, IMagentoAuditableEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="ICustomerGroup"/> for the current instance.
        /// </summary>
        ICustomerGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's default billing address.
        /// </summary>
        ICustomerAddress DefaultBilling
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's default shipping address.
        /// </summary>
        ICustomerAddress DefaultShipping
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer confirmation number.
        /// </summary>
        string ConfirmationNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the area in which the <see cref="ICustomer"/> was created.
        /// </summary>
        string CreatedArea
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        LocalDate? DateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the user's e-mail address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the Magento attribute ID of the <see cref="ICustomer"/> object's gender.
        /// </summary>
        int? Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the <see cref="ICustomer"/> object belongs to.
        /// </summary>
        IStore Store
        { get; set; }

        
    }
}
