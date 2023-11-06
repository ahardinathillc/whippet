using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetIpAddressBlacklist"/> objects.
    /// </summary>
    public interface IWhippetIpAddressBlacklistCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetIpAddressBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetIpAddressBlacklist IPAddress
        { get; }
    }
}

