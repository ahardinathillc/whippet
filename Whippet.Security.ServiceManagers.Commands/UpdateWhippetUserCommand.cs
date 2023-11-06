using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetUser"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetUserCommand : WhippetUserCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetUserCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetUserCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetUserCommand"/> class with the specified <see cref="WhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="WhippetUser"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetUserCommand(WhippetUser user)
            : base(user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}
