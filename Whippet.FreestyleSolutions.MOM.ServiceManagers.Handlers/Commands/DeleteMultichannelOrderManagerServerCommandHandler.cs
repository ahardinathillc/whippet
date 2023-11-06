using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteMultichannelOrderManagerServerCommand"/> objects.
    /// </summary>
    public class DeleteMultichannelOrderManagerServerCommandHandler : MultichannelOrderManagerServerCommandHandlerBase<DeleteMultichannelOrderManagerServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultichannelOrderManagerServerCommandHandler"/> class with the specified <see cref="IMultichannelOrderManagerServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteMultichannelOrderManagerServerCommandHandler(IMultichannelOrderManagerServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="DeleteMultichannelOrderManagerServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteMultichannelOrderManagerServerCommand command)
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
    }

}
