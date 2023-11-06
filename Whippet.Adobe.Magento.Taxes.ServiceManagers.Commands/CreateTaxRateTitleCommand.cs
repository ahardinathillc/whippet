using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="TaxRateTitle"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateTaxRateTitleCommand : TaxRateTitleCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateTitleCommand"/> class with no arguments.
        /// </summary>
        private CreateTaxRateTitleCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxRateTitleCommand"/> class with the specified <see cref="TaxRateTitle"/>.
        /// </summary>
        /// <param name="taxRate"><see cref="TaxRateTitle"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateTaxRateTitleCommand(TaxRateTitle taxRate)
            : base(taxRate)
        {
            if (taxRate == null)
            {
                throw new ArgumentNullException(nameof(taxRate));
            }
        }
    }
}
