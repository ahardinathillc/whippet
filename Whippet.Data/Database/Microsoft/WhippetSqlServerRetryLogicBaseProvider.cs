using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using Microsoft.Data.SqlClient;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Applies retry logic on an operation through the "Execute" or "ExecuteAsync" function. This class cannot be inherited.
    /// </summary>
    internal sealed class WhippetSqlServerRetryLogicBaseProvider : WhippetSqlServerRetryLogicBaseProviderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryLogicBaseProvider"/> class with the specified <see cref="SqlRetryLogicBaseProvider"/> object.
        /// </summary>
        /// <param name="provider"><see cref="SqlRetryLogicBaseProvider"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerRetryLogicBaseProvider(SqlRetryLogicBaseProvider provider)
            : base(provider)
        { }
    }
}
