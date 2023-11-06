using System;
using Microsoft.IdentityModel.Tokens;

namespace Athi.Whippet.Security.IdentityModel.Tokens.Jwt
{
    /// <summary>
    /// Represents default JWT token validation parameters to use in authentication for Whippet.
    /// </summary>
    public class JwtTokenValidationParameters : TokenValidationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenValidationParameters"/> class with no arguments.
        /// </summary>
        private JwtTokenValidationParameters()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenValidationParameters"/> class with the specified parameters.
        /// </summary>
        /// <param name="validAudience">Valid audience.</param>
        /// <param name="validIssuer">Valid issuer of the token.</param>
        /// <param name="issuerSigningKey">Issuer signing key.</param>
        /// <exception cref="ArgumentNullException" />
        public JwtTokenValidationParameters(string validAudience, string validIssuer, SymmetricSecurityKey issuerSigningKey)
            : base()
        {
            if (String.IsNullOrWhiteSpace(validAudience))
            {
                throw new ArgumentNullException(nameof(validAudience));
            }
            else if (String.IsNullOrWhiteSpace(validIssuer))
            {
                throw new ArgumentNullException(nameof(validIssuer));
            }
            else if (issuerSigningKey == null)
            {
                throw new ArgumentNullException(nameof(issuerSigningKey));
            }
            else
            {
                ValidateIssuer = true;
                ValidateAudience = true;
                ValidateLifetime = true;
                ValidateIssuerSigningKey = true;
                ValidAudience = validAudience;
                ValidIssuer = validIssuer;
                ClockSkew = TimeSpan.Zero;      // It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                IssuerSigningKey = issuerSigningKey;
                RequireExpirationTime = true;
            }
        }
    }
}

