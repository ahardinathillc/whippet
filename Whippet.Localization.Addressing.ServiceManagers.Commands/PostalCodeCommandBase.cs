using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="PostalCode"/> objects. This class must be inherited.
    /// </summary>
    public abstract class PostalCodeCommandBase : WhippetCommand, IWhippetCommand, IPostalCodeCommand
    {
        /// <summary>
        /// Gets the <see cref="Addressing.PostalCode"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public PostalCode PostalCode
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IPostalCode"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IPostalCode IPostalCodeCommand.PostalCode
        {
            get
            {
                return PostalCode;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeCommandBase"/> class with no arguments.
        /// </summary>
        protected PostalCodeCommandBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostalCodeCommandBase"/> class with the specified <see cref="Addressing.PostalCode"/> object.
        /// </summary>
        /// <param name="postalCode"><see cref="Addressing.PostalCode"/> object to initialize with.</param>
        protected PostalCodeCommandBase(PostalCode postalCode)
            : this()
        {
            PostalCode = postalCode;
        }
    }
}
