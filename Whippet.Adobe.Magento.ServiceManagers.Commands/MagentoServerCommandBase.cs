using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="MagentoServer"/> objects. This class must be inherited.
    /// </summary>
    public class MagentoServerCommandBase : WhippetCommand, IWhippetCommand, IMagentoServerCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoServer"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public MagentoServer Server
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoServer"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoServer IMagentoServerCommand.Server
        {
            get
            {
                return Server;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerCommandBase"/> class with no arguments.
        /// </summary>
        protected MagentoServerCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="server"><see cref="MagentoServer"/> instance to create or act upon in the data store.</param>
        protected MagentoServerCommandBase(MagentoServer server)
            : base()
        {
            Server = server;
        }
    }
}
