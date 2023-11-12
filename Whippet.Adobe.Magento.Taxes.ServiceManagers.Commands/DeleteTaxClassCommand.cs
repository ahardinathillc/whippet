using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="TaxClass"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteTaxClassCommand : TaxClassCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxClassCommand"/> class with no arguments.
        /// </summary>
        private DeleteTaxClassCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTaxClassCommand"/> class with the specified <see cref="TaxClass"/>.
        /// </summary>
        /// <param name="taxClass"><see cref="TaxClass"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteTaxClassCommand(TaxClass taxClass)
            : base(taxClass)
        {
            if (taxClass == null)
            {
                throw new ArgumentNullException(nameof(taxClass));
            }
        }
    }
}