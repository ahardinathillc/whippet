using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an individual customer in Magento.
    /// </summary>
    public interface ICustomer : IMagentoEntity, IEqualityComparer<ICustomer>
    {
        /// <summary>
        /// Gets or sets the unique customer ID.
        /// </summary>
        uint EntityID
        { get; set; }

        /// <summary>
        /// Gets or setes the confirmation code for the customer account.
        /// </summary>
        string Confirmation
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer was created.
        /// </summary>
        Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the environment in which the <see cref="ICustomer"/> was created.
        /// </summary>
        string CreatedIn
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomerAddress"/> that is the default billing address.
        /// </summary>
        ICustomerAddress DefaultBillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomerAddress"/> that is the default shipping address.
        /// </summary>
        ICustomerAddress DefaultShippingAddress
        { get; set; }

        /// <summary>
        /// Indicates whether auto group changing is disabled.
        /// </summary>
        bool DisableAutoGroupChange
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        Instant? DateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of failed login attempts.
        /// </summary>
        short? FailedLoginAttempts
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the first failed login attempt was captured.
        /// </summary>
        Instant? FirstFailedLoginAttempt
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the gender code for the customer. Gender codes are defined in Magento configuration.
        /// </summary>
        ushort? Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        ICustomerGroup Group
        { get; set; }

        /// <summary>
        /// Gets or sets the unique increment ID that identifies the row.
        /// </summary>
        string IncrementID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is currently active.
        /// </summary>
        bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the legacy customer ID (if any).
        /// </summary>
        int? LegacyCustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer's account lock expires.
        /// </summary>
        Instant? LockExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password hash code.
        /// </summary>
        string PasswordHash
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password reset token.
        /// </summary>
        string ResetPasswordToken
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer's password reset token was created.
        /// </summary>
        Instant? ResetPasswordTokenCreated
        { get; set; }

        /// <summary>
        /// Gets or sets the session expiration date/time for the customer.
        /// </summary>
        Instant? SessionCutoff
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's associated store.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        string ValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last updated.
        /// </summary>
        Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's associated store website.
        /// </summary>
        IStoreWebsite Website
        { get; set; }
    }
}

