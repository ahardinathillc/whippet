using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Athi.Whippet.Extensions.Text;
using Athi.Whippet.Security;
using Athi.Whippet.Security.IdentityModel.Tokens.Jwt;
using Athi.Whippet.Security.Cryptography;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ControllerBase"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="controller"><see cref="ControllerBase"/> object.</param>
        /// <param name="securitySection"><see cref="SecurityConfiguration"/> object that contains the master key property.</param>
        /// <param name="value">Plain-text value to encrypt.</param>
        /// <returns><see cref="SaltValuePair"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SaltValuePair Encrypt(this ControllerBase controller, SecurityConfiguration securitySection, string value)
        {
            if(controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }
            else if(securitySection == null)
            {
                throw new ArgumentNullException(nameof(securitySection));
            }
            else if(String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                byte[] salt = WhippetCryptography.ComputeHash(value);
                byte[] encryptedValue = WhippetCryptography.Encrypt(securitySection.MasterKey, value, salt);

                return new SaltValuePair(encryptedValue, salt, securitySection.MasterKey);
            }
        }

        /// <summary>
        /// Decrypts the specified value.
        /// </summary>
        /// <param name="controller"><see cref="ControllerBase"/> object.</param>
        /// <param name="securitySection"><see cref="SecurityConfiguration"/> object that contains the master key property.</param>
        /// <param name="svPair"><see cref="SaltValuePair"/> that contains the encrypted value and associated salt (if any).</param>
        /// <returns>Unencrypted value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(this ControllerBase controller, SecurityConfiguration securitySection, SaltValuePair svPair)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }
            else if (securitySection == null)
            {
                throw new ArgumentNullException(nameof(securitySection));
            }
            else
            {
                return UTF8Encoding.UTF8.SafeGetString_UTF8(WhippetCryptography.Decrypt(securitySection.MasterKey, svPair.Value, svPair.Salt));
            }
        }

        /// <summary>
        /// Generates a new JWT authentication token for the specified user.
        /// </summary>
        /// <param name="controller"><see cref="ControllerBase"/> object.</param>
        /// <param name="configuration"><see cref="IConfiguration"/> passed to the controller upon instantiation.</param>
        /// <param name="userName">Username to assign to the token.</param>
        /// <param name="email">E-mail address of the user to assign to the token.</param>
        /// <returns>JWT token.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GenerateJwtToken(this ControllerBase controller, IConfiguration configuration, string userName, string email)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }
            else if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            else if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            else if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                SecurityConfiguration securityConfig = new SecurityConfiguration(configuration);
                JwtTokenService tokenService = new JwtTokenService();

                return tokenService.GenerateToken(Encoding.UTF8.GetBytes(securityConfig.IssuerSigningKey), securityConfig.ValidIssuer, securityConfig.TokenExpirationMinutes, userName, email);
            }
        }

        /// <summary>
        /// Gets the name of the controller of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of controller to retrieve formatted name for.</typeparam>
        /// <param name="controller"><see cref="ControllerBase"/> object.</param>
        /// <returns>Formatted controller name.</returns>
        public static string GetControllerName<T>(this ControllerBase controller) where T : ControllerBase
        {
            const string CONTROLLER_SUFFIX = "controller";
            string controllerName = typeof(T).Name;

            while (controllerName.EndsWith(CONTROLLER_SUFFIX, StringComparison.InvariantCultureIgnoreCase))
            {
                controllerName = controllerName.Remove(controllerName.Length - CONTROLLER_SUFFIX.Length);
            }

            return controllerName;
        }
    }
}
