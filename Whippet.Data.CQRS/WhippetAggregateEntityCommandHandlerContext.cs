using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides a contextualized container for <see cref="IWhippetAggregateEntityCommand"/> objects to be executed by a handler. This class must be inherited.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> to be handled.</typeparam>
    public abstract class WhippetAggregateEntityCommandHandlerContext<TCommand> : WhippetCommandHandlerContext<TCommand>, IWhippetAggregateEntityCommandHandlerContext<TCommand>, IWhippetCommandHandlerContext<TCommand> where TCommand : IWhippetAggregateEntityCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAggregateEntityCommandHandlerContext{TCommand}"/> class with the specified <typeparamref name="TCommand"/> object.
        /// </summary>
        /// <param name="command"><typeparamref name="TCommand"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetAggregateEntityCommandHandlerContext(TCommand command)
            : base(command)
        { }
    }
}
