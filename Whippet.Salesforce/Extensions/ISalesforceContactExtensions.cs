using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceContact"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceContactExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceContact"/> object to a <see cref="SalesforceContact"/> object.
        /// </summary>
        /// <param name="contact"><see cref="ISalesforceContact"/> object to convert.</param>
        /// <returns><see cref="SalesforceContact"/> object.</returns>
        public static SalesforceContact ToSalesforceContact(this ISalesforceContact contact)
        {
            SalesforceContact sfContact = null;

            if (contact != null)
            {
                if (contact is SalesforceContact)
                {
                    sfContact = (SalesforceContact)(contact);
                }
                else
                {
                    sfContact = new SalesforceContact();
                    sfContact.ImportDataRow(contact.CreateDataRow__Internal());
                }
            }

            return sfContact;
        }
    }
}

