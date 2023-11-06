using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="WhippetSetting"/> objects.
    /// </summary>
    public class WhippetSettingCommandBase : WhippetCommand, IWhippetCommand, IWhippetSettingCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetSetting"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetSetting Setting
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetSetting"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetSetting IWhippetSettingCommand.Setting
        {
            get
            {
                return Setting;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetSettingCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="setting"><see cref="WhippetSetting"/> instance to create or act upon in the data store.</param>
        protected WhippetSettingCommandBase(WhippetSetting setting)
            : base()
        {
            Setting = setting;
        }
    }
}
