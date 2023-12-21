using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="LegacySuperDuperAccount"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateLegacySuperDuperAccountCommand : LegacySuperDuperAccountCommandBase, ILegacySuperDuperAccountCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLegacySuperDuperAccountCommand"/> class with the specified <see cref="LegacySuperDuperAccount"/> object.
        /// </summary>
        /// <param name="account"><see cref="LegacySuperDuperAccount"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateLegacySuperDuperAccountCommand(LegacySuperDuperAccount account)
            : base(account)
        {
            ArgumentNullException.ThrowIfNull(account);
        }
    }
}
