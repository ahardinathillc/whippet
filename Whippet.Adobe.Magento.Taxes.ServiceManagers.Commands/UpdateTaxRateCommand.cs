using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxRate"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateTaxRateCommand : TaxRateCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRateCommand"/> class with no arguments.
        /// </summary>
        private UpdateTaxRateCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaxRateCommand"/> class with the specified <see cref="TaxRate"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="TaxRate"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateTaxRateCommand(TaxRate taxRate)
            : base(taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
        }
    }
}