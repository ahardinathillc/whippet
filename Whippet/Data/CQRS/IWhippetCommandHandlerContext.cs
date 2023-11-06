using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides a contextualized container for <see cref="IWhippetCommand"/> objects to be executed by a handler.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> to be handled.</typeparam>
    public interface IWhippetCommandHandlerContext<out TCommand> where TCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetCommand"/> object that is to be executed. This property is read-only.
        /// </summary>
        TCommand Command
        { get; }
    }
}
