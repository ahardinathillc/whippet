using System;
using System.Net;
using RestSharp;
using Athi.Whippet.Web;

namespace Athi.Whippet.Net.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="RestResponse"/> objects. This class cannot be inherited.
    /// </summary>
    public static class RestResponseExtensions
    {
        /// <summary>
        /// Indicates whether the status code is <see cref="HttpStatusCode.OK"/> for the specified <see cref="RestResponse"/>.
        /// </summary>
        /// <param name="response"><see cref="RestResponse"/> object.</param>
        /// <returns><see langword="true"/> if the status code is <see cref="HttpStatusCode.OK"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsOkStatus(this RestResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            else
            {
                return response.StatusCode == HttpStatusCode.OK;
            }
        }

        /// <summary>
        /// Throws an <see cref="HttpException"/> based on the status code and content values.
        /// </summary>
        /// <param name="response"><see cref="RestResponse"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="HttpException"></exception>
        public static void ThrowHttpException(this RestResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            else
            {
                throw new HttpException(response.StatusCode, response.Content);
            }
        }
    }
}

