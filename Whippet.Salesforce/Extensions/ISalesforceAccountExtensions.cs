using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceAccount"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceAccountExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceAccount"/> object to a <see cref="SalesforceAccount"/> object.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to convert.</param>
        /// <returns><see cref="SalesforceAccount"/> object.</returns>
        public static SalesforceAccount ToSalesforceAccount(this ISalesforceAccount account)
        {
            SalesforceAccount sfAccount = null;

            if (account != null)
            {
                if (account is SalesforceAccount)
                {
                    sfAccount = (SalesforceAccount)(account);
                }
                else
                {
                    sfAccount = new SalesforceAccount();
                    sfAccount.ImportDataRow(account.CreateDataRow__Internal());
                }
            }

            return sfAccount;
        }
    }
}

