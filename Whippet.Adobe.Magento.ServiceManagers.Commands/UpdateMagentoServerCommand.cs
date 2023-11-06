using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MagentoServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateMagentoServerCommand : MagentoServerCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoServerCommand"/> class with no arguments.
        /// </summary>
        private UpdateMagentoServerCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoServerCommand"/> class with the specified <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="server"><see cref="MagentoServer"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateMagentoServerCommand(MagentoServer server)
            : base(server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
        }
    }
}
