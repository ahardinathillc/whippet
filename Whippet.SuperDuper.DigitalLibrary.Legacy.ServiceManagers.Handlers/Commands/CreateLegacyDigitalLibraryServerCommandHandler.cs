﻿using System;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Command handler for <see cref="CreateLegacyDigitalLibraryServerCommand"/> objects.
    /// </summary>
    public class CreateLegacyDigitalLibraryServerCommandHandler : LegacyDigitalLibraryServerCommandHandlerBase<CreateLegacyDigitalLibraryServerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLegacyDigitalLibraryServerCommandHandler"/> class with the specified <see cref="ILegacyDigitalLibraryServerRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacyDigitalLibraryServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public CreateLegacyDigitalLibraryServerCommandHandler(ILegacyDigitalLibraryServerRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command"><see cref="CreateLegacyDigitalLibraryServerCommand"/> object to handle.</param>
        /// <returns><see cref="WhippetResult"/> which contains the result of the command.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResult> HandleAsync(CreateLegacyDigitalLibraryServerCommand command)
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
                    result = await Repository.CreateAsync(command.Server);
                }

                return result;
            }
        }

        /// <summary>
        /// Validates the specified <see cref="CreateLegacyDigitalLibraryServerCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="CreateLegacyDigitalLibraryServerCommand"/> object to validate.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        protected override WhippetResult Validate(CreateLegacyDigitalLibraryServerCommand command)
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