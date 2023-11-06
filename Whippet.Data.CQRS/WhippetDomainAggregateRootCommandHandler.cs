using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Services;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Command handler for <see cref="WhippetAggregateEntityCommand"/> command objects. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetAggregateEntityCommand"/> object to handle.</typeparam>
    /// <typeparam name="TAggregateRoot"><see cref="WhippetAggregateRoot"/> object associated with the commands.</typeparam>
    public abstract class WhippetDomainAggregateRootCommandHandler<TCommand, TAggregateRoot> : IWhippetAggregateEntityCommandHandler<TCommand>, IWhippetCommandHandler<TCommand>
        where TCommand : IWhippetAggregateEntityCommand, IWhippetCommand
        where TAggregateRoot : WhippetAggregateRoot, new()
    {
        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetDomainRepository"/>.
        /// </summary>
        private IWhippetDomainRepository DomainRepository
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainAggregateRootCommandHandler{TCommand, TAggregateRoot}"/> class with no arguments.
        /// </summary>
        protected WhippetDomainAggregateRootCommandHandler()
            : this(WhippetServiceLocator.Current?.GetInstance<IWhippetDomainRepository>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainAggregateRootCommandHandler{TCommand, TAggregateRoot}"/> class with the specified <see cref="IWhippetDomainRepository"/> object.
        /// </summary>
        /// <param name="domainRepository"><see cref="IWhippetDomainRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetDomainAggregateRootCommandHandler(IWhippetDomainRepository domainRepository)
        { 
            if(domainRepository == null)
            {
                throw new ArgumentNullException(nameof(domainRepository));
            }
            else
            {
                DomainRepository = domainRepository;
            }
        }

        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetAggregateEntityCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult IWhippetAggregateEntityCommandHandler<TCommand>.Handle(IWhippetAggregateEntityCommandHandlerContext<TCommand> handlerContext)
        {
            return ((IWhippetCommandHandler<TCommand>)(this)).Handle(handlerContext);
        }

        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult IWhippetCommandHandler<TCommand>.Handle(IWhippetCommandHandlerContext<TCommand> handlerContext)
        {
            if (handlerContext == null)
            {
                throw new ArgumentNullException(nameof(handlerContext));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                TCommand command = handlerContext.Command;
                TAggregateRoot aggregateRoot = null;

                try
                {
                    aggregateRoot = DomainRepository.Get<TAggregateRoot>(command.AggregateRootID);

                    result = Validate(handlerContext, command, aggregateRoot);

                    if (result.IsSuccess)
                    {
                        result = Handle(command, aggregateRoot);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> command object to handle.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        WhippetResult IWhippetCommandHandler<TCommand>.Handle(TCommand command)
        {
            return new WhippetResult(new InvalidOperationException());
        }

        /// <summary>
        /// Handles the specified command asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<WhippetResult> IWhippetCommandHandler<TCommand>.HandleAsync(TCommand command)
        {
            return await Task.Run(() => new WhippetResult(new InvalidOperationException()));
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResult Handle(TCommand command, WhippetAggregateRoot aggregateRoot);

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> for errors before executing. This method must be overridden.
        /// </summary>
        /// <param name="handlerContext">Context in which the command handler is executing.</param>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <param name="aggregateRoot">Aggregate root associated with the command.</param>
        /// <returns><see cref="WhippetResult"/> that contains the result of the validation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected abstract WhippetResult Validate(IWhippetCommandHandlerContext<TCommand> handlerContext, TCommand command, TAggregateRoot aggregateRoot);
    }
}
