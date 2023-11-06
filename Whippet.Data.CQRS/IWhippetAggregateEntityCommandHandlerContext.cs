using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides a contextualized container for <see cref="IWhippetAggregateEntityCommand"/> objects to be executed by a handler.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> to be handled.</typeparam>
    public interface IWhippetAggregateEntityCommandHandlerContext<out TCommand> : IWhippetCommandHandlerContext<TCommand> where TCommand : IWhippetAggregateEntityCommand
    { }
}
