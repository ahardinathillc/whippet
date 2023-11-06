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
    public abstract class WhippetCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandHandler{TCommand}"/> class with no arguments.
        /// </summary>
        protected WhippetCommandHandler()
        { }

        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Handle(IWhippetCommandHandlerContext<TCommand> handlerContext)
        {
            if(handlerContext == null)
            {
                throw new ArgumentNullException(nameof(handlerContext));
            }
            else
            {
                return Handle(handlerContext.Command);
            }
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Handle(TCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if(result.IsSuccess)
                {
                    result = Task.Run(() => HandleAsync(command)).Result;
                }

                return result;
            }
        }

        /// <summary>
        /// Handles the specified command asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResult> HandleAsync(TCommand command);

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> for errors before executing.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> that contains the result of the validation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual WhippetResult Validate(TCommand command)
        {
            return WhippetResult.Success;
        }
    }
}
