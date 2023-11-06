using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetIpAddressBlacklist"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetIpAddressBlacklistCommand : WhippetIpAddressBlacklistCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetIpAddressBlacklistCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetIpAddressBlacklistCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetIpAddressBlacklistCommand"/> class with the specified <see cref="WhippetIpAddressBlacklist"/>.
        /// </summary>
        /// <param name="ipAddress"><see cref="WhippetIpAddressBlacklist"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetIpAddressBlacklistCommand(WhippetIpAddressBlacklist ipAddress)
            : base(ipAddress)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }
        }
    }
}
