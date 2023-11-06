using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all <see cref="IWhippetUserRegistrationVerificationRecordCommand"/> objects. This class must be inherited.
    /// </summary>
    public abstract class WhippetUserRegistrationVerificationRecordCommandBase : WhippetCommand, IWhippetCommand, IWhippetUserRegistrationVerificationRecordCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetUserRegistrationVerificationRecord"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetUserRegistrationVerificationRecord VerificationRecord
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetUserRegistrationVerificationRecord"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetUserRegistrationVerificationRecord IWhippetUserRegistrationVerificationRecordCommand.VerificationRecord
        { 
            get
            {
                return VerificationRecord;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetUserRegistrationVerificationRecordCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserCommandBase"/> class.
        /// </summary>
        /// <param name="record"><see cref="WhippetUserRegistrationVerificationRecord"/> instance to create or act upon in the data store.</param>
        protected WhippetUserRegistrationVerificationRecordCommandBase(WhippetUserRegistrationVerificationRecord record)
            : base()
        {
            VerificationRecord = record;
        }
    }
}
