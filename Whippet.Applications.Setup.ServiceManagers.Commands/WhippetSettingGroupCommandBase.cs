using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="WhippetSettingGroup"/> objects.
    /// </summary>
    public class WhippetSettingGroupCommandBase : WhippetCommand, IWhippetCommand, IWhippetSettingGroupCommand
    {
        /// <summary>
        /// Gets the <see cref="WhippetSettingGroup"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        public WhippetSettingGroup Group
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroup"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetSettingGroup IWhippetSettingGroupCommand.Group
        {
            get
            {
                return Group;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupCommandBase"/> class with no arguments.
        /// </summary>
        protected WhippetSettingGroupCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupCommandBase"/> class with no arguments.
        /// </summary>
        /// <param name="group"><see cref="WhippetSettingGroup"/> instance to create or act upon in the data store.</param>
        protected WhippetSettingGroupCommandBase(WhippetSettingGroup group)
            : base()
        {
            Group = group;
        }
    }
}
