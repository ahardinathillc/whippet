using System;
using System.Text;
using NodaTime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Specialized <see cref="WhippetResult"/> object that contains extra metadata information about a <see cref="WhippetUserAuthenticationResponse"/>. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetUserAuthenticationResult
    {
        /// <summary>
        /// Gets or sets the internal <see cref="WhippetResult"/> object.
        /// </summary>
        private WhippetResult Result
        { get; set; }

        /// <summary>
        /// Gets a default <see cref="WhippetResult"/> with the <see cref="Severity"/> set to <see cref="WhippetResultSeverity.Success"/>. This property is read-only.
        /// </summary>
        public static WhippetUserAuthenticationResult Success
        {
            get
            {
                return new WhippetUserAuthenticationResult();
            }
        }

        /// <summary>
        /// Gets the response that was captured from the authentication method. This property is read-only.
        /// </summary>
        public WhippetUserAuthenticationResponse Response
        { get; private set; }

        /// <summary>
        /// Unique identifier of the <see cref="WhippetUserAuthenticationResult"/> instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Guid ID
        {
            get
            {
                return Result.ID;
            }
        }

        /// <summary>
        /// The severity of the <see cref="WhippetUserAuthenticationResult"/> instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public WhippetResultSeverity Severity
        {
            get
            {
                return Result.Severity;
            }
        }

        /// <summary>
        /// Indicates whether the current instance is a successful operation. This property is read-only.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess
        {
            get
            {
                return Severity.HasFlag(WhippetResultSeverity.Success) && (Response.ResponseStatus == WhippetUserAuthenticationResponseStatus.Success);
            }
        }

        /// <summary>
        /// Message that was captured by the current instance. If the <see cref="Severity"/> property is <see cref="WhippetResultSeverity.Failure"/>, check the <see cref="Exception"/> property. This property is read-only.
        /// </summary>
        [JsonProperty]
        public string Message
        {
            get
            {
                return Result.Message;
            }
        }

        /// <summary>
        /// <see cref="System.Exception"/> that was encountered in the operation. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Exception Exception
        {
            get
            {
                return Result.Exception;
            }
        }

        /// <summary>
        /// Gets the date/time the result was captured in UTC time. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Instant Timestamp
        {
            get
            {
                return Result.Timestamp;
            }
        }

        /// <summary>
        /// <see cref="WhippetResult"/> that was encountered prior to the current instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        public WhippetResult InnerResult
        {
            get
            {
                return Result.InnerResult;
            }
        }

        /// <summary>
        /// Object that was returned from the operation. This property is read-only.
        /// </summary>
        public object ResultObject
        {
            get
            {
                return Result.ResultObject;
            }
        }

        /// <summary>
        /// Gets the URL to redirect to (if any). This property is read-only.
        /// </summary>
        public string RedirectUrl
        { get; private set; }

        /// <summary>
        /// Indicates whether <see cref="RedirectUrl"/> has a value. This property is read-only.
        /// </summary>
        public bool HasRedirect
        {
            get
            {
                return !String.IsNullOrWhiteSpace(RedirectUrl);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAuthenticationResult"/> class with no arguments.
        /// </summary>
        private WhippetUserAuthenticationResult()
        {
            Result = WhippetResult.Success;
            Response = new WhippetUserAuthenticationResponse(Guid.Empty, Instant.FromDateTimeUtc(DateTime.UtcNow), WhippetUserAuthenticationResponseStatus.Success);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserAuthenticationResult"/> class with the specified <see cref="WhippetResult"/> and <see cref="WhippetUserAuthenticationResponse"/> objects.
        /// </summary>
        /// <param name="result"><see cref="WhippetResult"/> object.</param>
        /// <param name="response"><see cref="WhippetUserAuthenticationResponse"/> object.</param>
        /// <param name="redirectUrl">URL to redirect to (if any).</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserAuthenticationResult(WhippetResult result, WhippetUserAuthenticationResponse response, string redirectUrl)
            : this()
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            else
            {
                Result = result;
                Response = response;
                RedirectUrl = redirectUrl;
            }
        }

        /// <summary>
        /// Gets the <see cref="string"/> representation of the current object.
        /// </summary>
        /// <returns><see cref="string"/> representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(Result.ToString());

            builder.Append(" :: ");

            builder.Append('(');
            builder.Append(Response.ToString());
            builder.Append(')');

            return builder.ToString();
        }

        public static implicit operator WhippetResult(WhippetUserAuthenticationResult result)
        {
            return (result == null) ? null : result.Result;
        }
    }
}

