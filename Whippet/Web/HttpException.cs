using System;
using System.Net;

namespace Athi.Whippet.Web
{
    /// <summary>
    /// Exception that is thrown when an error is encountered handling an HTTP request. This class cannot be inherited.
    /// </summary>
    public sealed class HttpException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code that was encountered. This property is read-only.
        /// </summary>
        public int StatusCode
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        public HttpException(int httpStatusCode)
            : this(httpStatusCode, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        public HttpException(HttpStatusCode httpStatusCode)
            : this((int)(httpStatusCode))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        /// <param name="message">Error message to display.</param>
        public HttpException(int httpStatusCode, string message)
            : this(httpStatusCode, message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        /// <param name="message">Error message to display.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message)
            : this((int)(httpStatusCode), message, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        /// <param name="message">Error message to display.</param>
        /// <param name="inner"><see cref="Exception"/> that was captured prior to the current instance being thrown.</param>
        public HttpException(int httpStatusCode, string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = httpStatusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code.
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code that was encountered.</param>
        /// <param name="message">Error message to display.</param>
        /// <param name="inner"><see cref="Exception"/> that was captured prior to the current instance being thrown.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message, Exception inner)
            : this((int)(httpStatusCode), message, inner)
        { }
    }
}
