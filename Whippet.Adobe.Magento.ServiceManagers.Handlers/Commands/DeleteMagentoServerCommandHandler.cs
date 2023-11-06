using System;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteMagentoServerCommand"/> objects.
    /// </summary>
    public class DeleteMagentoServerCommandHandler : MagentoServerCommandHandlerBase<DeleteMagentoServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoServerCommandHandler"/> class with the specified <see cref="IMagentoServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMagentoServerCommandHandler(IMagentoServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteMagentoServerCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if (result.IsSuccess)
                {
                    result = await Repository.DeleteAsync(command.Server);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteMagentoServerCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteMagentoServerCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteMagentoServerCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Server == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
