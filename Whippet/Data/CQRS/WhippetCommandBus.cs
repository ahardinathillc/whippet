using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Reflection;
using Athi.Whippet.Services;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Represents a default command bus implementaiton of <see cref="IWhippetCommandBus"/>.
    /// </summary>
    public class WhippetCommandBus : IWhippetCommandBus
    {
        /// <summary>
        /// Gets or sets the internal read-only collection of Whippet command handler invocation helper objects.
        /// </summary>
        private IReadOnlyDictionary<Type, WhippetCommandHandlerInvoker> CommandInvokers
        { get; set; }

        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetServiceContext"/> object that acts as a service locator.
        /// </summary>
        private IWhippetServiceContext ServiceLocator
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandBus"/> class with no arguments.
        /// </summary>
        private WhippetCommandBus()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandBus"/> class with the specified parameters.
        /// </summary>
        /// <param name="typeCatalog"><see cref="ITypeCatalog"/> object.</param>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetCommandBus(ITypeCatalog typeCatalog, IWhippetServiceContext serviceLocator)
            : this()
        {
            if(typeCatalog == null)
            {
                throw new ArgumentNullException(nameof(typeCatalog));
            }
            else if(serviceLocator == null && !WhippetServiceLocator.DefaultServiceLocatorConfigured)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }
            else
            {
                serviceLocator = serviceLocator ?? WhippetServiceLocator.Current;
                
                CommandInvokers = WhippetCommandHandlerInvoker.CreateInvokerIndex(typeCatalog, serviceLocator);
            }
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> object type.</typeparam>
        /// <param name="command"><see cref="IWhippetCommand"/> object to execute.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Execute<TCommand>(TCommand command) where TCommand : IWhippetCommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                WhippetCommandHandlerInvoker invoker = null;

                try
                {
                    if(!CommandInvokers.TryGetValue(command.GetType(), out invoker))
                    {
                        throw new CommandHandlerNotFoundException(command.GetType());
                    }
                    else
                    {
                        result = invoker.Execute(command);
                    }
                }
                catch(Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Sends the command to the bus to be intercepted by its appropriate handler.
        /// </summary>
        /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> object type.</typeparam>
        /// <param name="command"><see cref="IWhippetCommand"/> object to push onto the bus.</param>
        /// <exception cref="ArgumentNullException" />
        public void Send<TCommand>(TCommand command) where TCommand : IWhippetCommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetCommandHandlerInvoker invoker = null;

                if (!CommandInvokers.TryGetValue(command.GetType(), out invoker))
                {
                    throw new CommandHandlerNotFoundException(command.GetType());
                }
                else
                {
                    invoker.Send(command);
                }
            }
        }
    }
}
