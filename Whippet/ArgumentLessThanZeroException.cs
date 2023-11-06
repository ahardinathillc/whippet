using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Athi.Whippet
{
    /// <summary>
    /// Exception that is thrown when a supplied value is less than the floor value of zero (0). This class cannot be inherited.
    /// </summary>
    public sealed class ArgumentLessThanZeroException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLessThanZeroException"/> class with no arguments.
        /// </summary>
        public ArgumentLessThanZeroException()
            : base(LocalizeString(nameof(ArgumentLessThanZeroException), culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLessThanZeroException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public ArgumentLessThanZeroException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLessThanZeroException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public ArgumentLessThanZeroException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(ArgumentLessThanZeroException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLessThanZeroException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public ArgumentLessThanZeroException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
