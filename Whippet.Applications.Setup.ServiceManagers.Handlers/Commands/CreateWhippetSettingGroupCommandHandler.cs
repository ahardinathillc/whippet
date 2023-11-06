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
    /// Command handler for <see cref="CreateWhippetSettingGroupCommand"/> objects.
    /// </summary>
    public class CreateWhippetSettingGroupCommandHandler : WhippetSettingGroupCommandHandlerBase<CreateWhippetSettingGroupCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetSettingGroupCommandHandler"/> class with the specified <see cref="IWhippetSettingGroupRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetSettingGroupRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateWhippetSettingGroupCommandHandler(IWhippetSettingGroupRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateWhippetSettingGroupCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateWhippetSettingGroupCommand command)
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
                    result = await Repository.CreateAsync(command.Group);
                }

                return result;
            }
        }
    }
}
