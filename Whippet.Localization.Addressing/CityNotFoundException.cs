using System;
using NHibernate;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Exception that is thrown when a <see cref="City"/> object could not be located in the data store.
    /// </summary>
    public sealed class CityNotFoundException : ObjectNotFoundException
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
        /// Initializes a new instance of the <see cref="CityNotFoundException"/> class with the specified city name.
        /// </summary>
        /// <param name="cityName">Name of the city that could not be found.</param>
        public CityNotFoundException(string cityName)
            : this(cityName, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityNotFoundException"/> class with the specified city name.
        /// </summary>
        /// <param name="cityName">Name of the city that could not be found.</param>
        /// <param name="message">Message describing the exception.</param>
        public CityNotFoundException(string cityName, string message)
            : base(cityName, typeof(City))
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

