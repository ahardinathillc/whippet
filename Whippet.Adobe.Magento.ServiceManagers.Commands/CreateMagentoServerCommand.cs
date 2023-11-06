using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MagentoServer"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMagentoServerCommand : MagentoServerCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoServerCommand"/> class with no arguments.
        /// </summary>
        private CreateMagentoServerCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoServerCommand"/> class with the specified <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="server"><see cref="MagentoServer"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMagentoServerCommand(MagentoServer server)
            : base(server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
        }
    }
}
