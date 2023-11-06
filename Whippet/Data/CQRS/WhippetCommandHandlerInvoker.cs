using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Athi.Whippet.Reflection;
using Athi.Whippet.Services;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Generic command handler invocation helper class that can be used for loading the necessary contexts and handlers for executing <see cref="IWhippetCommand"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetCommandHandlerInvoker : IDisposable
    {
        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the command handler.
        /// </summary>
        private Type CommandHandlerType
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the command that is to be handled.
        /// </summary>
        private Type CommandType
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetServiceContext"/> used to locate and instantiate the necessary objects.
        /// </summary>
        private IWhippetServiceContext ServiceLocator
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandHandlerInvoker"/> class with no arguments.
        /// </summary>
        private WhippetCommandHandlerInvoker()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandHandlerInvoker"/> class with the specified parameters.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> used to locate and instantiate the necessary objects.</param>
        /// <param name="commandType"><see cref="Type"/> of the command that is to be handled.</param>
        /// <param name="commandHandlerType"><see cref="Type"/> of the command handler.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetCommandHandlerInvoker(IWhippetServiceContext serviceLocator, Type commandType, Type commandHandlerType)
            : this()
        {
            if(serviceLocator == null)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }
            else if(commandType == null)
            {
                throw new ArgumentNullException(nameof(commandType));
            }
            else if(commandHandlerType == null)
            {
                throw new ArgumentNullException(nameof(commandHandlerType));
            }
            else
            {
                ServiceLocator = serviceLocator;
                CommandType = commandType;
                CommandHandlerType = commandHandlerType;
            }
        }

        /// <summary>
        /// Executes the specified <see cref="IWhippetCommand"/>.
        /// </summary>
        /// <param name="command"><see cref="IWhippetCommand"/> object to execute.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetResult Execute(IWhippetCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandlerContext<IWhippetCommand> context = null;
                
                MethodInfo handlerMethod = null;
                
                object commandHandler = null;

                try
                {
                    context = (IWhippetCommandHandlerContext<IWhippetCommand>)(Activator.CreateInstance(typeof(WhippetCommandHandlerContext<>).MakeGenericType(CommandType), command));
                    handlerMethod = typeof(IWhippetCommandHandler<>).MakeGenericType(CommandType).GetMethod(nameof(IWhippetCommandHandler<IWhippetCommand>.Handle));
                    commandHandler = ServiceLocator.GetInstance(CommandHandlerType);

                    handlerMethod.Invoke(commandHandler, new object[] { context });
                }
                catch(Exception e)
                {
                    result = new WhippetResult(e);
                }
                finally
                {
                    if(commandHandler != null && (commandHandler is IDisposable))
                    {
                        ((IDisposable)(commandHandler)).Dispose();
                        commandHandler = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Sends the <see cref="IWhippetCommand"/> to the bus to be intercepted by the appropriate handler.
        /// </summary>
        /// <param name="command"><see cref="IWhippetCommand"/> object to push to the bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TargetInvocationException"></exception>
        public void Send(IWhippetCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Execute(command);

                if(!result.IsSuccess)
                {
                    throw new TargetInvocationException(result.Exception);
                }
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            if(ServiceLocator != null)
            {
                ServiceLocator.Dispose();
                ServiceLocator = null;
            }
        }

        /// <summary>
        /// Creates an <see cref="IReadOnlyDictionary{TKey, TValue}"/> of command handlers indexed by their respective command type.
        /// </summary>
        /// <param name="typeCatalog"><see cref="ITypeCatalog"/> object.</param>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that acts as a service locator.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<Type, WhippetCommandHandlerInvoker> CreateInvokerIndex(ITypeCatalog typeCatalog, IWhippetServiceContext serviceLocator)
        {
            if(typeCatalog == null)
            {
                throw new ArgumentNullException(nameof(typeCatalog));
            }
            else if(serviceLocator == null)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }
            else
            {
                Dictionary<Type, WhippetCommandHandlerInvoker> dict = new Dictionary<Type, WhippetCommandHandlerInvoker>();
                
                IEnumerable<Type> commandHandlerTypes = typeCatalog.GetGenericInterfaceImplementations(typeof(IWhippetCommandHandler<>));
                IEnumerable<Type> commandTypes = null;

                foreach(Type handlerType in commandHandlerTypes)
                {
                    commandTypes = (
                        from interfaceType in handlerType.GetInterfaces()
                        where interfaceType.IsGenericType
                            && interfaceType.GetGenericTypeDefinition().Equals(typeof(IWhippetCommandHandler<>))
                        select interfaceType.GetGenericArguments()[0]).ToList();

                    foreach(Type commandType in commandTypes)
                    {
                        dict.Add(commandType, new WhippetCommandHandlerInvoker(serviceLocator, commandType, handlerType));
                    }
                }

                return dict;
            }
        }
    }
}
