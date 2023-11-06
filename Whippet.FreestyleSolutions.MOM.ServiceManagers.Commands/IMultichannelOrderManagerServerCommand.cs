using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands
{
    /// <summary>
    /// Provides support for all commands that act upon <see cref="IMultichannelOrderManagerServer"/> objects.
    /// </summary>
    public interface IMultichannelOrderManagerServerCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerServer"/> instance to create or act upon in the data store. This property is read-only.
        /// </summary>
        IMultichannelOrderManagerServer Server
        { get; }
    }
}
