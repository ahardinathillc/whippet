using System;
using System.Collections;
using NodaTime;
using Docker.DotNet;

namespace Athi.Whippet.Docker
{
    /// <summary>
    /// Represents the result of a Docker operation. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class WhippetDockerResult<T>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="WhippetResultContainer{T}"/> object.
        /// </summary>
        private WhippetResultContainer<T> InternalResult
        { get; set; }
        
        /// <summary>
        /// Gets the <see cref="IDockerClient"/> that the result originated from. This property is read-only.
        /// </summary>
        public IDockerClient Client
        { get; private set; }

        /// <summary>
        /// Gets the item contained within the internal <see cref="WhippetResultContainer{T}"/>. This property is read-only.
        /// </summary>
        public T Item
        {
            get
            {
                return InternalResult.Item;
            }
        }

        /// <summary>
        /// The severity of the <see cref="WhippetDockerResult{T}"/> instance. This property is read-only.
        /// </summary>
        public WhippetResultSeverity Severity
        {
            get
            {
                return InternalResult.Severity;
            }
        }
        
        /// <summary>
        /// Indicates whether the current instance is a successful operation. This property is read-only.
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return InternalResult.IsSuccess;
            }
        }

        /// <summary>
        /// Message that was captured by the current instance. If the <see cref="Severity"/> property is <see cref="WhippetResultSeverity.Failure"/>, check the <see cref="Exception"/> property. This property is read-only.
        /// </summary>
        public string Message
        { 
            get
            {
                return InternalResult.Message;
            }
        }

        /// <summary>
        /// <see cref="System.Exception"/> that was encountered in the operation. This property is read-only.
        /// </summary>
        public Exception Exception
        { 
            get
            {
                return InternalResult.Exception;
            }
        }

        /// <summary>
        /// Gets the date/time the result was captured in UTC time. This property is read-only.
        /// </summary>
        public Instant Timestamp
        { 
            get
            {
                return InternalResult.Timestamp;
            }
        }

        /// <summary>
        /// Indicates whether <see cref="Item"/> is populated and, if an <see cref="IEnumerable"/>, checks to see if any items are present. This property is read-only.
        /// </summary>
        public bool HasItem
        {
            get
            {
                return InternalResult.HasItem;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerResult{T}"/> class with no arguments.
        /// </summary>
        private WhippetDockerResult()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerResult{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="result"><typeparamref name="T"/> object.</param>
        /// <param name="client"><see cref="IDockerClient"/> object.</param>
        /// <param name="severity">Severity of the operation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDockerResult(T result, IDockerClient client, WhippetResultSeverity severity = WhippetResultSeverity.Success)
            : this(new WhippetResultContainer<T>(new WhippetResult(severity), result), client)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDockerResult{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="result"><see cref="WhippetResultContainer{T}"/> object.</param>
        /// <param name="client"><see cref="IDockerClient"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDockerResult(WhippetResultContainer<T> result, IDockerClient client)
            : this()
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(client);

            InternalResult = result;
            Client = client;
        }

        public static implicit operator WhippetResultContainer<T>(WhippetDockerResult<T> result)
        {
            return (result == null) ? null : result.InternalResult;
        }
    }
}
