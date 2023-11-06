using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Base class for all installer actions. Installer actions configure databases, set up file paths, and perform other configuration actions. This class must be inherited.
    /// </summary>
    public abstract class InstallActionBase : IInstallAction
    {
        /// <summary>
        /// Gets the name of the action being performed. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// Gets the description of the action being performed. This property is read-only.
        /// </summary>
        public string Description
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallActionBase"/> class with no arguments.
        /// </summary>
        private InstallActionBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallActionBase"/> class with the specified name and description.
        /// </summary>
        /// <param name="name">Installation action name.</param>
        /// <param name="description">Installation action description.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected InstallActionBase(string name, string description)
            : this()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }
            else
            {
                Name = name;
                Description = description;
            }
        }

        /// <summary>
        /// Performs the installation action and reports the progress of the action to the specified <see cref="ProgressDelegate"/> (if supplied). This method must be overridden.
        /// </summary>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> that records progress of the current installation action.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        public abstract WhippetResult PerformAction(ProgressDelegate pDelegate = null);

        /// <summary>
        /// Invokes <paramref name="pDelegate"/> if it is not null with the specified parameters.
        /// </summary>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> delegate to invoke.</param>
        /// <param name="percentComplete">Percentage of the operation that is complete.</param>
        /// <param name="statusMessage">Status message of the operation.</param>
        /// <param name="severity">Status severity.</param>
        protected virtual void ReportProgress(ProgressDelegate pDelegate, int percentComplete, string statusMessage, WhippetResultSeverity? severity = null)
        {
            if (pDelegate != null)
            {
                pDelegate(percentComplete, statusMessage, severity);
            }
        }
    }
}
