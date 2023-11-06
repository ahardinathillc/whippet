using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetUserRegistrationVerificationRecord"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetUserRegistrationVerificationRecordCommand : WhippetUserRegistrationVerificationRecordCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetUserRegistrationVerificationRecordCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetUserRegistrationVerificationRecordCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetUserRegistrationVerificationRecordCommand"/> class with the specified <see cref="WhippetUserRegistrationVerificationRecord"/>.
        /// </summary>
        /// <param name="record"><see cref="WhippetUserRegistrationVerificationRecord"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetUserRegistrationVerificationRecordCommand(WhippetUserRegistrationVerificationRecord record)
            : base(record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }
        }
    }
}
