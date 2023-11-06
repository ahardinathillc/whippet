using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="Country"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateCountryCommand : CountryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCountryCommand"/> class with no arguments.
        /// </summary>
        private UpdateCountryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCountryCommand"/> class with the specified <see cref="Country"/>.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateCountryCommand(Country country)
            : base(country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
        }
    }
}
