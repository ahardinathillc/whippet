using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetGroupUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetGroupUserAssignmentCommand : WhippetGroupUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetGroupUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetGroupUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetGroupUserAssignmentCommand"/> class with the specified <see cref="WhippetGroupUserAssignment"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroupUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetGroupUserAssignmentCommand(WhippetGroupUserAssignment group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}

