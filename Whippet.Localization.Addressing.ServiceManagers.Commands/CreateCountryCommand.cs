using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="Country"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateCountryCommand : CountryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCountryCommand"/> class with no arguments.
        /// </summary>
        private CreateCountryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCountryCommand"/> class with the specified <see cref="Country"/>.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateCountryCommand(Country country)
            : base(country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
        }
    }
}
