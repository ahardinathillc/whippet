using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="ITaxRule"/> objects.
    /// </summary>
    public class TaxRuleCommandBase : WhippetCommand, IWhippetCommand, ITaxRuleCommand
    {
        /// <summary>
        /// Gets the <see cref="Taxes.TaxRule"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public TaxRule TaxRule
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ITaxRule"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ITaxRule ITaxRuleCommand.TaxRule
        {
            get
            {
                return TaxRule;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleCommandBase"/> class with no arguments.
        /// </summary>
        protected TaxRuleCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="taxRule"><see cref="Taxes.TaxRule"/> instance to create or act upon in the data store.</param>
        protected TaxRuleCommandBase(TaxRule taxRule)
            : base()
        {
            TaxRule = taxRule;
        }
    }
}