using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetSmtpServerProfile"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetSmtpServerProfileCommand : WhippetSmtpServerProfileCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSmtpServerProfileCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetSmtpServerProfileCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSmtpServerProfileCommand"/> class with the specified <see cref="WhippetSmtpServerProfile"/>.
        /// </summary>
        /// <param name="profile"><see cref="WhippetSmtpServerProfile"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetSmtpServerProfileCommand(WhippetSmtpServerProfile profile)
            : base(profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
        }
    }
}
