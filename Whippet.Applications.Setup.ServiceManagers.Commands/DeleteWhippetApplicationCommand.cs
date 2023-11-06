using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetApplication"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetApplicationCommand : WhippetApplicationCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetApplicationCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetApplicationCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetApplicationCommand"/> class with the specified <see cref="WhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="WhippetApplication"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetApplicationCommand(WhippetApplication application)
            : base(application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
        }
    }
}
