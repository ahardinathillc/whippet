using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Applications.Setup.Repositories;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateWhippetSettingCommand"/> objects.
    /// </summary>
    public class CreateWhippetSettingCommandHandler : WhippetSettingCommandHandlerBase<CreateWhippetSettingCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetSettingCommandHandler"/> class with the specified <see cref="IWhippetSettingRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetSettingRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateWhippetSettingCommandHandler(IWhippetSettingRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateWhippetSettingCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateWhippetSettingCommand command)
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
                    result = await Repository.CreateAsync(command.Setting);
                }

                return result;
            }
        }
    }
}
