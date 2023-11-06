using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NodaTime;

namespace Athi.Whippet
{
    /// <summary>
    /// Represents the result of an operation. This can be chained together in a forward-only callstack. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetResult
    {
        private string _message;

        /// <summary>
        /// Gets a default <see cref="WhippetResult"/> with the <see cref="Severity"/> set to <see cref="WhippetResultSeverity.Success"/>. This property is read-only.
        /// </summary>
        public static WhippetResult Success
        {
            get
            {
                return new WhippetResult(WhippetResultSeverity.Success);
            }
        }

        /// <summary>
        /// Unique identifier of the <see cref="WhippetResult"/> instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Guid ID
        { get; private set; }

        /// <summary>
        /// The severity of the <see cref="WhippetResult"/> instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public WhippetResultSeverity Severity
        { get; private set; }

        /// <summary>
        /// Indicates whether the current instance is a successful operation. This property is read-only.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess
        {
            get
            {
                return Severity.HasFlag(WhippetResultSeverity.Success);
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
                if(String.IsNullOrWhiteSpace(_message))
                {
                    if(Exception != null)
                    {
                        _message = Exception.Message;
                    }
                }

                return _message;
            }
            private set
            {
                _message = value;
            }
        }

        /// <summary>
        /// <see cref="System.Exception"/> that was encountered in the operation. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Exception Exception
        { get; private set; }

        /// <summary>
        /// Gets the date/time the result was captured in UTC time. This property is read-only.
        /// </summary>
        [JsonProperty]
        public Instant Timestamp
        { get; private set; }

        /// <summary>
        /// <see cref="WhippetResult"/> that was encountered prior to the current instance. This property is read-only.
        /// </summary>
        [JsonProperty]
        public WhippetResult InnerResult
        { get; private set; }

        /// <summary>
        /// Object that was returned from the operation.
        /// </summary>
        public object ResultObject
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResult"/> class with no arguments.
        /// </summary>
        private WhippetResult()
        {
            ID = Guid.NewGuid();
            Timestamp = Instant.FromDateTimeUtc(DateTime.UtcNow);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResult"/> class with the specified parameters.
        /// </summary>
        /// <param name="severity"><see cref="WhippetResultSeverity"/> of the instance.</param>
        /// <param name="message">Message that contains extra information about the result or provides additional context.</param>
        /// <param name="exception"><see cref="System.Exception"/> that was captured at the time of the result.</param>
        /// <param name="innerResult"><see cref="WhippetResult"/> instance that was captured prior to this instance.</param>
        /// <param name="resultObject">Object that was returned from the operation.</param>
        public WhippetResult(WhippetResultSeverity severity, string message = null, Exception exception = null, WhippetResult innerResult = null, object resultObject = null)
            : this()
        {
            Severity = severity;
            Message = message;
            Exception = exception;
            InnerResult = innerResult;
            ResultObject = resultObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResult"/> class with the specified <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception"><see cref="System.Exception"/> object that was encountered. The <see cref="Severity"/> property will automatically be set to <see cref="WhippetResultSeverity.Failure"/>.</param>
        public WhippetResult(Exception exception)
            : this(WhippetResultSeverity.Failure, exception: exception)
        { }

        /// <summary>
        /// Throws an exception if <see cref="IsSuccess"/> is <see langword="false"/>.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void ThrowIfFailed()
        {
            if (!IsSuccess)
            {
                if (Exception != null)
                {
                    throw Exception;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="string"/> representation of the current object.
        /// </summary>
        /// <returns><see cref="string"/> representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(ID.ToString() + " ");
            builder.Append(Timestamp.ToString() + " : (");
            builder.Append(Severity.ToString());
            builder.Append(")");

            if (Exception != null || !String.IsNullOrWhiteSpace(Message))
            {
                builder.Append(" :: ");
            }

            if (Exception != null)
            {
                builder.Append(Exception.ToString());

                if (!String.IsNullOrWhiteSpace(Message))
                {
                    builder.Append(" :: ");
                }
            }

            if (!String.IsNullOrWhiteSpace(Message))
            {
                builder.Append(Message);
            }

            return builder.ToString();
        }
    }
}
