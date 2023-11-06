using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.ApplicationConfiguration;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Represents the "Security" section of the appsettings.json file.
    /// </summary>
    public class SecurityConfiguration : ConfigurationSectionBase
    {
        private const int DEFAULT_EXPY_TOKEN = 120;

        /// <summary>
        /// Gets the encryption master key.
        /// </summary>
        public byte[] MasterKey
        { 
            get
            {
                string[] pieces = Section[nameof(MasterKey)].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                byte[] mk = new byte[pieces.Length];

                for(int i = 0; i < pieces.Length; i++)
                {
                    mk[i] = (byte)(Convert.ToInt32(pieces[i]));
                }

                return mk;
            }
        }

        /// <summary>
        /// Gets the authentication cookie name. This property is read-only.
        /// </summary>
        public string AuthCookieName
        {
            get
            {
                return Section[nameof(AuthCookieName)];
            }
        }

        /// <summary>
        /// Gets the valid host value that indicates the valid JWT host. This property is read-only.
        /// </summary>
        public string ValidHost
        {
            get
            {
                return Section[nameof(ValidHost)];
            }
        }

        /// <summary>
        /// Gets the valid issuer that indicates the valid JWT issuer. This property is read-only.
        /// </summary>
        public string ValidIssuer
        {
            get
            {
                return Section[nameof(ValidIssuer)];
            }
        }

        /// <summary>
        /// Gets the issuer signing key used to encrypt JWT tokens. This property is read-only.
        /// </summary>
        public string IssuerSigningKey
        {
            get
            {
                return Section[nameof(IssuerSigningKey)];
            }
        }

        /// <summary>
        /// Gets the <see cref="IssuerSigningKey"/> value as an encoded UTF-8 byte array. This property is read-only.
        /// </summary>
        public byte[] IssuerSigningKey_UTF8
        {
            get
            {
                return Encoding.UTF8.GetBytes(IssuerSigningKey);
            }
        }

        /// <summary>
        /// Gets the <see cref="IssuerSigningKey"/> value as an encoded ASCII byte array. This property is read-only.
        /// </summary>
        public byte[] IssuerSigningKey_ASCII
        {
            get
            {
                return Encoding.ASCII.GetBytes(IssuerSigningKey);
            }
        }

        /// <summary>
        /// Gets the JWT timeout in minutes. This is the amount of time that a token is valid for before expiring. This property is read-only.
        /// </summary>
        public TimeSpan TokenExpirationMinutes
        {
            get
            {
                int time;

                try
                {
                    if (!Int32.TryParse(Section[nameof(TokenExpirationMinutes)], out time))
                    {
                        time = DEFAULT_EXPY_TOKEN;
                    }
                }
                catch
                {
                    time = DEFAULT_EXPY_TOKEN;
                }

                return TimeSpan.FromMinutes(time);
            }
        }

        /// <summary>
        /// Gets the system administrator e-mail or, alternatively, the default no-reply e-mail to use when dispatching system e-mails. This property is read-only.
        /// </summary>
        public string SystemAdministratorEmail
        {
            get
            {
                return Section[nameof(SystemAdministratorEmail)];
            }
        }

        /// <summary>
        /// Indicates whether JWT tokens should require HTTPS for metadata and authority access. Typically, this is <see langword="false"/> for development environments. This property is read-only.
        /// </summary>
        public bool JwtRequireHttpsMetadata
        {
            get
            {
                // if the section is not present, default to TRUE

                bool requireHttps;

                try
                {
                    if (!Boolean.TryParse(Section[nameof(JwtRequireHttpsMetadata)], out requireHttps))
                    {
                        requireHttps = true;
                    }
                }
                catch
                {
                    requireHttps = true;
                }

                return requireHttps;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConfiguration"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that contains the section to read.</param>
        /// <exception cref="ArgumentNullException" />
        public SecurityConfiguration(IConfiguration configuration)
            : base(configuration, "WhippetSecuritySettings")
        { }
    }
}
