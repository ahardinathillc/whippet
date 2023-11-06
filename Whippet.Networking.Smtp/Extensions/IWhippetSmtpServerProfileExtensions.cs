using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Networking.Smtp.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetSmtpServerProfile"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetSmtpServerProfileExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IWhippetSmtpServerProfile"/> object to a <see cref="WhippetSmtpServerProfile"/> object.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to convert.</param>
        /// <returns><see cref="WhippetSmtpServerProfile"/> object.</returns>
        public static WhippetSmtpServerProfile ToWhippetSmtpServerProfile(this IWhippetSmtpServerProfile profile)
        {
            WhippetSmtpServerProfile prf = null;

            if (profile != null)
            {
                if (profile is WhippetSmtpServerProfile)
                {
                    prf = (WhippetSmtpServerProfile)(profile);
                }
                else
                {
                    prf = new WhippetSmtpServerProfile(
                        profile.ID,
                        profile.ServerName,
                        profile.ServerAddress,
                        profile.PortNumber,
                        profile.SecureSocketOption,
                        profile.IsDefault,
                        profile.Username,
                        profile.Password,
                        profile.Tenant.ToWhippetTenant(),
                        profile.CreatedDateTime,
                        profile.CreatedBy,
                        profile.LastModifiedDateTime,
                        profile.LastModifiedBy,
                        profile.Active,
                        profile.Deleted
                    );
                }
            }

            return prf;
        }
    }
}

