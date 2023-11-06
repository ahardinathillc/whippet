using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforceClientProfile"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforceClientProfileExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforceClientProfile"/> object to a <see cref="SalesforceClientProfile"/> object.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to convert.</param>
        /// <returns><see cref="SalesforceClientProfile"/> object.</returns>
        public static SalesforceClientProfile ToSalesforceClientProfile(this ISalesforceClientProfile profile)
        {
            SalesforceClientProfile sfProfile = null;

            if (profile != null)
            {
                if (profile is SalesforceClientProfile)
                {
                    sfProfile = (SalesforceClientProfile)(profile);
                }
                else
                {
                    sfProfile = new SalesforceClientProfile(profile.ID, profile.Name, profile.Url, profile.ApiToken, profile.ConsumerKey, profile.ConsumerSecret, profile.UseWebServerAuthenticationFlow, profile.Tenant.ToWhippetTenant(), profile.Active, profile.Deleted, profile.CreatedDateTime, profile.CreatedBy, profile.LastModifiedDateTime, profile.LastModifiedBy);
                    sfProfile.Password = profile.Password;
                    sfProfile.Username = profile.Username;
                }
            }

            return sfProfile;
        }
    }
}

