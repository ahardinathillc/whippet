using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Commands;
using Athi.Whippet.Localization.Addressing.Repositories;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteCityCommand"/> objects.
    /// </summary>
    public class DeleteCityCommandHandler : CityCommandHandlerBase<DeleteCityCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCityCommandHandler"/> class with the specified <see cref="ICityRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ICityRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteCityCommandHandler(ICityRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="ICityCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteCityCommand command)
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
                    result = await Repository.DeleteAsync(command.City);
                }

                return result;
            }
        }
    }
}
