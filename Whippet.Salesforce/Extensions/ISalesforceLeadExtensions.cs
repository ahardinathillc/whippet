using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceLead"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceLeadExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceLead"/> object to a <see cref="SalesforceLead"/> object.
        /// </summary>
        /// <param name="lead"><see cref="ISalesforceLead"/> object to convert.</param>
        /// <returns><see cref="SalesforceLead"/> object.</returns>
        public static SalesforceLead ToSalesforceLead(this ISalesforceLead lead)
        {
            SalesforceLead sfLead = null;

            if (lead != null)
            {
                if (lead is SalesforceLead)
                {
                    sfLead = (SalesforceLead)(lead);
                }
                else
                {
                    sfLead = new SalesforceLead();
                    sfLead.ImportDataRow(lead.CreateDataRow__Internal());
                }
            }

            return sfLead;
        }
    }
}

