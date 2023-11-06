using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Commands;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateJobCategoryCommand"/> objects.
    /// </summary>
    public class CreateJobCategoryCommandHandler : JobCategoryCommandHandlerBase<CreateJobCategoryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateJobCategoryCommandHandler"/> class with the specified <see cref="IJobCategoryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IJobCategoryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateJobCategoryCommandHandler(IJobCategoryRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="IJobCategoryCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateJobCategoryCommand command)
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
                    result = await Repository.CreateAsync(command.Category);
                }

                return result;
            }
        }
    }
}
