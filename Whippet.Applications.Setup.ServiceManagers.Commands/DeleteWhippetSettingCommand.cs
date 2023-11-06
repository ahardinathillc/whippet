using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="WhippetSetting"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteWhippetSettingCommand : WhippetSettingCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSettingCommand"/> class with no arguments.
        /// </summary>
        private DeleteWhippetSettingCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWhippetSettingCommand"/> class with the specified <see cref="WhippetSetting"/>.
        /// </summary>
        /// <param name="setting"><see cref="WhippetSetting"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteWhippetSettingCommand(WhippetSetting setting)
            : base(setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
        }
    }
}
