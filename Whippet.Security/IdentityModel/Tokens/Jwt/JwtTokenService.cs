using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using System.ComponentModel;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using NodaTime;
using Newtonsoft.Json;
using Athi.Whippet;
using Athi.Whippet.Security;

namespace Athi.Whippet.Security.IdentityModel.Tokens.Jwt
{
    /// <summary>
    /// Token service for generating JWT bearer tokens. This class cannot be inherited.
    /// </summary>
    public sealed class JwtTokenService : ITokenService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenService"/> class with no arguments.
        /// </summary>
        public JwtTokenService()
        { }

        /// <summary>
        /// Generates a new token.
        /// </summary>
        /// <param name="issuerSigningKey">Issuer signing key.</param>
        /// <param name="issuer">Issuing authority of the token.</param>
        /// <param name="minutesUntilExpiration">The total number of minutes before the JWT token expires.</param>
        /// <param name="userName">Username to assign to the token.</param>
        /// <param name="email">E-mail address associated with the user.</param>
        /// <param name="securityAlgorithm">Security algorithm to use.</param>
        /// <returns>Token value.</returns>
        /// <exception cref="ArgumentNullException" />
        public string GenerateToken(byte[] issuerSigningKey, string issuer, TimeSpan minutesUntilExpiration, string userName, string email, string securityAlgorithm = SecurityAlgorithms.HmacSha256)
        {
            if (issuerSigningKey == null || issuerSigningKey.Length == 0)
            {
                throw new ArgumentNullException(nameof(issuerSigningKey));
            }
            else if (String.IsNullOrWhiteSpace(issuer))
            {
                throw new ArgumentNullException(nameof(issuer));
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
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(issuerSigningKey);
                SigningCredentials credentials = new SigningCredentials(securityKey, securityAlgorithm);
                JwtSecurityToken token = new JwtSecurityToken(issuer, issuer, GenerateDefaultJwtClaims(userName, email), null, DateTime.UtcNow.AddMinutes(minutesUntilExpiration.TotalMinutes), credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

        /// <summary>
        /// Validates the given token.
        /// </summary>
        /// <param name="tokenParameters"><see cref="TokenValidationParameters"/> object that contains the validation options set on application startup.</param>
        /// <param name="tokenValue">Token value to validate.</param>
        /// <returns><see langword="true"/> if the token value is valid; otherwise, <see langword="false"/>.</returns>
        public bool ValidateToken(TokenValidationParameters tokenParameters, string tokenValue)
        {
            if (tokenParameters == null)
            {
                throw new ArgumentNullException(nameof(tokenParameters));
            }
            else if (String.IsNullOrWhiteSpace(tokenValue))
            {
                throw new ArgumentNullException(nameof(tokenValue));
            }
            else
            {
                ClaimsPrincipal dummyPrincipal = null;
                SecurityToken dummyToken = null;

                return ValidateToken(tokenParameters, tokenValue, out dummyPrincipal, out dummyToken);
            }
        }

        /// <summary>
        /// Validates the given token.
        /// </summary>
        /// <param name="tokenParameters"><see cref="TokenValidationParameters"/> object that contains the validation options set on application startup.</param>
        /// <param name="tokenValue">Token value to validate.</param>
        /// <returns><see langword="true"/> if the token value is valid; otherwise, <see langword="false"/>.</returns>
        public bool ValidateToken(TokenValidationParameters tokenParameters, string tokenValue, out ClaimsPrincipal principal, out SecurityToken token)
        {
            if (tokenParameters == null)
            {
                throw new ArgumentNullException(nameof(tokenParameters));
            }
            else if (String.IsNullOrWhiteSpace(tokenValue))
            {
                throw new ArgumentNullException(nameof(tokenValue));
            }
            else
            {
                bool valid = false;

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken = null;

                try
                {
                    principal = handler.ValidateToken(tokenValue, tokenParameters, out validatedToken);
                    token = validatedToken;
                    valid = true;
                }
                catch
                {
                    valid = false;
                    token = null;
                    principal = null;
                }

                return valid;
            }
        }

        /// <summary>
        /// Generates a collection of default <see cref="Claim"/> objects to assign to a JWT bearer token.
        /// </summary>
        /// <param name="userName">Username that the token is being generated for.</param>
        /// <param name="email">E-mail address associated with the user.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Claim"/> objects.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Claim> GenerateDefaultJwtClaims(string userName, string email)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            else if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                return new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("Date", DateTime.UtcNow.ToLongDateString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            }
        }
    }
}

