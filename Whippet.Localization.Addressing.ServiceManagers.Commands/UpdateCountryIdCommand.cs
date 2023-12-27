using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="Country"/> object's ID in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateCountryIdCommand : CountryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Gets the new ID to assign to the <see cref="Country"/>. This property is read-only.
        /// </summary>
        public Guid NewID
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCountryIdCommand"/> class with no arguments.
        /// </summary>
        private UpdateCountryIdCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCountryIdCommand"/> class with the specified <see cref="Country"/> and ID.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to initialize with.</param>
        /// <param name="newId">New ID to assign to the <see cref="Country"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateCountryIdCommand(Country country, Guid newId)
            : base(country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            NewID = newId;
        }
    }
}
