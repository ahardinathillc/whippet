using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Provides functionality and support for executing <see cref="InstallerAction"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class Installer
    {
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey,TValue}"/> containing <see cref="InstallerActionCollection"/> objects which group the <see cref="InstallerAction"/> instances together sorted in the order of execution. This property is read-only.
        /// </summary>
        public IReadOnlyDictionary<int, InstallerActionCollection> Actions
        { get; private set; }
        
        /// <summary>
        /// Progress reporter that lists the current action.
        /// </summary>
        private Action<string> ReportCurrentAction
        { get; set; }
        
        /// <summary>
        /// Progress reporter that lists the progress of the overall installation process.
        /// </summary>
        private Action<double> PercentCompleteReporter
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Installer"/> class with no arguments.
        /// </summary>
        private Installer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Installer"/> class with the specified <see cref="IDictionary{TKey,TValue}"/> of <see cref="InstallerActionCollection"/> objects sorted by execution order.
        /// </summary>
        /// <param name="actions"><see cref="IDictionary{TKey,TValue}"/> of <see cref="InstallerActionCollection"/> objects sorted by execution order.</param>
        /// <param name="percentCompleteReporter"><see cref="Action{T}"/> that updates an external progress reporter.</param>
        /// <param name="currentActionPercentCompleteReporter"><see cref="Action{T}"/> that updates an external progress reporter for the current action group that's being executed.</param>
        /// <param name="currentActionReporter"><see cref="Action{T}"/> that updates an external progress reporter that lists the current action.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Installer(IDictionary<int, InstallerActionCollection> actions, Action<double> percentCompleteReporter = null, Action<double> currentActionPercentCompleteReporter = null, Action<string> currentActionReporter = null)
            : this()
        {
            ArgumentNullException.ThrowIfNull(actions);

            foreach (InstallerActionCollection collection in actions.Values)
            {
                collection.PercentComplete = currentActionPercentCompleteReporter;
            }

            PercentCompleteReporter = percentCompleteReporter;
            
            actions = actions.OrderBy(a => a.Key).ToDictionary();   // order once
            
            Actions = new ReadOnlyDictionary<int, InstallerActionCollection>(actions);
            
            ReportCurrentAction = currentActionReporter;
        }

        /// <summary>
        /// Starts the installation process.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        public WhippetResult Install()
        {
            WhippetResult result = WhippetResult.Success;
            int totalActionGroups = Actions.Count;
            int actionGroupsCompleted = 0;
            
            foreach (KeyValuePair<int, InstallerActionCollection> entry in Actions)
            {
                result = entry.Value.PerformInstall(ReportCurrentAction);

                if (!result.IsSuccess)
                {
                    break;
                }
                else
                {
                    actionGroupsCompleted++;

                    if (PercentCompleteReporter != null)
                    {
                        PercentCompleteReporter(Convert.ToDouble(actionGroupsCompleted) / Convert.ToDouble(totalActionGroups));
                    }
                }
            }

            return result;
        }
    }
}
