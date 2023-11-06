using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="SalesforceProduct"/> objects. This class must be inherited.
    /// </summary>
    public abstract class SalesforceProductCommandBase : WhippetCommand, IWhippetCommand, ISalesforceProductCommand
    {
        /// <summary>
        /// Gets the <see cref="SalesforceProduct"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public SalesforceProduct Product
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ISalesforceProduct"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ISalesforceProduct ISalesforceProductCommand.Product
        {
            get
            {
                return Product;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductCommandBase"/> class with no arguments.
        /// </summary>
        protected SalesforceProductCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceProductCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="product"><see cref="SalesforceProduct"/> instance to create or act upon in the data store.</param>
        protected SalesforceProductCommandBase(SalesforceProduct product)
            : base()
        {
            Product = product;
        }
    }
}
