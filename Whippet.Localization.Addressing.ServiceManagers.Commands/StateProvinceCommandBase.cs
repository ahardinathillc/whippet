using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="StateProvince"/> objects. This class must be inherited.
    /// </summary>
    public abstract class StateProvinceCommandBase : WhippetCommand, IWhippetCommand, IStateProvinceCommand
    {
        /// <summary>
        /// Gets the <see cref="StateProvince"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public StateProvince State
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IStateProvince"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IStateProvince IStateProvinceCommand.State
        {
            get
            {
                return State;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceCommandBase"/> class with no arguments.
        /// </summary>
        protected StateProvinceCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvinceCommandBase"/> class with the specified <see cref="StateProvince"/> object.
        /// </summary>
        /// <param name="state"><see cref="StateProvince"/> object to initialize with.</param>
        protected StateProvinceCommandBase(StateProvince state)
            : this()
        {
            State = state;
        }
    }
}
