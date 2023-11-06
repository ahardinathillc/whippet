using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="Country"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteCountryCommand : CountryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCountryCommand"/> class with no arguments.
        /// </summary>
        private DeleteCountryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCountryCommand"/> class with the specified <see cref="Country"/>.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteCountryCommand(Country country)
            : base(country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
        }
    }
}
