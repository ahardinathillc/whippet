using System;
using System.Runtime.Serialization;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Exception that is thrown when no setup groups exist for a Whippet application. This class cannot be inherited.
    /// </summary>
    public sealed class NoWhippetSettingGroupsExistForApplicationException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoWhippetSettingGroupsExistForApplicationException"/> class with no arguments.
        /// </summary>
        public NoWhippetSettingGroupsExistForApplicationException()
            : base(LocalizeString(nameof(NoWhippetSettingGroupsExistForApplicationException), culture: CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoWhippetSettingGroupsExistForApplicationException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public NoWhippetSettingGroupsExistForApplicationException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoWhippetSettingGroupsExistForApplicationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public NoWhippetSettingGroupsExistForApplicationException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizeString(nameof(NoWhippetSettingGroupsExistForApplicationException), culture: CurrentCulture) : message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoWhippetSettingGroupsExistForApplicationException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        public NoWhippetSettingGroupsExistForApplicationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}
