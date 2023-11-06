using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Localization;
using Athi.Whippet.ResourceFiles;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Exception that is thrown when a command handler cannot be located for a specific type. This class cannot be inherited.
    /// </summary>
    public sealed class CommandHandlerNotFoundException : WhippetException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class with no arguments.
        /// </summary>
        /// <param name="type"><see cref="Type"/> that represents the command type that invoked the exception.</param>
        public CommandHandlerNotFoundException(Type type)
            : this(type, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class with the specified message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public CommandHandlerNotFoundException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class with the specified message and exception.
        /// </summary>
        /// <param name="type"><see cref="Type"/> that represents the command type that invoked the exception.</param>
        /// <param name="innerException"><see cref="Exception"/> that was encountered prior to the current instance.</param>
        public CommandHandlerNotFoundException(Type type, Exception innerException)
            : base(LocalizedStringResourceLoader.GetException<CommandHandlerNotFoundException>(ExceptionResourceIndex.CommandHandlerNotFoundException, new object[] { type?.FullName }), innerException)
        { }
    }
}
