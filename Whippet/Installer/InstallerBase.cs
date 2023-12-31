using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
//using Athi.Whippet.Collections.Extensions;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Base class for all installers in the Whippet framework. This class must be inherited.
    /// </summary>
    public abstract class InstallerBase : IInstaller
    {
        private SortedList<int, IInstallerAction> _actions;
        
        /// <summary>
        /// Gets the <see cref="SortedList{TKey,TValue}"/> of <see cref="IInstallerAction"/> actions to perform sorted by their execution order. This property is read-only.
        /// </summary>
        protected SortedList<int, IInstallerAction> Actions
        {
            get
            {
                if (_actions == null)
                {
                    _actions = new SortedList<int, IInstallerAction>();
                }

                return _actions;
            }
        }
        
        /// <summary>
        /// Indicates whether the installer supports asynchronous execution. This property must be overridden. This property is read-only.
        /// </summary>
        public abstract bool SupportsAsync
        { get; }
        
        /// <summary>
        /// Gets or sets an <see cref="Action{T1, T2}"/> that updates the current progress percentage of the task execution. 
        /// </summary>
        private Action<string, double> UpdateStatusAndProgressPercentage
        { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="Action{T}"/> that updates the current progress percentage of the task execution. 
        /// </summary>
        private Action<double> UpdateProgressPercentage
        { get; set; }
        
        /// <summary>
        /// Gets an <see cref="Action{T}"/> that handles caught exceptions and processes them, such as logging. 
        /// </summary>
        protected virtual Action<Exception> ErrorHandler
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerBase"/> class with no arguments.
        /// </summary>
        private InstallerBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerBase"/> class with the specified parameters.
        /// </summary>
        /// <param name="actions">Collection of <see cref="IInstallerAction"/> actions to perform sorted by their execution order.</param>
        /// <param name="updateProgressPercentage"><see cref="Action{T}"/> that updates the current progress percentage of the task execution.</param>
        /// <param name="updateStatusAndProgressPercentage"><see cref="Action{T1, T2}"/> that updates the current progress percentage of the task execution.</param>
        /// <param name="errorHandler"><see cref="Action{T}"/> that handles caught exceptions and processes them, such as logging.</param>
        protected InstallerBase(IEnumerable<KeyValuePair<int, IInstallerAction>> actions, Action<double> updateProgressPercentage = null, Action<string, double> updateStatusAndProgressPercentage = null, Action<Exception> errorHandler = null)
            : this()
        {
            ArgumentNullException.ThrowIfNull(actions);

            Actions.AddRange(actions);
            UpdateProgressPercentage = updateProgressPercentage;
            ErrorHandler = errorHandler;
            UpdateStatusAndProgressPercentage = updateStatusAndProgressPercentage;
        }

        /// <summary>
        /// Updates the progress percentage reporter. The default implementation used is <see cref="UpdateProgressPercentage"/>.
        /// </summary>
        /// <param name="actionsCompletedCount">Total number of completed actions so far.</param>
        /// <param name="status">Optional status message to display.</param>
        protected virtual void UpdateProgress(int actionsCompletedCount, string status = null)
        {
            double percentComplete = (Actions.Count > 0) ? Convert.ToDouble(actionsCompletedCount) / Convert.ToDouble(Actions.Count) : 0;
            
            if (!String.IsNullOrWhiteSpace(status) && (UpdateStatusAndProgressPercentage != null))
            {
                UpdateStatusAndProgressPercentage(status, percentComplete);
            }
            else if ((UpdateProgressPercentage != null) && (Actions.Count > 0))
            {
                UpdateProgressPercentage(percentComplete);
            }
        }

        /// <summary>
        /// Forwards the specified <see cref="Exception"/> to the error handler. The default implementation used is <see cref="ErrorHandler"/>.
        /// </summary>
        /// <param name="e"><see cref="Exception"/> that was captured.</param>
        protected virtual void HandleError(Exception e)
        {
            if ((ErrorHandler != null) && (e != null))
            {
                ErrorHandler(e);
            }
        }
        
        /// <summary>
        /// Executes the current installer with the provided arguments.
        /// </summary>
        /// <param name="args">Arguments to supply to the install actions (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public abstract WhippetResultContainer<object> Install(params object[] args);
        
        /// <summary>
        /// When overridden in a derived class, executes the current installer asynchronously with the specified parameters. If not overridden, this method returns <see langword="null"/>.
        /// </summary>
        /// <param name="args">Parameters to pass to the installer actions (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual Task<WhippetResultContainer<object>> InstallAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken))
        {
            return null;
        }
    }
}
