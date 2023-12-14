using System;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="DeleteLegacyDigitalLibraryServerCommand"/> objects.
    /// </summary>
    public class DeleteLegacyDigitalLibraryServerCommandHandler : LegacyDigitalLibraryServerCommandHandlerBase<DeleteLegacyDigitalLibraryServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLegacyDigitalLibraryServerCommandHandler"/> class with the specified <see cref="ILegacyDigitalLibraryServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacyDigitalLibraryServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public DeleteLegacyDigitalLibraryServerCommandHandler(ILegacyDigitalLibraryServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="DeleteLegacyDigitalLibraryServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(DeleteLegacyDigitalLibraryServerCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                WhippetResult result = Validate(command);

                if (result.IsSuccess)
                {
                    result = await Repository.DeleteAsync(command.Server);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="DeleteLegacyDigitalLibraryServerCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="DeleteLegacyDigitalLibraryServerCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(DeleteLegacyDigitalLibraryServerCommand command)
        {
            WhippetResult result = WhippetResult.Success;

            if (command == null || command.Server == null)
            {
                result = new WhippetResult(new ArgumentNullException(nameof(command)));
            }

            return result;
        }        
    }
}
