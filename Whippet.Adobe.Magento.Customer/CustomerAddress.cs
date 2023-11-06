using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a <see cref="Magento.Customer.Customer"/> address entity.
    /// </summary>
    public class CustomerAddress : MagentoEntity, IMagentoEntity, ICustomerAddress, IEqualityComparer<ICustomerAddress>, IWhippetActiveEntity
    {
        private Customer _customer;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="CustomerAddress"/>.
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
        /// Gets or sets the city portion of the address.
        /// </summary>
        public virtual string City
        { get; set; }

        /// <summary>
        /// Gets or sets the company portion of the address.
        /// </summary>
        public virtual string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID. Countries are defined in Magento configuration.
        /// </summary>
        public virtual string CountryID
        { get; set; }

        /// <summary>
        /// Gets the date/time the entity was created.
        /// </summary>
        public virtual Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the fax number associated with the address.
        /// </summary>
        public virtual string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name portion of the address.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID that is applied to the entity to distinguish its unique row.
        /// </summary>
        public virtual string IncrementID
        { get; set; }

        /// <summary>
        /// Indicates whether the address is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the last name portion of the address.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name portion of the address.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Magento.Customer.Customer"/> that the <see cref="CustomerAddress"/> belongs to.
        /// </summary>
        public virtual Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new Customer();
                }

                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that the <see cref="ICustomerAddress"/> belongs to.
        /// </summary>
        ICustomer ICustomerAddress.Customer
        {
            get
            {
                return Customer;
            }
            set
            {
                Customer = value.ToCustomer();
            }
        }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the customer name.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the region name. Regions are defined in Magento configuration.
        /// </summary>
        public virtual string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. Regions are defined in Magento configuration.
        /// </summary>
        public virtual uint RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        public virtual string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the suffix portion of the customer name.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the telephone number associated with the address.
        /// </summary>
        public virtual string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the address was last updated.
        /// </summary>
        public virtual Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or setes the VAT ID.
        /// </summary>
        public virtual string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT number is valid.
        /// </summary>
        public virtual bool? ValueAddedTaxValid
        { get; set; }

        /// <summary>
        /// Gets or sets the request date of the VAT number.
        /// </summary>
        public virtual string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT request ID.
        /// </summary>
        public virtual string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT request was successful.
        /// </summary>
        public virtual bool? ValueAddedTaxRequestSuccess
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class with no arguments.
        /// </summary>
        public CustomerAddress()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class with the specified address ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="addressId">Rule ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public CustomerAddress(uint addressId, MagentoServer server)
            : base(addressId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ICustomerAddress)) ? false : Equals(obj as ICustomerAddress);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerAddress x, ICustomerAddress y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Active == y.Active
                    && String.Equals(x.City, y.City, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Company, y.Company, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CountryID, y.CountryID, StringComparison.InvariantCultureIgnoreCase)
                    && x.CreatedAt.Equals(y.CreatedAt)
                    && String.Equals(x.Fax, y.Fax, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.IncrementID, y.IncrementID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.MiddleName, y.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && String.Equals(x.PostalCode, y.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Prefix, y.Prefix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Region, y.Region, StringComparison.InvariantCultureIgnoreCase)
                    && x.RegionID == y.RegionID
                    && String.Equals(x.Street, y.Street, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Suffix, y.Suffix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Telephone, y.Telephone, StringComparison.InvariantCultureIgnoreCase)
                    && x.UpdatedAt.Equals(y.UpdatedAt)
                    && String.Equals(x.ValueAddedTaxID, y.ValueAddedTaxID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxValid.GetValueOrDefault().Equals(y.ValueAddedTaxValid.GetValueOrDefault())
                    && String.Equals(x.ValueAddedTaxRequestDate, y.ValueAddedTaxRequestDate, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValueAddedTaxRequestID, y.ValueAddedTaxRequestID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxRequestSuccess.Equals(y.ValueAddedTaxRequestSuccess);
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
        /// <param name="obj"><see cref="ICustomerAddress"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomerAddress obj)
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

