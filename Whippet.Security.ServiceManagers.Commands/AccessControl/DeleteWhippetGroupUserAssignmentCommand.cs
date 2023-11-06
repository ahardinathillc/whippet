using System;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetGroupUserAssignment"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetGroupUserAssignmentCommand : WhippetGroupUserAssignmentCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetGroupUserAssignmentCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetGroupUserAssignmentCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetGroupUserAssignmentCommand"/> class with the specified <see cref="WhippetGroupUserAssignment"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetGroupUserAssignment"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetGroupUserAssignmentCommand(WhippetGroupUserAssignment group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}

