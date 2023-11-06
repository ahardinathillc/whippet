using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Commands;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetSmtpServerProfile"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetSmtpServerProfileCommand"/> object to handle.</typeparam>
    public interface IWhippetSmtpServerProfileCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetSmtpServerProfileCommand
    { }
}
