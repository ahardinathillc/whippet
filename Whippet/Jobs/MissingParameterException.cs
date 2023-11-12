using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using Athi.Whippet.Localization;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Exception that is thrown when one or more parameters are missing required to execute a job. This class cannot be inherited.
    /// </summary>
    public sealed class MissingParameterException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingParameterException"/> class with no arguments.
        /// </summary>
        private MissingParameterException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingParameterException"/> class with the specified <see cref="IEnumerable{T}"/> collection of missing types.
        /// </summary>
        /// <param name="missingTypes"><see cref="IEnumerable{T}"/> collection of missing types.</param>
        public MissingParameterException(IEnumerable<Type> missingTypes)
            : this(CreateExceptionMessage(missingTypes))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingParameterException"/> class with the specified <see cref="IEnumerable{T}"/> collection of missing types.
        /// </summary>
        /// <param name="missingTypes"><see cref="IEnumerable{T}"/> collection of missing types.</param>
        /// <param name="innerException"><see cref="Exception"/> that was caught prior to the current instance.</param>
        public MissingParameterException(IEnumerable<Type> missingTypes, Exception innerException)
            : base(CreateExceptionMessage(missingTypes), innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingParameterException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Error message to display.</param>
        public MissingParameterException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingParameterException"/> class with the specified serialization information.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Context in which the serialization takes place.</param>
        public MissingParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Creates the exception message.
        /// </summary>
        /// <param name="missingTypes"><see cref="IEnumerable{T}"/> collection of missing types.</param>
        /// <returns>Error message.</returns>
        private static string CreateExceptionMessage(IEnumerable<Type> missingTypes)
        {
            string missingTypesString = null;

            if (missingTypes != null && missingTypes.Any())
            {
                missingTypesString = LocalizedStringResourceLoader.GetException<MissingParameterException>(nameof(MissingParameterException), new object[] { missingTypes.Distinct().Select(t => t.AssemblyQualifiedName).Concat(", ") });
            }
            else
            {
                missingTypesString = LocalizedStringResourceLoader.GetException<MissingParameterException>(nameof(MissingParameterException), new object[] { typeof(object).AssemblyQualifiedName });
            }

            return missingTypesString;
        }
    }
}