using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order address entry in Magento.
    /// </summary>
    public class SalesOrderAddress : MagentoEntity, IMagentoEntity, ISalesOrderAddress, IEqualityComparer<ISalesOrderAddress>
    {
        private CustomerAddress _customerAddress;
        private MagentoCustomer _customer;
        private SalesOrder _order;
        private QuoteAddress _quoteAddress;

        /// <summary>
        /// Gets or sets the unique ID of the entity.
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
        /// Gets or sets the address type.
        /// </summary>
        public virtual string AddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the address city.
        /// </summary>
        public virtual string City
        { get; set; }

        /// <summary>
        /// Gets or sets the address company.
        /// </summary>
        public virtual string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the two-letter country ID.
        /// </summary>
        public virtual string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer address.
        /// </summary>
        public virtual CustomerAddress CustomerAddress
        {
            get
            {
                if (_customerAddress == null)
                {
                    _customerAddress = new CustomerAddress();
                }

                return _customerAddress;
            }
            set
            {
                _customerAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated customer address.
        /// </summary>
        ICustomerAddress ISalesOrderAddress.CustomerAddress
        {
            get
            {
                return CustomerAddress;
            }
            set
            {
                CustomerAddress = value.ToCustomerAddress();
            }
        }

        /// <summary>
        /// Gets or sets the associated customer.
        /// </summary>
        public virtual MagentoCustomer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new MagentoCustomer();
                }

                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated customer.
        /// </summary>
        ICustomer ISalesOrderAddress.Customer
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
        /// Gets or sets the e-mail associated with the order address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the fax phone number associated with the order address.
        /// </summary>
        public virtual string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name on the order address.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID of the gift registry item.
        /// </summary>
        public virtual int? GiftRegistryItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the last name on the order address.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name on the order address.
        /// </summary>
        public virtual string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="SalesOrder"/> object.
        /// </summary>
        public virtual SalesOrder Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new SalesOrder();
                }

                return _order;
            }
            set
            {
                _order = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="ISalesOrder"/> object.
        /// </summary>
        ISalesOrder ISalesOrderAddress.Order
        {
            get
            {
                return Order;
            }
            set
            {
                Order = value.ToSalesOrder();
            }
        }

        /// <summary>
        /// Gets or sets the postal code of the order address.
        /// </summary>
        public virtual string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the name on the order address.
        /// </summary>
        public virtual string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        public virtual QuoteAddress QuoteAddress
        {
            get
            {
                if (_quoteAddress == null)
                {
                    _quoteAddress = new QuoteAddress();
                }

                return _quoteAddress;
            }
            set
            {
                _quoteAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        IQuoteAddress ISalesOrderAddress.QuoteAddress
        {
            get
            {
                return QuoteAddress;
            }
            set
            {
                QuoteAddress = value.ToQuoteAddress();
            }
        }

        /// <summary>
        /// Gets or sets the address region.
        /// </summary>
        public virtual string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. The region ID is stored in Magento configuration.
        /// </summary>
        public virtual string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        public virtual string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        public virtual string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the address telephone number.
        /// </summary>
        public virtual string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the validated VAT number for the customer.
        /// </summary>
        public virtual string ValidatedValueAddedTaxNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT ID.
        /// </summary>
        public virtual string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT supplied is valid.
        /// </summary>
        public virtual bool? ValueAddedTaxIsValid
        { get; set; }

        /// <summary>
        /// Gets or sets the date the VAT was requested.
        /// </summary>
        public virtual string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the VAT request.
        /// </summary>
        public virtual string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT request was successful.
        /// </summary>
        public virtual bool? ValueAddedTaxRequestSuccess
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddress"/> class with no arguments.
        /// </summary>
        public SalesOrderAddress()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderAddress"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="addressId">Quote address ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public SalesOrderAddress(uint addressId, MagentoServer server)
            : base(addressId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ISalesOrderAddress)) ? false : Equals(obj as ISalesOrderAddress);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderAddress obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrderAddress x, ISalesOrderAddress y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.AddressType, y.AddressType, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.City, y.City, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Company, y.Company, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CountryID, y.CountryID, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && ((x.CustomerAddress == null && y.CustomerAddress == null) || (x.CustomerAddress != null && x.CustomerAddress.Equals(y.CustomerAddress)))
                    && String.Equals(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Fax, y.Fax, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && x.GiftRegistryItemID.GetValueOrDefault().Equals(y.GiftRegistryItemID.GetValueOrDefault())
                    && String.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.MiddleName, y.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.PostalCode, y.PostalCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Prefix, y.Prefix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Region, y.Region, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.RegionID, y.RegionID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Street, y.Street, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Suffix, y.Suffix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Telephone, y.Telephone, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValidatedValueAddedTaxNumber, y.ValidatedValueAddedTaxNumber, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValueAddedTaxID, y.ValueAddedTaxID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxIsValid.GetValueOrDefault().Equals(y.ValueAddedTaxIsValid.GetValueOrDefault())
                    && String.Equals(x.ValueAddedTaxRequestDate, y.ValueAddedTaxRequestDate, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValueAddedTaxRequestID, y.ValueAddedTaxRequestID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ValueAddedTaxRequestSuccess.GetValueOrDefault().Equals(y.ValueAddedTaxRequestSuccess.GetValueOrDefault())
                    && ((x.Order == null && y.Order == null) || (x.Order != null && x.Order.Equals(y.Order)));
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
        /// <param name="obj"><see cref="IQuote"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrderAddress obj)
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

