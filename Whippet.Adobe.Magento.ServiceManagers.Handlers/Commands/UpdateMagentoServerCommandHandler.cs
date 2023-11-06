using System;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="UpdateMagentoServerCommand"/> objects.
    /// </summary>
    public class UpdateMagentoServerCommandHandler : MagentoServerCommandHandlerBase<UpdateMagentoServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoServerCommandHandler"/> class with the specified <see cref="IMagentoServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateMagentoServerCommandHandler(IMagentoServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateMagentoServerCommand command)
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
                    result = await Repository.UpdateAsync(command.Server);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="UpdateMagentoServerCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="UpdateMagentoServerCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(UpdateMagentoServerCommand command)
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
