using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxRule"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteTaxRuleCommand : TaxRuleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxRuleCommand"/> class with no arguments.
        /// </summary>
        private DeleteTaxRuleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxRuleCommand"/> class with the specified <see cref="TaxRule"/>.
        /// </summary>
        /// <param name="taxRule"><see cref="TaxRule"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteTaxRuleCommand(TaxRule taxRule)
            : base(taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
        }
    }
}