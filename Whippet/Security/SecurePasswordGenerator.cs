using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Generates a secure random password.
    /// </summary>
    public static class SecurePasswordGenerator
    {
        /// <summary>
        /// Generates a Random Password respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid <see cref="PasswordOptions"/> object containing the password strength requirements.</param>
        /// <returns>A random password.</returns>
        /// <remarks>From <a href="https://www.ryadel.com/en/c-sharp-random-password-generator-asp-net-core-mvc/">C# Random Password Generator for ASP.NET Core & ASP.NET MVC Identity Framework</a>.</remarks>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };
 
            string[] randomChars = new [] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };

            List<char> chars = new List<char>();
 
            if (opts.RequireUppercase)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count), 
                    randomChars[0][RandomNumberGenerator.GetInt32(0, randomChars[0].Length)]);
 
            if (opts.RequireLowercase)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[1][RandomNumberGenerator.GetInt32(0, randomChars[1].Length)]);
 
            if (opts.RequireDigit)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[2][RandomNumberGenerator.GetInt32(0, randomChars[2].Length)]);
 
            if (opts.RequireNonAlphanumeric)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[3][RandomNumberGenerator.GetInt32(0, randomChars[3].Length)]);
 
            for (int i = chars.Count; i < opts.RequiredLength 
                                      || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[RandomNumberGenerator.GetInt32(0, randomChars.Length)];
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count), 
                    rcs[RandomNumberGenerator.GetInt32(0, rcs.Length)]);
            }
 
            return new string(chars.ToArray());
        }        
    }
}
