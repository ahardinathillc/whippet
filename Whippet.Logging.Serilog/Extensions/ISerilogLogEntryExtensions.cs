using System;

namespace Athi.Whippet.Logging.Serilog.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISerilogLogEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISerilogLogEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISerilogLogEntry"/> object to a <see cref="SerilogLogEntry"/> object.
        /// </summary>
        /// <param name="log"><see cref="ISerilogLogEntry"/> object to convert.</param>
        /// <returns><see cref="SerilogLogEntry"/> object.</returns>
        public static SerilogLogEntry ToSerilogLogEntry(this ISerilogLogEntry log)
        {
            SerilogLogEntry sl = null;

            if (log != null)
            {
                if (log is SerilogLogEntry)
                {
                    sl = (SerilogLogEntry)(log);
                }
                else
                {
                    sl = new SerilogLogEntry(log.ID, log.Message, log.MessageTemplate, log.Level, log.TimeStamp, log.Exception, log.Properties);
                }
            }

            return sl;
        }
    }
}

