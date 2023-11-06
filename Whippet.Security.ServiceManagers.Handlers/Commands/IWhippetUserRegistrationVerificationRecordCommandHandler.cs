using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Commands;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetUserRegistrationVerificationRecordCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetUserRegistrationVerificationRecordCommand"/> object to handle.</typeparam>
    public interface IWhippetUserRegistrationVerificationRecordCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetUserRegistrationVerificationRecordCommand
    { }
}
