using System;
using NHibernate;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Exception that is thrown when a <see cref="StateProvince"/> object could not be located in the data store.
    /// </summary>
    public sealed class StateProvinceNotFoundException : ObjectNotFoundException
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
        /// Initializes a new instance of the <see cref="StateProvinceNotFoundException"/> class with the specified state/province name.
        /// </summary>
        /// <param name="stateProvinceName">Name of the state/province that could not be found.</param>
        public StateProvinceNotFoundException(string stateProvinceName)
            : this(stateProvinceName, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceNotFoundException"/> class with the specified state/province name.
        /// </summary>
        /// <param name="stateProvinceName">Name of the state/province that could not be found.</param>
        /// <param name="message">Message describing the exception.</param>
        public StateProvinceNotFoundException(string stateProvinceName, string message)
            : base(stateProvinceName, typeof(StateProvince))
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

