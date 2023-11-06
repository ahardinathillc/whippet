using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IMultichannelOrderManagerRestEndpoint"/> objects.
    /// </summary>
    public interface IMultichannelOrderManagerRestEndpointCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerRestEndpoint"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMultichannelOrderManagerRestEndpoint RestEndpoint
        { get; }
    }
}
