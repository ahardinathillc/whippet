using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Athi.Whippet
{
    /// <summary>
    /// Base class for all <see cref="WhippetException"/> objects that do not require localization. This class must be inherited.
    /// </summary>
    public abstract class UnlocalizedException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnlocalizedException"/> class with no arguments.
        /// </summary>
        protected UnlocalizedException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnlocalizedException"/> class with the specified exception message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected UnlocalizedException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnlocalizedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        protected UnlocalizedException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnlocalizedException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        protected UnlocalizedException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
