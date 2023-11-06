using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="WhippetSettingGroup"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateWhippetSettingGroupCommand : WhippetSettingGroupCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetSettingGroupCommand"/> class with no arguments.
        /// </summary>
        private CreateWhippetSettingGroupCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWhippetSettingGroupCommand"/> class with the specified <see cref="WhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetSettingGroup"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateWhippetSettingGroupCommand(WhippetSettingGroup group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}
