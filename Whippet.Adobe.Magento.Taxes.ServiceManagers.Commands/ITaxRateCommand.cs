using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxRate"/> objects.
    /// </summary>
    public interface ITaxRateCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ITaxRate"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxRate TaxRate
        { get; }
    }
}