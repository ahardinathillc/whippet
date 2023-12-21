using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Install runner for the core Whippet application framework.
    /// </summary>
    [Obsolete("This component is deprecated and will be removed in a future version.")]
    public interface IWhippetInstallRunner : IDisposable, IInstallAction
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> used to set the current database connection. This property is read-only.
        /// </summary>
        ISession Session
        { get; }
    }
}
