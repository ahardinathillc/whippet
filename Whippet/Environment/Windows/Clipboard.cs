using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Athi.Whippet.Environment.Windows
{
    /// <summary>
    /// Initializes a handle to the Windows clipboard. This class cannot be inherited.
    /// </summary>
    public sealed class Clipboard : Process, IDisposable
    {
        private const string PROCESS_NAME = @"clip";

        /// <summary>
        /// Initializes a new instance of the <see cref="Clipboard"/> class with no arguments.
        /// </summary>
        private Clipboard()
            : base()
        {
            StartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                FileName = PROCESS_NAME
            };
        }

        /// <summary>
        /// Adds the specified value to the clipboard, overwriting any object currently stored there.
        /// </summary>
        /// <param name="value">Value to write to the clipboard.</param>
        public static void AddToClipboard(string value)
        {
            Clipboard cb = null;

            try
            {
                cb = new Clipboard();
                cb.Start();
                cb.StandardInput.Write(value);
                cb.StandardInput.Close();
            }
            finally
            {
                if(cb != null)
                {
                    cb.Dispose();
                    cb = null;
                }
            }
        }
    }
}
