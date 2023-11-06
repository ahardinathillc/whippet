using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Represents a Whippet <see cref="InstallRunner"/>, which handles an installation activity.
    /// </summary>
    public class InstallRunner : IInstallAction
    {
        private Queue<IInstallAction> _actions;

        /// <summary>
        /// Gets the name that describes the installer. This property is read-only.
        /// </summary>
        string IInstallAction.Name
        {
            get
            {
                return _ActionName;
            }
        }

        /// <summary>
        /// Gets the description of the installer. This property is read-only.
        /// </summary>
        string IInstallAction.Description
        {
            get
            {
                return _ActionDescription;
            }
        }

        /// <summary>
        /// Gets or sets the description of the installer.
        /// </summary>
        private string _ActionDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the name that describes the installer.
        /// </summary>
        private string _ActionName
        { get; set; }

        /// <summary>
        /// Gets the <see cref="SortedList{TKey, TValue}"/> collection of <see cref="IInstallAction"/> objects to invoke. This property is read-only.
        /// </summary>
        protected Queue<IInstallAction> InstallActions
        {
            get
            {
                if (_actions == null)
                {
                    _actions = new Queue<IInstallAction>();
                }

                return _actions;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallRunner"/> class with no arguments.
        /// </summary>
        private InstallRunner()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallRunner"/> class with the specified installer name and description.
        /// </summary>
        /// <param name="installerName">Name of the installer.</param>
        /// <param name="installerDescription">Installer description.</param>
        public InstallRunner(string installerName, string installerDescription)
            : this()
        {
            _ActionName = installerName;
            _ActionDescription = installerDescription;
        }

        /// <summary>
        /// Adds the specified <see cref="IInstallAction"/> to the runner.
        /// </summary>
        /// <param name="action"><see cref="IInstallAction"/> action to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual void AddAction(IInstallAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                InstallActions.Enqueue(action);
            }
        }

        /// <summary>
        /// Executes all <see cref="IInstallAction"/> actions currently loaded into the <see cref="InstallRunner"/>. The installer halts on the first exception encountered.
        /// </summary>
        /// <param name="runnerDelegate"><see cref="ProgressDelegate"/> delegate that measures the total progress of all actions performed.</param>
        /// <param name="actionDelegate"><see cref="ProgressDelegate"/> delegate that measures the individual progress of the currently executing <see cref="IInstallAction"/>.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        public WhippetResult Run(ProgressDelegate runnerDelegate, ProgressDelegate actionDelegate)
        {
            var result = WhippetResult.Success;
            var i = 1;

            var actions = InstallActions.ToList();

            foreach (var action in actions)
            {
                if (runnerDelegate != null)
                {
                    runnerDelegate(Convert.ToInt32(i / InstallActions.Count), ((IInstallAction)this).Description);
                }

                result = ((IInstallAction)this).PerformAction(actionDelegate);

                if (!result.IsSuccess)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

        /// <summary>
        /// Performs the installation action and reports the progress of the action to the specified <see cref="ProgressDelegate"/> (if supplied).
        /// </summary>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> that records progress of the current installation action.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        WhippetResult IInstallAction.PerformAction(ProgressDelegate pDelegate)
        {
            var result = WhippetResult.Success;
            var action = InstallActions.Dequeue();

            if (action != null)
            {
                result = action.PerformAction(pDelegate);
            }

            return result;
        }
    }
}
