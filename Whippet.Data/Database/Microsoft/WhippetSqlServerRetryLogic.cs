using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Retrieves the next time interval with respect to the number of retries if a transient condition occurs. This class cannot be inherited.
    /// </summary>
    internal sealed class WhippetSqlServerRetryLogic : WhippetSqlServerRetryLogicBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerRetryLogic"/> class with the specified <see cref="SqlRetryLogicBase"/> object.
        /// </summary>
        /// <param name="logicBase"><see cref="SqlRetryLogicBase"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerRetryLogic(SqlRetryLogicBase logicBase)
            : base(logicBase)
        { }
    }
}
