using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="WhippetGroupUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateWhippetGroupUserAssignmentCommand : WhippetGroupUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetGroupUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private CreateWhippetGroupUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetGroupUserAssignmentCommand"/> class with the specified <see cref="WhippetGroupUserAssignment"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroupUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateWhippetGroupUserAssignmentCommand(WhippetGroupUserAssignment group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}

