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
    /// Command handler for <see cref="CreateStateProvinceCommand"/> objects.
    /// </summary>
    public class CreateStateProvinceCommandHandler : StateProvinceCommandHandlerBase<CreateStateProvinceCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStateProvinceCommandHandler"/> class with the specified <see cref="IStateProvince"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IStateProvince"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateStateProvinceCommandHandler(IStateProvinceRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IStateProvinceCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateStateProvinceCommand command)
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
                    result = await Repository.CreateAsync(command.State);
                }

                return result;
            }
        }
    }
}
