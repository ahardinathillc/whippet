using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="InvariantAddress"/> objects. This class must be inherited.
    /// </summary>
    public abstract class InvariantAddressCommandBase : WhippetCommand, IWhippetCommand, IInvariantAddressCommand
    {
        /// <summary>
        /// Gets the <see cref="Addressing.InvariantAddress"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public InvariantAddress Address
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IInvariantAddress"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IInvariantAddress IInvariantAddressCommand.Address
        {
            get
            {
                return Address;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressCommandBase"/> class with no arguments.
        /// </summary>
        protected InvariantAddressCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantAddressCommandBase"/> class with the specified <see cref="Addressing.InvariantAddress"/> object.
        /// </summary>
        /// <param name="address"><see cref="Addressing.InvariantAddress"/> object to initialize with.</param>
        protected InvariantAddressCommandBase(InvariantAddress address)
            : this()
        {
            Address = address;
        }
    }
}
