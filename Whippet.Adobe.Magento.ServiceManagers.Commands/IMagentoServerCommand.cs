using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IMagentoServer"/> objects.
    /// </summary>
    public interface IMagentoServerCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMagentoServer"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoServer Server
        { get; }
    }
}
