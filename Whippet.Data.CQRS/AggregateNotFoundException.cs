using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Athi.Whippet.Localization;
using Athi.Whippet.Data.CQRS.ResourceFiles;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Exception that is thrown when a <see cref="WhippetAggregateRoot"/> object could not be found or loaded. This class cannot be inherited.
    /// </summary>
    public sealed class AggregateNotFoundException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateNotFoundException"/> class with no arguments.
        /// </summary>
        public AggregateNotFoundException()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateNotFoundException"/> class with the specified aggregate ID.
        /// </summary>
        /// <param name="aggregateId">Aggregate ID of the aggregate that failed to load.</param>
        public AggregateNotFoundException(Guid aggregateId)
            : base(LocalizedStringResourceLoader.GetException<AggregateNotFoundException>(ExceptionResourceIndex.AggregateNotFoundException, new object[] { aggregateId }))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public AggregateNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateNotFoundException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public AggregateNotFoundException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
