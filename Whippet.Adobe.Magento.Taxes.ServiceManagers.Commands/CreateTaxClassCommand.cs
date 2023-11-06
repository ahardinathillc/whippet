using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="TaxClass"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateTaxClassCommand : TaxClassCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxClassCommand"/> class with no arguments.
        /// </summary>
        private CreateTaxClassCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaxClassCommand"/> class with the specified <see cref="TaxClass"/>.
        /// </summary>
        /// <param name="taxClass"><see cref="TaxClass"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateTaxClassCommand(TaxClass taxClass)
            : base(taxClass)
        {
            if (taxClass == null)
            {
                throw new ArgumentNullException(nameof(taxClass));
            }
        }
    }
}
