using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxRateTitle"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteTaxRateTitleCommand : TaxRateTitleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxRateTitleCommand"/> class with no arguments.
        /// </summary>
        private DeleteTaxRateTitleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxRateTitleCommand"/> class with the specified <see cref="TaxRateTitle"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="TaxRateTitle"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteTaxRateTitleCommand(TaxRateTitle taxRate)
            : base(taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
        }
    }
}