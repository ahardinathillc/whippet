using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetSettingGroup"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetSettingGroupCommand : WhippetSettingGroupCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSettingGroupCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetSettingGroupCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSettingGroupCommand"/> class with the specified <see cref="WhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetSettingGroup"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetSettingGroupCommand(WhippetSettingGroup group)
            : base(group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
        }
    }
}
