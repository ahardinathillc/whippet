using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="PostalCode"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdatePostalCodeCommand : PostalCodeCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePostalCodeCommand"/> class with no arguments.
        /// </summary>
        private UpdatePostalCodeCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePostalCodeCommand"/> class with the specified <see cref="PostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="PostalCode"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdatePostalCodeCommand(PostalCode postalCode)
            : base(postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
        }
    }
}
