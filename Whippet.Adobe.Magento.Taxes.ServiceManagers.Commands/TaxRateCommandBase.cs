using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxRate"/> objects.
    /// </summary>
    public class TaxRateCommandBase : WhippetCommand, IWhippetCommand, ITaxRateCommand
    {
        /// <summary>
        /// Gets the <see cref="Taxes.TaxRate"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TaxRate TaxRate
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ITaxRate"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxRate ITaxRateCommand.TaxRate
        {
            get
            {
                return TaxRate;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateCommandBase"/> class with no arguments.
        /// </summary>
        protected TaxRateCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="taxRate"><see cref="Taxes.TaxRate"/> instance to create or act upon in the data store.</param>
        protected TaxRateCommandBase(TaxRate taxRate)
            : base()
        {
            TaxRate = taxRate;
        }
    }
}
