using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents an individual customer in Magento.
    /// </summary>
    public class Customer : MagentoEntity, IMagentoEntity, ICustomer, IEqualityComparer<ICustomer>, IWhippetActiveEntity
    {
        private CustomerAddress _defaultBilling;
        private CustomerAddress _defaultShipping;
        private CustomerGroup _group;

        private Store _store;
        private StoreWebsite _website;

        /// <summary>
        /// Gets or sets the unique customer ID.
        /// </summary>
        public virtual uint EntityID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets or setes the confirmation code for the customer account.
        /// </summary>
        public virtual string Confirmation
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer was created.
        /// </summary>
        public virtual Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the environment in which the <see cref="Customer"/> was created.
        /// </summary>
        public virtual string CreatedIn
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CustomerAddress"/> that is the default billing address.
        /// </summary>
        public virtual CustomerAddress DefaultBillingAddress
        {
            get
            {
                if (_defaultBilling == null)
                {
                    _defaultBilling = new CustomerAddress();
                }

                return _defaultBilling;
            }
            set
            {
                _defaultBilling = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CustomerAddress"/> that is the default billing address.
        /// </summary>
        ICustomerAddress ICustomer.DefaultBillingAddress
        {
            get
            {
                return DefaultBillingAddress;
            }
            set
            {
                DefaultBillingAddress = value.ToCustomerAddress();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CustomerAddress"/> that is the default shipping address.
        /// </summary>
        public virtual CustomerAddress DefaultShippingAddress
        {
            get
            {
                if (_defaultShipping == null)
                {
                    _defaultShipping = new CustomerAddress();
                }

                return _defaultShipping;
            }
            set
            {
                _defaultShipping = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CustomerAddress"/> that is the default shipping address.
        /// </summary>
        ICustomerAddress ICustomer.DefaultShippingAddress
        {
            get
            {
                return DefaultShippingAddress;
            }
            set
            {
                DefaultShippingAddress = value.ToCustomerAddress();
            }
        }

        /// <summary>
        /// Indicates whether auto group changing is disabled.
        /// </summary>
        public virtual bool DisableAutoGroupChange
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        public virtual Instant? DateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of failed login attempts.
        /// </summary>
        public virtual short? FailedLoginAttempts
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the first failed login attempt was captured.
        /// </summary>
        public virtual Instant? FirstFailedLoginAttempt
        { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the gender code for the customer. Gender codes are defined in Magento configuration.
        /// </summary>
        public virtual ushort? Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        public virtual CustomerGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new CustomerGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        ICustomerGroup ICustomer.Group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value.ToCustomerGroup();
            }
        }

        /// <summary>
        /// Gets or sets the unique increment ID that identifies the row.
        /// </summary>
        public virtual string IncrementID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the legacy customer ID (if any).
        /// </summary>
        public virtual int? LegacyCustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer's account lock expires.
        /// </summary>
        public virtual Instant? LockExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password hash code.
        /// </summary>
        public virtual string PasswordHash
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password reset token.
        /// </summary>
        public virtual string ResetPasswordToken
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer's password reset token was created.
        /// </summary>
        public virtual Instant? ResetPasswordTokenCreated
        { get; set; }

        /// <summary>
        /// Gets or sets the session expiration date/time for the customer.
        /// </summary>
        public virtual Instant? SessionCutoff
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's associated store.
        /// </summary>
        public virtual Store Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's associated store.
        /// </summary>
        IStore ICustomer.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
            }
        }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        public virtual string ValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last updated.
        /// </summary>
        public virtual Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's associated store website.
        /// </summary>
        public virtual StoreWebsite Website
        {
            get
            {
                if (_website == null)
                {
                    _website = new StoreWebsite();
                }

                return _website;
            }
            set
            {
                _website = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's associated store website.
        /// </summary>
        IStoreWebsite ICustomer.Website
        {
            get
            {
                return Website;
            }
            set
            {
                Website = value.ToStoreWebsite();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with no arguments.
        /// </summary>
        public Customer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified address ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public Customer(uint customerId, MagentoServer server)
            : base(customerId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ICustomer)) ? false : Equals(obj as ICustomer);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer x, ICustomer y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Active == y.Active
                    && String.Equals(x.Confirmation, y.Confirmation, StringComparison.InvariantCultureIgnoreCase)
                    && x.CreatedAt.Equals(y.CreatedAt)
                    && String.Equals(x.CreatedIn, y.CreatedIn, StringComparison.InvariantCultureIgnoreCase)
                    && x.DateOfBirth.GetValueOrDefault().Equals(y.DateOfBirth.GetValueOrDefault())
                    && ((x.DefaultBillingAddress == null && y.DefaultBillingAddress == null) || (x.DefaultBillingAddress != null && x.DefaultBillingAddress.Equals(y.DefaultBillingAddress)))
                    && ((x.DefaultShippingAddress == null && y.DefaultShippingAddress == null) || (x.DefaultShippingAddress != null && x.DefaultShippingAddress.Equals(y.DefaultShippingAddress)))
                    && x.DisableAutoGroupChange == y.DisableAutoGroupChange
                    && String.Equals(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase)
                    && x.FailedLoginAttempts.GetValueOrDefault().Equals(y.FailedLoginAttempts.GetValueOrDefault())
                    && x.FirstFailedLoginAttempt.GetValueOrDefault().Equals(y.FirstFailedLoginAttempt.GetValueOrDefault())
                    && String.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && x.Gender.GetValueOrDefault().Equals(y.Gender.GetValueOrDefault())
                    && ((x.Group == null && y.Group == null) || (x.Group != null && x.Group.Equals(y.Group)))
                    && String.Equals(x.IncrementID, y.IncrementID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && x.LegacyCustomerNumber.GetValueOrDefault().Equals(y.LegacyCustomerNumber.GetValueOrDefault())
                    && x.LockExpiration.GetValueOrDefault().Equals(y.LockExpiration.GetValueOrDefault())
                    && String.Equals(x.MiddleName, y.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.PasswordHash, y.PasswordHash, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Prefix, y.Prefix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ResetPasswordToken, y.ResetPasswordToken, StringComparison.InvariantCultureIgnoreCase)
                    && x.ResetPasswordTokenCreated.GetValueOrDefault().Equals(y.ResetPasswordTokenCreated.GetValueOrDefault())
                    && x.SessionCutoff.GetValueOrDefault().Equals(y.SessionCutoff.GetValueOrDefault())
                    && ((x.Store == null && y.Store == null) || (x.Store != null && x.Store.Equals(y.Store)))
                    && String.Equals(x.Suffix, y.Suffix, StringComparison.InvariantCultureIgnoreCase)
                    && x.UpdatedAt.Equals(y.UpdatedAt)
                    && String.Equals(x.ValueAddedTax, y.ValueAddedTax, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Website == null && y.Website == null) || (x.Website != null && x.Website.Equals(y.Website)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ICustomer"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomer obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(LastName))
            {
                builder.Append(LastName);

                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    builder.Append(", ");
                }
            }

            if (!String.IsNullOrWhiteSpace(FirstName))
            {
                builder.Append(FirstName);

                if (!String.IsNullOrWhiteSpace(MiddleName))
                {
                    builder.Append(' ');
                }
            }

            if (!String.IsNullOrWhiteSpace(MiddleName))
            {
                builder.Append(MiddleName);
            }

            if (!String.IsNullOrWhiteSpace(builder.ToString()) && !String.IsNullOrWhiteSpace(Email))
            {
                builder.Append(" [");
                builder.Append(Email);
                builder.Append("]");
            }
            else if (!String.IsNullOrWhiteSpace(Email))
            {
                builder.Append(Email);
            }

            if (String.IsNullOrWhiteSpace(builder.ToString()))
            {
                builder = new StringBuilder(base.ToString());
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

