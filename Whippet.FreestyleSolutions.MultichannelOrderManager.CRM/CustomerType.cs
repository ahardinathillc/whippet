using System;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM
{
    /// <summary>
    /// Represents a customer type.
    /// </summary>
    public class CustomerType : MultichannelOrderManagerEntity, IMultichannelOrderManagerEntity, IWhippetEntity, IEqualityComparer<CustomerType>
    {
        private string _code;
        
        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new virtual MultichannelOrderManagerEntityKey<int> ID
        {
            get
            {
                return base.ID.ToValue<int>();
            }
            set
            {
                base.ID = new MultichannelOrderManagerEntityKey<int>(value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum length of <see cref="Code"/>.
        /// </summary>
        protected internal virtual int CodeLength
        { get; set; }
        
        /// <summary>
        /// Gets or sets the type description.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the customer type code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && (CodeLength > 0) && (value.Length > CodeLength))
                {
                    throw new ArgumentOutOfRangeException();
                }

                _code = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with no arguments.
        /// </summary>
        public CustomerType()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        public CustomerType(int id)
            : base(new MultichannelOrderManagerEntityKey<int>(id))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerType"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the customer type.</param>
        /// <param name="description">Type description.</param>
        /// <param name="type">Type code.</param>
        public CustomerType(int id, string description, string type)
            : base(new MultichannelOrderManagerEntityKey<int>(id))
        {
            Description = description;
            Code = type;
        }
        
                /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as CustomerType);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(CustomerType obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(CustomerType x, CustomerType y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    String.Equals(x.Code, y.Code, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Code, Description);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="CustomerType"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(CustomerType obj)
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
        /// Returns the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Description) ? base.ToString() : Description;
        }        
    }
}
