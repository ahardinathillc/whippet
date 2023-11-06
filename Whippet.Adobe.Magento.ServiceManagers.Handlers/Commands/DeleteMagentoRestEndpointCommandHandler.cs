using System;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteMagentoRestEndpointCommand"/> objects.
    /// </summary>
    public class DeleteMagentoRestEndpointCommandHandler : MagentoRestEndpointCommandHandlerBase<DeleteMagentoRestEndpointCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoRestEndpointCommandHandler"/> class with the specified <see cref="IMagentoRestEndpointRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMagentoRestEndpointRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMagentoRestEndpointCommandHandler(IMagentoRestEndpointRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IMagentoRestEndpointCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteMagentoRestEndpointCommand command)
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
                    result = await Repository.DeleteAsync(command.RestEndpoint);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteMagentoRestEndpointCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteMagentoRestEndpointCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteMagentoRestEndpointCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.RestEndpoint == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }
    }
}
