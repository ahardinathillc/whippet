using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Athi.Whippet.Security;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// An action result which formats a <see cref="WhippetAuthenticationJsonResult"/> object as JSON. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetAuthenticationJsonResult : WhippetJsonResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetAuthenticationJsonResult"/> class with no arguments.
        /// </summary>
        /// <param name="response"><see cref="WhippetUserAuthenticationResponse"/> object to initialize with.</param>
        /// <param name="redirectToUrl">URL to redirect to upon successful authentication (if any).</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetAuthenticationJsonResult(WhippetUserAuthenticationResponse response, string redirectToUrl = null)
            : base(CreateAuthenticationJsonResponse(response, redirectToUrl))
        { }

        /// <summary>
        /// Creates a new anonymous object containing the properties of the <see cref="WhippetUserAuthenticationResponse"/> and associated redirection URL (if provided).
        /// </summary>
        /// <param name="response"><see cref="WhippetUserAuthenticationResponse"/> to create JSON object from.</param>
        /// <param name="redirectToUrl">URL to redirect to upon successful authentication (if any).</param>
        /// <returns>Anonymous object containing the properties to serialize.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static object CreateAuthenticationJsonResponse(WhippetUserAuthenticationResponse response, string redirectToUrl)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            else
            {
                return new
                {
                    userId = response.UserID.ToString(),
                    requestTimeStamp = response.RequestTimestamp.ToDateTimeUtc().ToString(),
                    responseStatus = response.ResponseStatus.ToString(),
                    ipAddress = response.IPAddress?.ToString(),
                    redirectUrl = redirectToUrl
                };
            }
        }
    }
}
