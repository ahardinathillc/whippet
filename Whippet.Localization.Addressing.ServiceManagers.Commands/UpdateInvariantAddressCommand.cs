using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="InvariantAddress"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateInvariantAddressCommand : InvariantAddressCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvariantAddressCommand"/> class with no arguments.
        /// </summary>
        private UpdateInvariantAddressCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvariantAddressCommand"/> class with the specified <see cref="InvariantAddress"/>.
        /// </summary>
        /// <param name="address"><see cref="InvariantAddress"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateInvariantAddressCommand(InvariantAddress address)
            : base(address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
        }
    }
}
