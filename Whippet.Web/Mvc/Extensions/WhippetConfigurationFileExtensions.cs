using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Razor;
using Athi.Whippet.ApplicationConfiguration;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetConfigurationFile"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetConfigurationFileExtensions
    {
        /// <summary>
        /// Configures extended Razor view locations.
        /// </summary>
        /// <param name="config"><see cref="WhippetConfigurationFile"/> that contains the directory locations and configuration.</param>
        /// <param name="options"><see cref="RazorViewEngineOptions"/> to apply the configuration to.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ConfigureRazorViewDirectories(this WhippetConfigurationFile config, RazorViewEngineOptions options)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            else if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            else
            {
                IConfigurationSection rvDirectories = config.GetSection("RazorViewDirectories");

                string baseDirectory = null;
                string defaultPattern = null;
                string[] directories = null;

                if (rvDirectories != null)
                {
                    baseDirectory = rvDirectories["BaseDirectory"];
                    defaultPattern = rvDirectories["DefaultPattern"];
                    directories = rvDirectories["Directories"]?.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (!baseDirectory.EndsWith('/'))
                    {
                        baseDirectory = baseDirectory + "/";
                    }

                    if (defaultPattern.StartsWith('/'))
                    {
                        if (defaultPattern.Length > 2)
                        {
                            defaultPattern = defaultPattern.Substring(1);
                        }
                        else
                        {
                            defaultPattern = null;
                        }
                    }

                    // add the base directory first

                    options.ViewLocationFormats.Add(baseDirectory + defaultPattern);

                    // now loop through and add each directory

                    for (int i = 0; i < directories.Length; i++)
                    {
                        if (!directories[i].EndsWith('/'))
                        {
                            directories[i] = directories[i] + "/";
                        }

                        options.ViewLocationFormats.Add(baseDirectory + directories[i] + defaultPattern);
                    }
                }
            }
        }
    }
}

