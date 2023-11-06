using System;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer
{
    /// <summary>
    /// Represents a logical grouping for <see cref="Magento.Customer.Customer"/> entities.
    /// </summary>
    public class CustomerGroup : MagentoEntity, IMagentoEntity, ICustomerGroup, IEqualityComparer<ICustomerGroup>
    {
        private TaxClass _tc;

        /// <summary>
        /// Gets or sets the unique group ID.
        /// </summary>
        public virtual uint GroupID
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
        /// Gets or sets the customer group code.
        /// </summary>
        public virtual string GroupCode
        { get; set; }

        /// <summary>
        /// Gets or sets the tax class of the <see cref="CustomerGroup"/>.
        /// </summary>
        public virtual TaxClass TaxClass
        {
            get
            {
                if (_tc == null)
                {
                    _tc = new TaxClass();
                }

                return _tc;
            }
            set
            {
                _tc = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax class of the <see cref="ICustomerGroup"/>.
        /// </summary>
        ITaxClass ICustomerGroup.TaxClass
        {
            get
            {
                return TaxClass;
            }
            set
            {
                TaxClass = value.ToTaxClass();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroup"/> class with no arguments.
        /// </summary>
        public CustomerGroup()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroup"/> class with the specified class ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="groupId">Group ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public CustomerGroup(uint groupId, MagentoServer server)
            : base(groupId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ICustomerGroup)) ? false : Equals(obj as ICustomerGroup);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerGroup obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomerGroup x, ICustomerGroup y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.GroupCode, y.GroupCode, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.TaxClass == null && y.TaxClass == null) || (x.TaxClass != null && x.TaxClass.Equals(y.TaxClass)));
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
        /// <param name="obj"><see cref="ITaxClass"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ICustomerGroup obj)
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
            return String.IsNullOrWhiteSpace(GroupCode) ? base.ToString() : GroupCode;
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

