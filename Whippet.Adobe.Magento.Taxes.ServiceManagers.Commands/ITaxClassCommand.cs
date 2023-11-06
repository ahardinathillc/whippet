using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxClass"/> objects.
    /// </summary>
    public interface ITaxClassCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ITaxClass"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxClass TaxClass
        { get; }
    }
}
