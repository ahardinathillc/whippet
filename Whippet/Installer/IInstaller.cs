using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Represents an installer in the Whippet framework.
    /// </summary>
    public interface IInstaller
    {
        /// <summary>
        /// Indicates whether the installer supports asynchronous execution. This property is read-only.
        /// </summary>
        bool SupportsAsync
        { get; }
        
        /// <summary>
        /// Executes the current installer with the provided arguments.
        /// </summary>
        /// <param name="args">Arguments to supply to the install actions (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<object> Install(params object[] args);

        /// <summary>
        /// When overridden in a derived class, executes the current installer asynchronously with the specified parameters. If not overridden, this method returns <see langword="null"/>.
        /// </summary>
        /// <param name="args">Parameters to pass to the installer actions (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<object>> InstallAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken));
    }
}
