using System;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    public static class IQueryCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static string ToCompleteQueryString(this IQueryCollection collection)
        {
            StringBuilder queryString = new StringBuilder();

            if (collection != null && collection.Count > 0)
            {
                foreach (KeyValuePair<string, StringValues> entry in collection)
                {
                    queryString.Append(entry.Key);
                    queryString.Append('=');
                    queryString.Append(entry.Value.ToString());
                    queryString.Append('&');
                }
            }

            return queryString.ToString();
        }
    }
}

