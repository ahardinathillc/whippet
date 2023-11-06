using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="WhippetApplication"/> objects.
    /// </summary>
    public class WhippetApplicationCommandBase : WhippetCommand, IWhippetCommand, IWhippetApplicationCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetApplication"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetApplication Application
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetApplication"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetApplication IWhippetApplicationCommand.Application
        {
            get
            {
                return Application;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetApplicationCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="setting"><see cref="WhippetApplication"/> instance to create or act upon in the data store.</param>
        protected WhippetApplicationCommandBase(WhippetApplication setting)
            : base()
        {
            Application = setting;
        }
    }
}
