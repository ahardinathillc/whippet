using System;
using Microsoft.Extensions.Configuration;

namespace Athi.Whippet.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IConfiguration"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IConfigurationExtensions
    {
        /// <summary>
        /// Gets the security settings <see cref="IConfigurationSection"/> for the specified <see cref="IConfiguration"/> instance.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> instance.</param>
        /// <returns><see cref="IConfigurationSection"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IConfigurationSection GetSecuritySettingsSection(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            else
            {
                return configuration.GetSection("WhippetSecuritySettings");
            }
        }
    }
}

