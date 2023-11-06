using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="IWhippetSetting"/> objects.
    /// </summary>
    public interface IWhippetSettingCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSetting"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IWhippetSetting Setting
        { get; }
    }
}
