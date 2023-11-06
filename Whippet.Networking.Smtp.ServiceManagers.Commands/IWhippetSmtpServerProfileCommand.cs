using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IWhippetSmtpServerProfile"/> objects.
    /// </summary>
    public interface IWhippetSmtpServerProfileCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSmtpServerProfile"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetSmtpServerProfile ServerProfile
        { get; }
    }
}
