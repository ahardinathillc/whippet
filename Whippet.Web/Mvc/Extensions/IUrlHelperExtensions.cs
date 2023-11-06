using System;
using System.Web;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IUrlHelper"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IUrlHelperExtensions
    {
        /// <summary>
        /// Gets the current URL with substituted values while preserving the query string.
        /// </summary>
        /// <param name="helper"><see cref="IUrlHelper"/> instance.</param>
        /// <param name="substitutes">Query string parameters or route data parameters.</param>
        /// <returns>Route with preserved query string.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <remarks>See <a href="https://stackoverflow.com/questions/42022311/asp-net-mvc-create-action-link-preserve-query-string">ASP.NET MVC - Create action link preserve query string</a> for more information.</remarks>
        public static string Current(this IUrlHelper helper, object substitutes)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            else
            {
                RouteValueDictionary routeData = new RouteValueDictionary(helper.ActionContext.RouteData.Values);
                IQueryCollection queryString = helper.ActionContext.HttpContext.Request.Query;

                //add query string parameters to the route data
                foreach (var param in queryString)
                {
                    if (!string.IsNullOrEmpty(queryString[param.Key]))
                    {
                        //rd[param.Key] = qs[param.Value]; // does not assign the values!
                        routeData.Add(param.Key, param.Value);
                    }
                }

                // override parameters we're changing in the route data
                //The unmatched parameters will be added as query string.
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(substitutes.GetType()))
                {
                    var value = property.GetValue(substitutes);
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        routeData.Remove(property.Name);
                    }
                    else
                    {
                        routeData[property.Name] = value;
                    }
                }

                string url = helper.RouteUrl(routeData);
                return url;
            }
        }

        /// <summary>
        /// Creates a query string.
        /// </summary>
        /// <param name="helper"><see cref="IUrlHelper"/> instance.</param>
        /// <param name="baseUrl">Base URL to append query string to.</param>
        /// <param name="htmlEncode">If <see langword="true"/>, will encode the query string values.</param>
        /// <param name="values"><see cref="KeyValuePair{TKey, TValue}"/> collection of values to create the query string from.</param>
        /// <returns>Query string value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string CreateQueryString(this IUrlHelper helper, string baseUrl, bool htmlEncode, params KeyValuePair<string, string>[] values)
        {
            if (String.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
            else
            {
                StringBuilder builder = new StringBuilder(baseUrl);

                if (values != null && values.Any())
                {
                    if (!builder.ToString().EndsWith('?'))
                    {
                        builder.Append('?');
                    }

                    foreach (KeyValuePair<string, string> pair in values)
                    {
                        builder.Append(pair.Key);
                        builder.Append('=');
                        builder.Append(htmlEncode ? WebUtility.HtmlEncode(pair.Value) : pair.Value);
                        builder.Append('&');
                    }

                    if (builder.ToString().EndsWith('&'))
                    {
                        builder = builder.Remove(builder.Length - 1, 1);
                    }
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Creates a query string template with placeholders for values to be added.
        /// </summary>
        /// <param name="helper"><see cref="IUrlHelper"/> instance.</param>
        /// <param name="baseUrl">Base URL to append query string to.</param>
        /// <param name="keys">Querystring value names.</param>
        /// <returns>Query string value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string CreateQueryStringTemplate(this IUrlHelper helper, string baseUrl, IEnumerable<string> keys)
        {
            if (String.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
            else
            {
                StringBuilder builder = new StringBuilder(baseUrl);
                int counter = 0;

                if (keys != null && keys.Any())
                {
                    if (!builder.ToString().EndsWith('?'))
                    {
                        builder.Append('?');
                    }

                    foreach (string key in keys)
                    {
                        builder.Append(key);
                        builder.Append('=');
                        builder.Append("{" + counter + "}");
                        builder.Append('&');

                        counter++;
                    }

                    if (builder.ToString().EndsWith('&'))
                    {
                        builder = builder.Remove(builder.Length - 1, 1);
                    }
                }

                return builder.ToString();
            }
        }
    }
}

