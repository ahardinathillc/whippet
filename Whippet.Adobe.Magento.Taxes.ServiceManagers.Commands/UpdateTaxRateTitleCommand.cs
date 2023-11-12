using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxRateTitle"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateTaxRateTitleCommand : TaxRateTitleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRateTitleCommand"/> class with no arguments.
        /// </summary>
        private UpdateTaxRateTitleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRateTitleCommand"/> class with the specified <see cref="TaxRateTitle"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="TaxRateTitle"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateTaxRateTitleCommand(TaxRateTitle taxRate)
            : base(taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
        }
    }
}