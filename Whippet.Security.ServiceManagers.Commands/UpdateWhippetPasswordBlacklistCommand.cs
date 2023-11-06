using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetPasswordBlacklist"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetPasswordBlacklistCommand : WhippetPasswordBlacklistCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetPasswordBlacklistCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetPasswordBlacklistCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetPasswordBlacklistCommand"/> class with the specified <see cref="WhippetPasswordBlacklist"/>.
        /// </summary>
        /// <param name="password"><see cref="WhippetPasswordBlacklist"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetPasswordBlacklistCommand(WhippetPasswordBlacklist password)
            : base(password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
        }
    }
}
