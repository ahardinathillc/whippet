using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    /// Indicates the severity of a <see cref="WhippetResult"/>.
    /// </summary>
    [Flags]
    public enum WhippetResultSeverity : byte
    {
        /// <summary>
        /// The operation failed. This cannot be combined with other flags.
        /// </summary>
        Failure = 0,
        /// <summary>
        /// The operation contains extra information about the response.
        /// </summary>
        Info = 1,
        /// <summary>
        /// The operation succeeded.
        /// </summary>
        Success = 2,
        /// <summary>
        /// The operation may or may not have succeeded, or a side-effect may have been encountered.
        /// </summary>
        Warning = 4
    }
}
