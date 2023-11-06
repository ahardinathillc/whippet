using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="StateProvince"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteStateProvinceCommand : StateProvinceCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStateProvinceCommand"/> class with no arguments.
        /// </summary>
        private DeleteStateProvinceCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStateProvinceCommand"/> class with the specified <see cref="StateProvince"/>.
        /// </summary>
        /// <param name="state"><see cref="StateProvince"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteStateProvinceCommand(StateProvince state)
            : base(state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }
}
