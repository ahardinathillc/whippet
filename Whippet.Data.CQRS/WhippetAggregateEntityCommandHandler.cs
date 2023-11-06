using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Services;

namespace Athi.Whippet.Data.CQRS
{
    public abstract class WhippetAggregateEntityCommandHandler<TCommand, TAggregateRoot> : WhippetCommandHandler<TCommand>, IWhippetAggregateEntityCommandHandler<TCommand>
        where TCommand : IWhippetAggregateEntityCommand
        where TAggregateRoot : WhippetAggregateRoot, new()
    {
        /// <summary>
        /// Gets the <see cref="IWhippetDomainRepository"/> used to retrieve <see cref="WhippetAggregateRoot"/> objects. This property is read-only.
        /// </summary>
        protected IWhippetDomainRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCommandHandler{TCommand, TAggregateRoot}"/> class using the default service locator to load an <see cref="IWhippetDomainRepository"/> object.
        /// </summary>
        /// <exception cref="DefaultServiceLocatorNotConfiguredException" />
        protected WhippetAggregateEntityCommandHandler()
            : this(WhippetServiceLocator.Current?.GetInstance<IWhippetDomainRepository>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCommandHandler{TCommand, TAggregateRoot}"/> class using the specified <see cref="IWhippetDomainRepository"/> object to load <typeparamref name="TAggregateRoot"/> objects or <see langword="null"/> to use the default service locator.
        /// </summary>
        /// <param name="domainRepository"><see cref="IWhippetDomainRepository"/> object to use to load <typeparamref name="TAggregateRoot"/> objects.</param>
        /// <exception cref="DefaultServiceLocatorNotConfiguredException" />
        protected WhippetAggregateEntityCommandHandler(IWhippetDomainRepository domainRepository)
            : base()
        {
            if(domainRepository == null)
            {
                if(WhippetServiceLocator.DefaultServiceLocatorConfigured)
                {
                    Repository = WhippetServiceLocator.Current.GetInstance<IWhippetDomainRepository>();
                }
                else
                {
                    throw new DefaultServiceLocatorNotConfiguredException(null, new ArgumentNullException(nameof(domainRepository)));
                }
            }
            else
            {
                Repository = domainRepository;
            }
        }

        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidCastException" />
        WhippetResult IWhippetCommandHandler<TCommand>.Handle(IWhippetCommandHandlerContext<TCommand> handlerContext)
        {
            if(handlerContext == null)
            {
                throw new ArgumentNullException(nameof(handlerContext));
            }
            else if(!(handlerContext is IWhippetAggregateEntityCommandHandlerContext<TCommand>))
            {
                throw new InvalidCastException();
            }
            else
            {
                return Handle(handlerContext as IWhippetAggregateEntityCommandHandlerContext<TCommand>);
            }
        }

        /// <summary>
        /// Handles the specified command based on its given context.
        /// </summary>
        /// <param name="handlerContext"><see cref="IWhippetAggregateEntityCommandHandlerContext{TCommand}"/> that wraps the <typeparamref name="TCommand"/> object.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Handle(IWhippetAggregateEntityCommandHandlerContext<TCommand> handlerContext)
        {
            if(handlerContext == null)
            {
                throw new ArgumentNullException(nameof(handlerContext));
            }
            else
            {
                TAggregateRoot aggregateRoot = Repository.Get<TAggregateRoot>(handlerContext.Command.AggregateRootID);
                WhippetResult result = Validate(handlerContext.Command, aggregateRoot);

                if(result.IsSuccess)
                {
                    result = Handle(handlerContext.Command, aggregateRoot);
                }

                if(aggregateRoot != null)
                {
                    try
                    {
                        Repository.Save(aggregateRoot);
                    }
                    catch(Exception e)
                    {
                        result = new WhippetResult(e);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Handles the specified command. This method must be overridden.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResult Handle(TCommand command)
        {
            return Handle(command, null);
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidCastException" />
        WhippetResult IWhippetAggregateEntityCommandHandler<TCommand>.Handle(TCommand command, WhippetAggregateRoot aggregateRoot)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else if((aggregateRoot != null) && !(aggregateRoot is TAggregateRoot))
            {
                throw new InvalidCastException();
            }
            else
            {
                return Handle(command, (TAggregateRoot)(aggregateRoot));
            }
        }

        /// <summary>
        /// Handles the specified <typeparamref name="TCommand"/> object.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to handle.</param>
        /// <param name="aggregateRoot"><typeparamref name="TAggregateRoot"/> object associated with the command.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResult Handle(TCommand command, TAggregateRoot aggregateRoot);

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> for errors before executing.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> that contains the result of the validation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected override WhippetResult Validate(TCommand command)
        {
            return Validate(command, null);
        }

        /// <summary>
        /// Validates the specified <typeparamref name="TCommand"/> for errors before executing. This method must be overridden.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to validate.</param>
        /// <param name="aggregateRoot"><typeparamref name="TAggregateRoot"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> that contains the result of the validation.</returns>
        /// <exception cref="ArgumentNullException" />
        protected abstract WhippetResult Validate(TCommand command, TAggregateRoot aggregateRoot);
    }
}
