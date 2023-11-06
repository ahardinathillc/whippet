using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetUserRegistrationVerificationRecord"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetUserRegistrationVerificationRecordCommand : WhippetUserRegistrationVerificationRecordCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetUserRegistrationVerificationRecordCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetUserRegistrationVerificationRecordCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetUserRegistrationVerificationRecordCommand"/> class with the specified <see cref="WhippetUserRegistrationVerificationRecord"/>.
        /// </summary>
        /// <param name="record"><see cref="WhippetUserRegistrationVerificationRecord"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetUserRegistrationVerificationRecordCommand(WhippetUserRegistrationVerificationRecord record)
            : base(record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
        }
    }
}
