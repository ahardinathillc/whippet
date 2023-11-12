using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxRule"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateTaxRuleCommand : TaxRuleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRuleCommand"/> class with no arguments.
        /// </summary>
        private UpdateTaxRuleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRuleCommand"/> class with the specified <see cref="TaxRule"/>.
        /// </summary>
        /// <param name="taxRule"><see cref="TaxRule"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateTaxRuleCommand(TaxRule taxRule)
            : base(taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
        }
    }
}