using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxRateTitle"/> objects.
    /// </summary>
    public class TaxRateTitleCommandBase : WhippetCommand, IWhippetCommand, ITaxRateTitleCommand
    {
        /// <summary>
        /// Gets the <see cref="Taxes.TaxRateTitle"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TaxRateTitle TaxRateTitle
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ITaxRateTitle"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxRateTitle ITaxRateTitleCommand.TaxRateTitle
        {
            get
            {
                return TaxRateTitle;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleCommandBase"/> class with no arguments.
        /// </summary>
        protected TaxRateTitleCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="taxRateTitle"><see cref="Taxes.TaxRateTitle"/> instance to create or act upon in the data store.</param>
        protected TaxRateTitleCommandBase(TaxRateTitle taxRateTitle)
            : base()
        {
            TaxRateTitle = taxRateTitle;
        }
    }
}
