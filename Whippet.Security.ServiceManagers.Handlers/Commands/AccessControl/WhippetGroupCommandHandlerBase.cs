using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Base class for <see cref="IWhippetGroupCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetGroupCommand"/> type to handle.</typeparam>
    public abstract class WhippetGroupCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetGroupCommandHandler<TCommand>
        where TCommand : IWhippetGroupCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetGroupRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetGroupRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetGroupRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetGroupRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetGroupCommandHandlerBase(IWhippetGroupRepository repository)
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
