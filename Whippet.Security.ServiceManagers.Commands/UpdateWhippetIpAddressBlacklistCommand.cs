using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetIpAddressBlacklist"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetIpAddressBlacklistCommand : WhippetIpAddressBlacklistCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetIpAddressBlacklistCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetIpAddressBlacklistCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetIpAddressBlacklistCommand"/> class with the specified <see cref="WhippetIpAddressBlacklist"/>.
        /// </summary>
        /// <param name="ipAddress"><see cref="WhippetIpAddressBlacklist"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetIpAddressBlacklistCommand(WhippetIpAddressBlacklist ipAddress)
            : base(ipAddress)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }
        }
    }
}
