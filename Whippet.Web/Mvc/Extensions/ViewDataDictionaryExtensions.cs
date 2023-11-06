using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ViewDataDictionary"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ViewDataDictionaryExtensions
    {
        /// <summary>
        /// Retrieves an entry from the specified <see cref="ViewDataDictionary"/> with the specified resource ID and casts the entry as a <typeparamref name="TObject"/>.
        /// </summary>
        /// <typeparam name="TObject">Type to cast the entry as.</typeparam>
        /// <param name="viewData"><see cref="ViewDataDictionary"/> object.</param>
        /// <param name="resourceId">Resource ID of the resource to retrieve.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException" />
        public static TObject GetObject<TObject>(this ViewDataDictionary viewData, string resourceId)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }
            else if (String.IsNullOrWhiteSpace(resourceId))
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            else
            {
                return ((TObject)(viewData[resourceId]));
            }
        }
    }
}

