using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="City"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteCityCommand : CityCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCityCommand"/> class with no arguments.
        /// </summary>
        private DeleteCityCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCityCommand"/> class with the specified <see cref="City"/>.
        /// </summary>
        /// <param name="city"><see cref="City"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteCityCommand(City city)
            : base(city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
        }
    }
}
