using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="StateProvince"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateStateProvinceCommand : StateProvinceCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStateProvinceCommand"/> class with no arguments.
        /// </summary>
        private UpdateStateProvinceCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStateProvinceCommand"/> class with the specified <see cref="StateProvince"/>.
        /// </summary>
        /// <param name="state"><see cref="StateProvince"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateStateProvinceCommand(StateProvince state)
            : base(state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }
}
