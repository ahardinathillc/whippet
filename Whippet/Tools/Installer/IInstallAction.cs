using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Tools.Installer
{
    /// <summary>
    /// Represents an installer action. Installer actions configure databases, set up file paths, and perform other configuration actions.
    /// </summary>
    public interface IInstallAction
    {
        /// <summary>
        /// Gets the name of the action being performed. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets the description of the action being performed. This property is read-only.
        /// </summary>
        string Description
        { get; }

        /// <summary>
        /// Performs the installation action and reports the progress of the action to the specified <see cref="ProgressDelegate"/> (if supplied).
        /// </summary>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> that records progress of the current installation action.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        WhippetResult PerformAction(ProgressDelegate pDelegate = null);
    }
}
