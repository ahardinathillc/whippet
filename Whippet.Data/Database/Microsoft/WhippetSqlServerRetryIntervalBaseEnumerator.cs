using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Generates a sequence of time intervals. This class cannot be inherited.
    /// </summary>
    internal sealed class WhippetSqlServerRetryIntervalBaseEnumerator : WhippetSqlServerRetryIntervalBaseEnumeratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryIntervalBaseEnumerator"/> class with the specified <see cref="SqlRetryIntervalBaseEnumerator"/> object.
        /// </summary>
        /// <param name="enumerator"><see cref="SqlRetryIntervalBaseEnumerator"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSqlServerRetryIntervalBaseEnumerator(SqlRetryIntervalBaseEnumerator enumerator)
            : base(enumerator)
        { }
    }
}
