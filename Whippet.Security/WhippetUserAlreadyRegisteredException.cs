using System;
using System.Runtime.Serialization;
using Athi.Whippet.Localization;
using Athi.Whippet.Security.ResourceFiles;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Exception that is thrown when an <see cref="IWhippetUser"/> object is attempted to be created when an instance with a matching username already exists. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetUserAlreadyRegisteredException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAlreadyRegisteredException"/> class with no arguments.
        /// </summary>
        private WhippetUserAlreadyRegisteredException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAlreadyRegisteredException"/> class with the specified username.
        /// </summary>
        /// <param name="username">Username that was requested but already exists.</param>
        public WhippetUserAlreadyRegisteredException(string username)
            : base(LocalizedStringResourceLoader.GetException<WhippetUserAlreadyRegisteredException>(ExceptionResourceIndex.UserAlreadyExistsException, new object[] { username }, CurrentCulture))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAlreadyRegisteredException"/> class with a specified username and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="username">Username that was requested but already exists.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        public WhippetUserAlreadyRegisteredException(string username, Exception innerException)
            : base(LocalizedStringResourceLoader.GetException<WhippetUserAlreadyRegisteredException>(ExceptionResourceIndex.UserAlreadyExistsException, new object[] { username }, CurrentCulture), innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        internal WhippetUserAlreadyRegisteredException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }
    }
}

