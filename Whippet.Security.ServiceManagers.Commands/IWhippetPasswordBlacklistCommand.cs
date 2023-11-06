using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetPasswordBlacklist"/> objects.
    /// </summary>
    public interface IWhippetPasswordBlacklistCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetPasswordBlacklist"/> instance ot create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetPasswordBlacklist Password
        { get; }
    }
}

