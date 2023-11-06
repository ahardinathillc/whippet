using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a class that can receive and act on <see cref="IWhippetCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> object to handle</typeparam>
    public interface IWhippetCommandHandler<in TCommand> where TCommand : IWhippetCommand
    {
        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Handle(IWhippetCommandHandlerContext<TCommand> handlerContext);

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Handle(TCommand command);

        /// <summary>
        /// Handles the specified command asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResult> HandleAsync(TCommand command);
    }
}
