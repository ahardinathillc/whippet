using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="City"/> objects. This class must be inherited.
    /// </summary>
    public abstract class CityCommandBase : WhippetCommand, IWhippetCommand, ICityCommand
    {
        /// <summary>
        /// Gets the <see cref="Addressing.City"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public City City
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ICity"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        ICity ICityCommand.City
        {
            get
            {
                return City;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityCommandBase"/> class with no arguments.
        /// </summary>
        protected CityCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CityCommandBase"/> class with the specified <see cref="Addressing.City"/> object.
        /// </summary>
        /// <param name="city"><see cref="Addressing.City"/> object to initialize with.</param>
        protected CityCommandBase(City city)
            : this()
        {
            City = city;
        }
    }
}
