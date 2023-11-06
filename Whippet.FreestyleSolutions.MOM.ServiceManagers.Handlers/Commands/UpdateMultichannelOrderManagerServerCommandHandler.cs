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
    /// Command handler for <see cref="UpdateMultichannelOrderManagerServerCommand"/> objects.
    /// </summary>
    public class UpdateMultichannelOrderManagerServerCommandHandler : MultichannelOrderManagerServerCommandHandlerBase<UpdateMultichannelOrderManagerServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultichannelOrderManagerServerCommandHandler"/> class with the specified <see cref="IMultichannelOrderManagerServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public UpdateMultichannelOrderManagerServerCommandHandler(IMultichannelOrderManagerServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="UpdateMultichannelOrderManagerServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(UpdateMultichannelOrderManagerServerCommand command)
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
    }

}
