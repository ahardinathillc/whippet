using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    /// Provides a real-time update to a process.
    /// </summary>
    /// <param name="percentComplete">Percentage complete after each task invocation inside the delegate.</param>
    /// <param name="statusMessage">Status message to display (if any).</param>
    /// <param name="severity"><see cref="WhippetResultSeverity"/> of the operation.</param>
    public delegate void ProgressDelegate(int percentComplete, string statusMessage, WhippetResultSeverity? severity = null);
}
