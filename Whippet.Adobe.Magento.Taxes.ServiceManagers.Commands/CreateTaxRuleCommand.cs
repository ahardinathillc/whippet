using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="TaxRule"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateTaxRuleCommand : TaxRuleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRuleCommand"/> class with no arguments.
        /// </summary>
        private CreateTaxRuleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRuleCommand"/> class with the specified <see cref="TaxRule"/>.
        /// </summary>
        /// <param name="taxRule"><see cref="TaxRule"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateTaxRuleCommand(TaxRule taxRule)
            : base(taxRule)
        {
            if (taxRule == null)
            {
                throw new ArgumentNullException(nameof(taxRule));
            }
        }
    }
}