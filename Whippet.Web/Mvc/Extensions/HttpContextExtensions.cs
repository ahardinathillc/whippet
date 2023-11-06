using System;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Athi.Whippet.Web.Mvc.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="HttpContext"/> objects. This class cannot be inherited.
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Gets the IP address for the current request.
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/> for the current instance.</param>
        /// <returns>IP address.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetIpAddress(this HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                string ipAddress = null;

                if (!String.IsNullOrWhiteSpace(context.Request.Headers["X-Forwarded-For"]))
                {
                    ipAddress = context.Request.Headers["X-Forwarded-For"];
                }
                else
                {
                    ipAddress = context.Connection.RemoteIpAddress?.ToString();

                    // if we were unable to resolve the IP address, default to server address

                    if (String.IsNullOrWhiteSpace(ipAddress))
                    {
                        ipAddress = context.Connection.LocalIpAddress?.ToString();

                        // if that's null, default to loopback

                        if (String.IsNullOrWhiteSpace(ipAddress))
                        {
                            ipAddress = IPAddress.Parse("127.0.0.1").ToString();
                        }
                    }
                }

                return ipAddress;
            }
        }
    }
}

