using System;
using NHibernate;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Exception that is thrown when a <see cref="Country"/> object could not be located in the data store.
    /// </summary>
    public sealed class CountryNotFoundException : ObjectNotFoundException
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
        /// Initializes a new instance of the <see cref="CountryNotFoundException"/> class with the specified country name.
        /// </summary>
        /// <param name="countryName">Name of the country that could not be found.</param>
        public CountryNotFoundException(string countryName)
            : this(countryName, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryNotFoundException"/> class with the specified country name.
        /// </summary>
        /// <param name="countryName">Name of the country that could not be found.</param>
        /// <param name="message">Message describing the exception.</param>
        public CountryNotFoundException(string countryName, string message)
            : base(countryName, typeof(Country))
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
