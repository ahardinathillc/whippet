using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxClass"/> objects.
    /// </summary>
    public class TaxClassCommandBase : WhippetCommand, IWhippetCommand, ITaxClassCommand
    {
        /// <summary>
        /// Gets the <see cref="Taxes.TaxClass"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TaxClass TaxClass
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ITaxClass"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxClass ITaxClassCommand.TaxClass
        {
            get
            {
                return TaxClass;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassCommandBase"/> class with no arguments.
        /// </summary>
        protected TaxClassCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="taxClass"><see cref="Taxes.TaxClass"/> instance to create or act upon in the data store.</param>
        protected TaxClassCommandBase(TaxClass taxClass)
            : base()
        {
            TaxClass = taxClass;
        }
    }
}