using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Applications.Setup.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetApplication"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetApplicationExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetApplication"/> object to a <see cref="WhippetApplication" /> object.
        /// </summary>
        /// <param name="applicationObj"><see cref="IWhippetApplication"/> object to convert.</param>
        /// <returns><see cref="WhippetApplication"/> object.</returns>
        public static WhippetApplication ToWhippetApplication(this IWhippetApplication applicationObj)
        {
            WhippetApplication app = null;

            if (applicationObj != null)
            {
                if (applicationObj is WhippetApplication)
                {
                    app = (WhippetApplication)(applicationObj);
                }
                else
                {
                    app = new WhippetApplication(applicationObj.ID, applicationObj.ApplicationID, applicationObj.Name, applicationObj.Tenant.ToWhippetTenant());
                }
            }

            return app;
        }
    }
}
