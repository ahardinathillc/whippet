using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="LegacySuperDuperAccount"/> objects. This class must be inherited.
    /// </summary>
    public abstract class LegacySuperDuperAccountCommandBase : WhippetCommand, IWhippetCommand, ILegacySuperDuperAccountCommand
    {
        private readonly LegacySuperDuperAccount _Account;

        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public LegacySuperDuperAccount Account
        {
            get
            {
                return _Account;
            }
        }

        /// <summary>
        /// Gets the <see cref="ILegacySuperDuperAccount"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ILegacySuperDuperAccount ILegacySuperDuperAccountCommand.Account
        {
            get
            {
                return Account;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountCommandBase"/> class with no arguments.
        /// </summary>
        protected LegacySuperDuperAccountCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="account"><see cref="LegacySuperDuperAccount"/> instance to create or act upon in the data store.</param>
        protected LegacySuperDuperAccountCommandBase(LegacySuperDuperAccount account)
            : base()
        {
            _Account = account;
        }
    }
}
