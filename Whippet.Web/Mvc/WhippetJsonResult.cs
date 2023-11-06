using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using JSSettings = System.Text.Json.JsonSerializerOptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Athi.Whippet.Security;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// An action result which formats the given object as JSON.
    /// </summary>
    public class WhippetJsonResult : JsonResult
    {
        /// <summary>
        /// Creates a new <see cref="WhippetJsonResult"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        public WhippetJsonResult(object value)
            : base(value)
        { }

        /// <summary>
        /// Creates a new <see cref="WhippetJsonResult"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <param name="serializerSettings">The <see cref="JsonSerializerSettings"/> to be used by the formatter.</param>
        public WhippetJsonResult(object value, JsonSerializerSettings serializerSettings)
            : base(value, serializerSettings)
        { }

        /// <summary>
        /// Creates a new <see cref="WhippetJsonResult"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <param name="serializerSettings">The <see cref="System.Text.Json.JsonSerializerOptions"/> to be used by the formatter.</param>
        public WhippetJsonResult(object value, JSSettings serializerSettings)
            : base(value, serializerSettings)
        { }

        /// <summary>
        /// Converts the specified <see cref="WhippetResult"/> object to a <see cref="WhippetJsonResult"/> object.
        /// </summary>
        /// <param name="result"><see cref="WhippetResult"/> object to convert.</param>
        /// <returns><see cref="WhippetJsonResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetJsonResult FromWhippetResult(WhippetResult result)
        {
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else
            {
                return FromWhippetResultContainer<object>(new WhippetResultContainer<object>(result, result.ResultObject));
            }
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetResultContainer{T}"/> object to a <see cref="WhippetJsonResult"/> object.
        /// </summary>
        /// <typeparam name="T">Type of object stored in the <see cref="WhippetResultContainer{T}"/>.</typeparam>
        /// <param name="result"><see cref="WhippetResultContainer{T}"/> object to convert.</param>
        /// <returns><see cref="WhippetJsonResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetJsonResult FromWhippetResultContainer<T>(WhippetResultContainer<T> result)
        {
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else
            {
                var jsonResult = new
                {
                    isSuccess = result.IsSuccess,
                    exception = (result.Exception != null) ? result.Exception.Message : String.Empty,
                    message = result.Message,
                    severity = result.Severity.ToString(),
                    value = result.Item
                };

                return new WhippetJsonResult(jsonResult);
            }
        }

        /// <summary>
        /// Converts the specified <see cref="Exception"/> object to a <see cref="WhippetJsonResult"/> object.
        /// </summary>
        /// <param name="e"><see cref="Exception"/> object to convert.</param>
        /// <returns><see cref="WhippetJsonResult"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static WhippetJsonResult FromException(Exception e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            else
            {
                return FromWhippetResult(new WhippetResult(e));
            }
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetUserAuthenticationResult"/> object to a <see cref="WhippetJsonResult"/> object.
        /// </summary>
        /// <param name="result"><see cref="WhippetUserAuthenticationResult"/> object to convert.</param>
        /// <returns><see cref="WhippetJsonResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetJsonResult FromWhippetUserAuthenticationResult(WhippetUserAuthenticationResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else
            {
                var jsonResult = new
                {
                    isSuccess = result.IsSuccess,
                    exception = (result.Exception != null) ? result.Exception.Message : String.Empty,
                    message = result.Message,
                    severity = result.Severity.ToString(),
                    value = result.Response.ResponseStatus.ToString(),
                    redirectUrl = result.HasRedirect ? result.RedirectUrl : String.Empty,
                    userId = result.Response.UserID.ToString(),
                    ipAddress = result.Response.IPAddress.ToString(),
                    requestTimestamp = result.Response.RequestTimestamp.ToString()
                };

                return new WhippetJsonResult(jsonResult);
            }
        }

        /// <summary>
        /// Ignores reference loop handling when serializing JSON. This is useful when the server encounters 500 response errors when attempting to return a <see cref="WhippetJsonResult"/> object.
        /// </summary>
        /// <param name="isForNewtonsoft">If <see langword="true"/>, will use <see cref="JsonSerializerSettings"/>; otherwise, <see cref="JSSettings"/> is used.</param>
        public void IgnoreReferenceLoopHandling(bool isForNewtonsoft = true)
        {
            JsonSerializerSettings newtonsoftSettings = null;
            JSSettings settings = null;

            if (isForNewtonsoft)
            {
                if (SerializerSettings != null)
                {
                    newtonsoftSettings = (JsonSerializerSettings)(SerializerSettings);
                }
                else
                {
                    newtonsoftSettings = new JsonSerializerSettings();
                }

                newtonsoftSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                SerializerSettings = newtonsoftSettings;
            }
            else
            {
                if (SerializerSettings != null)
                {
                    settings = (JSSettings)(SerializerSettings);
                }
                else
                {
                    settings = new JSSettings();
                }

                settings.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                SerializerSettings = settings;
            }
        }
    }
}
