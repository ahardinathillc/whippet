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
    /// Base class for <see cref="IWhippetGroupUserAssignmentCommand"/> command handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetGroupUserAssignmentCommand"/> type to handle.</typeparam>
    public abstract class WhippetGroupUserAssignmentCommandHandlerBase<TCommand> : WhippetCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>, IWhippetGroupUserAssignmentCommandHandler<TCommand>
        where TCommand : IWhippetGroupUserAssignmentCommand
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetGroupUserAssignmentRepository"/> to execute the commands against.
        /// </summary>
        protected IWhippetGroupUserAssignmentRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentCommandHandlerBase{TCommand}"/> class with the specified <see cref="IWhippetGroupUserAssignmentRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetGroupUserAssignmentRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetGroupUserAssignmentCommandHandlerBase(IWhippetGroupUserAssignmentRepository repository)
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
