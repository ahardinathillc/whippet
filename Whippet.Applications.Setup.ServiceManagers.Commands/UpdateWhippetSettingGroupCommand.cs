using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetSettingGroup"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetSettingGroupCommand : WhippetSettingGroupCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetSettingGroupCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetSettingGroupCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetSettingGroupCommand"/> class with the specified <see cref="WhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetSettingGroup"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetSettingGroupCommand(WhippetSettingGroup group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}
