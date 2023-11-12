using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxRule"/> objects.
    /// </summary>
    public interface ITaxRuleCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="ITaxRule"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxRule TaxRule
        { get; }
    }
}