using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Represents an individual action that is executed by an <see cref="IInstaller"/> instance.
    /// </summary>
    public interface IInstallerAction
    {
        /// <summary>
        /// Indicates whether the action supports asynchronous execution. This property is read-only.
        /// </summary>
        bool SupportsAsync
        { get; }
        
        /// <summary>
        /// Gets a description of the current action being performed. This property is read-only.
        /// </summary>
        string Action
        { get; }
        
        /// <summary>
        /// Executes the current action with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<object> Execute(params object[] args);

        /// <summary>
        /// When overridden in a derived class, executes the current action asynchronously with the specified parameters. If not overridden, this method returns <see langword="null"/>.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<object>> ExecuteAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken));
    }
}
