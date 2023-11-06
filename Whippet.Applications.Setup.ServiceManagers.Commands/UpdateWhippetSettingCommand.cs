using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="WhippetSetting"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateWhippetSettingCommand : WhippetSettingCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetSettingCommand"/> class with no arguments.
        /// </summary>
        private UpdateWhippetSettingCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWhippetSettingCommand"/> class with the specified <see cref="WhippetSetting"/>.
        /// </summary>
        /// <param name="setting"><see cref="WhippetSetting"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateWhippetSettingCommand(WhippetSetting setting)
            : base(setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
        }
    }
}
