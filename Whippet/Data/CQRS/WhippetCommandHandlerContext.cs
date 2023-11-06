using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides a contextualized container for <see cref="IWhippetCommand"/> objects to be executed by a handler. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> to be handled.</typeparam>
    public abstract class WhippetCommandHandlerContext<TCommand> : IWhippetCommandHandlerContext<TCommand> where TCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetCommand"/> object that is to be executed. This property is read-only.
        /// </summary>
        public TCommand Command
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandHandlerContext{TCommand}"/> class with no arguments.
        /// </summary>
        private WhippetCommandHandlerContext()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCommandHandlerContext{TCommand}"/> class with the specified <typeparamref name="TCommand"/> object.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetCommandHandlerContext(TCommand command)
            : this()
        { 
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                Command = command;
            }
        }
    }
}
