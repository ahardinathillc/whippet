using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="Country"/> objects. This class must be inherited.
    /// </summary>
    public abstract class CountryCommandBase : WhippetCommand, IWhippetCommand, ICountryCommand
    {
        /// <summary>
        /// Gets the <see cref="Addressing.Country"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public Country Country
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ICountry"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ICountry ICountryCommand.Country
        {
            get
            {
                return Country;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCommandBase"/> class with no arguments.
        /// </summary>
        protected CountryCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCommandBase"/> class with the specified <see cref="Country"/> object.
        /// </summary>
        /// <param name="country"><see cref="Country"/> object to initialize with.</param>
        protected CountryCommandBase(Country country)
            : this()
        {
            Country = country;
        }
    }
}
