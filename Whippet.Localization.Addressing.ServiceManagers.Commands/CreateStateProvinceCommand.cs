using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="StateProvince"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateStateProvinceCommand : StateProvinceCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStateProvinceCommand"/> class with no arguments.
        /// </summary>
        private CreateStateProvinceCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStateProvinceCommand"/> class with the specified <see cref="StateProvince"/>.
        /// </summary>
        /// <param name="state"><see cref="StateProvince"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateStateProvinceCommand(StateProvince state)
            : base(state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }
}
