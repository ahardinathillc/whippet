using System;
using NHibernate;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Exception that is thrown when a <see cref="PostalCode"/> object could not be located in the data store.
    /// </summary>
    public sealed class PostalCodeNotFoundException : ObjectNotFoundException
    {
        private string _msg;

        /// <summary>
        /// Gets the message describing the exception. This property is read-only. 
        /// </summary>
        public new string Message
        {
            get
            {
                return (base.Message + " " + _msg).Trim();
            }
            private set
            {
                _msg = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeNotFoundException"/> class with the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value that could not be found.</param>
        public PostalCodeNotFoundException(string postalCode)
            : this(postalCode, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeNotFoundException"/> class with the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value that could not be found.</param>
        /// <param name="message">Message describing the exception.</param>
        public PostalCodeNotFoundException(string postalCode, string message)
            : base(postalCode, typeof(PostalCode))
        {
            Message = message;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}

