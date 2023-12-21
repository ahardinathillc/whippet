using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="LegacySuperDuperAccount"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateLegacySuperDuperAccountCommand : LegacySuperDuperAccountCommandBase, ILegacySuperDuperAccountCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLegacySuperDuperAccountCommand"/> class with the specified <see cref="LegacySuperDuperAccount"/> object.
        /// </summary>
        /// <param name="account"><see cref="LegacySuperDuperAccount"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateLegacySuperDuperAccountCommand(LegacySuperDuperAccount account)
            : base(account)
        {
            ArgumentNullException.ThrowIfNull(account);
        }
    }
}
