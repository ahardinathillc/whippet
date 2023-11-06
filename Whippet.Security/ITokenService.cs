using System;
using Microsoft.IdentityModel.Tokens;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Provides agnostic support to token service classes, such as creation and validation.
    /// </summary>
    public interface ITokenService
    {
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
        string GenerateToken(byte[] issuerSigningKey, string issuer, TimeSpan minutesUntilExpiration, string userName, string email, string securityAlgorithm = SecurityAlgorithms.HmacSha256);

        /// <summary>
        /// Validates the given token.
        /// </summary>
        /// <param name="tokenParameters"><see cref="TokenValidationParameters"/> object that contains the validation options set on application startup.</param>
        /// <param name="tokenValue">Token value to validate.</param>
        /// <returns><see langword="true"/> if the token value is valid; otherwise, <see langword="false"/>.</returns>
        bool ValidateToken(TokenValidationParameters tokenParameters, string tokenValue);
    }
}

