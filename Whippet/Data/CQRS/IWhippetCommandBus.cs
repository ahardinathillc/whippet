using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides an event bus for <see cref="IWhippetCommand"/> objects.
    /// </summary>
    public interface IWhippetCommandBus
    {
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> object type.</typeparam>
        /// <param name="command"><see cref="IWhippetCommand"/> object to execute.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResult Execute<TCommand>(TCommand command) where TCommand : IWhippetCommand;

        /// <summary>
        /// Sends the command to the bus to be intercepted by its appropriate handler.
        /// </summary>
        /// <typeparam name="TCommand"><see cref="IWhippetCommand"/> object type.</typeparam>
        /// <param name="command"><see cref="IWhippetCommand"/> object to push onto the bus.</param>
        /// <exception cref="ArgumentNullException" />
        void Send<TCommand>(TCommand command) where TCommand : IWhippetCommand;
    }
}
