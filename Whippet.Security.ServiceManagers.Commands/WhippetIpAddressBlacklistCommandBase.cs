using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="WhippetIpAddressBlacklist"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetIpAddressBlacklistCommandBase : WhippetCommand, IWhippetCommand, IWhippetIpAddressBlacklistCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetIpAddressBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetIpAddressBlacklist IPAddress
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="WhippetIpAddressBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetIpAddressBlacklist IWhippetIpAddressBlacklistCommand.IPAddress
        {
            get
            {
                return IPAddress;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetIpAddressBlacklistCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="ipAddress"><see cref="WhippetIpAddressBlacklist"/> instance to create or act upon in the data store.</param>
        protected WhippetIpAddressBlacklistCommandBase(WhippetIpAddressBlacklist ipAddress)
            : base()
        {
            IPAddress = ipAddress;
        }
    }
}
