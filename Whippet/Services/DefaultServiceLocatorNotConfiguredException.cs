using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Localization;

namespace Athi.Whippet.Services
{
    /// <summary>
    /// Exception that is thrown when a default service locator is not specified. This class cannot be inherited.
    /// </summary>
    public sealed class DefaultServiceLocatorNotConfiguredException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceLocatorNotConfiguredException"/> class with no arguments.
        /// </summary>
        public DefaultServiceLocatorNotConfiguredException()
            : this(LocalizedStringResourceLoader.GetException<DefaultServiceLocatorNotConfiguredException>(nameof(DefaultServiceLocatorNotConfiguredException)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceLocatorNotConfiguredException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public DefaultServiceLocatorNotConfiguredException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceLocatorNotConfiguredException"/> class with the specified message and exception.
        /// </summary>
        /// <param name="message">Message to display.</param>
        /// <param name="innerException"><see cref="Exception"/> that was encountered prior to the current instance.</param>
        public DefaultServiceLocatorNotConfiguredException(string message, Exception innerException)
            : base(String.IsNullOrWhiteSpace(message) ? LocalizedStringResourceLoader.GetException<DefaultServiceLocatorNotConfiguredException>(nameof(DefaultServiceLocatorNotConfiguredException)) : message, innerException)
        { }
    }
}
