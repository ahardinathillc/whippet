using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IMagentoRestEndpoint"/> objects.
    /// </summary>
    public interface IMagentoRestEndpointCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMagentoRestEndpoint"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoRestEndpoint RestEndpoint
        { get; }
    }
}
