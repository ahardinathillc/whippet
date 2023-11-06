using System;
using Microsoft.AspNetCore.Mvc;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IActionResult"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IActionResultExtensions
    {
        /// <summary>
        /// Indicates whether the <see cref="IActionResult"/> is a <see cref="ForbidResult"/>.
        /// </summary>
        /// <param name="action"><see cref="IActionResult"/> object to check.</param>
        /// <returns><see langword="true"/> if the <see cref="IActionResult"/> object is a <see cref="ForbidResult"/>; otherwise, <see langword="false"/>.</returns>
        public static bool IsForbidden(this IActionResult action)
        {
            return (action is ForbidResult);
        }
    }
}

