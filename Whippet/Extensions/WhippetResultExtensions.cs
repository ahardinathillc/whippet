using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetResult"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetResultExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetResultContainer{T}"/> objects to a <see cref="WhippetResult"/>.
        /// </summary>
        /// <typeparam name="T">Type of result stored in the <see cref="WhippetResultContainer{T}"/>.</typeparam>
        /// <param name="resultContainer"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetResultContainer{T}"/> objects.</param>
        /// <returns><see cref="WhippetResult"/> object.</returns>
        public static WhippetResult ToWhippetResult<T>(this IEnumerable<WhippetResultContainer<T>> resultContainer)
        {
            WhippetResult result = WhippetResult.Success;
            WhippetResultSeverity severity = WhippetResultSeverity.Success;

            if (resultContainer != null && resultContainer.Any())
            {
                severity = resultContainer.Where(rc => !rc.IsSuccess).Any() ? WhippetResultSeverity.Failure : WhippetResultSeverity.Success;
                result = new WhippetResult(severity, resultObject: resultContainer);
            }

            return result;
        }
    }
}
