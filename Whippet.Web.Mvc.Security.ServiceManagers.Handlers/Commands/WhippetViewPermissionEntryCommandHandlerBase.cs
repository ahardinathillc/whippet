using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands;
using Athi.Whippet.Web.Mvc.Security.Repositories;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetViewPermissionEntryCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetViewPermissionEntryCommand"/> type to handle.</typeparam>
    public abstract class WhippetViewPermissionEntryCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetViewPermissionEntryCommandHandler<TCommand>
        where TCommand : IWhippetViewPermissionEntryCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetViewPermissionEntryRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetViewPermissionEntryRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetViewPermissionEntryRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetViewPermissionEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetViewPermissionEntryCommandHandlerBase(IWhippetViewPermissionEntryRepository repository)
            : base()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                Repository = repository;
            }
        }
    }
}
