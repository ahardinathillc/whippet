using System;

namespace Athi.Whippet.Logging.Serilog
{
    /// <summary>
    /// Represents a logging level in Serilog.
    /// </summary>
    public enum SerilogLevel
    {
        /// <summary>
        /// Tracing information and debugging minutiae; generally only switched on in unusual situations.
        /// </summary>
        Verbose,
        /// <summary>
        /// Internal control flow and diagnostic state dumps to facilitate pinpointing of recognised problems.
        /// </summary>
        Debug,
        /// <summary>
        /// Events of interest or that have relevance to outside observers; the default enabled minimum logging level.
        /// </summary>
        Information,
        /// <summary>
        /// Indicators of possible issues or service/functionality degradation.
        /// </summary>
        Warning,
        /// <summary>
        /// Indicating a failure within the application or connected system.
        /// </summary>
        Error,
        /// <summary>
        /// Critical errors causing complete failure of the application.
        /// </summary>
        Fatal
    }
}
