using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceOpportunity"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceOpportunityExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceOpportunity"/> object to a <see cref="SalesforceOpportunity"/> object.
        /// </summary>
        /// <param name="opportunity"><see cref="ISalesforceOpportunity"/> object to convert.</param>
        /// <returns><see cref="SalesforceOpportunity"/> object.</returns>
        public static SalesforceOpportunity ToSalesforceOpportunity(this ISalesforceOpportunity opportunity)
        {
            SalesforceOpportunity sfOpportunity = null;

            if (opportunity != null)
            {
                if (opportunity is SalesforceOpportunity)
                {
                    sfOpportunity = (SalesforceOpportunity)(opportunity);
                }
                else
                {
                    sfOpportunity = new SalesforceOpportunity();
                    sfOpportunity.ImportDataRow(opportunity.CreateDataRow__Internal());
                }
            }

            return sfOpportunity;
        }
    }
}

