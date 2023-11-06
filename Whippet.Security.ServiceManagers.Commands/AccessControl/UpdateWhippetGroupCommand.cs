using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetGroup"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetGroupCommand : WhippetGroupCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetGroupCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetGroupCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetGroupCommand"/> class with the specified <see cref="WhippetGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroup"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetGroupCommand(WhippetGroup group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}

