using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NodaTime;
using Athi.Whippet.Extensions;

namespace Athi.Whippet
{
    /// <summary>
    /// Similiar to a <see cref="Tuple{T1, T2}"/>, this class provides a pairing of a <see cref="WhippetResult"/> and an accompanying object that triggered the result. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T">Type of object stored in the container.</typeparam>
    public sealed class WhippetResultContainer<T>
    {
        /// <summary>
        /// <see cref="WhippetResult"/> object that is associated with the current instance. This property is read-only.
        /// </summary>
        public WhippetResult Result
        { get; private set; }

        /// <summary>
        /// The severity of the <see cref="WhippetResult"/> instance. This property is read-only.
        /// </summary>
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
        public bool IsSuccess
        {
            get
            {
                return Result.IsSuccess;
            }
        }

        /// <summary>
        /// Message that was captured by the current instance. If the <see cref="Severity"/> property is <see cref="WhippetResultSeverity.Failure"/>, check the <see cref="Exception"/> property. This property is read-only.
        /// </summary>
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
        public Instant Timestamp
        { 
            get
            {
                return Result.Timestamp;
            }
        }

        /// <summary>
        /// Indicates whether <see cref="Item"/> is populated and, if an <see cref="IEnumerable"/>, checks to see if any items are present. This property is read-only.
        /// </summary>
        public bool HasItem
        {
            get
            {
                bool hasResults = false;
                IEnumerator enumerator = null;

                if(Item != null)
                {
                    hasResults = true;

                    if(Item is IEnumerable)
                    {
                        enumerator = ((IEnumerable)(Item)).GetEnumerator();
                        hasResults = enumerator.MoveNext();
                    }
                }

                return hasResults;
            }
        }

        /// <summary>
        /// Gets the item that is stored in the result. This property is read-only.
        /// </summary>
        public T Item
        { get; private set; }

        /// <summary>
        /// Indicates whether <typeparamref name="T"/> is an enumerable collection of objects by implementing <see cref="IEnumerable"/>. This property is read-only.
        /// </summary>
        public bool ItemIsEnumerable
        {
            get
            {
                bool isEnumerable = false;
                Type[] types = typeof(T).GetInterfaces();

                foreach (Type type in types)
                {
                    if (type == typeof(IEnumerable))
                    {
                        isEnumerable = true;
                    }
                }

                return isEnumerable;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResultContainer{T}"/> class with no arguments.
        /// </summary>
        private WhippetResultContainer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResultContainer{T}"/> class with the specified <see cref="WhippetResult"/> and associated item.
        /// </summary>
        /// <param name="result"><see cref="WhippetResult"/> instance that is associated with <paramref name="item"/>.</param>
        /// <param name="item">Item that triggered the <see cref="WhippetResult"/> object.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetResultContainer(WhippetResult result, T item)
        { 
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else
            {
                Result = result;
                Item = item;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetResultContainer{T}"/> class with the specified <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="exception"><see cref="System.Exception"/> that was captured.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetResultContainer(Exception exception)
            : this(new WhippetResult(exception), default(T))
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }
        }

        /// <summary>
        /// Gets the <see cref="string"/> representation of the current object.
        /// </summary>
        /// <returns><see cref="string"/> representation of the current object.</returns>
        public override string ToString()
        {
            return Result.ToString();
        }

        /// <summary>
        /// Throws an exception if <see cref="IsSuccess"/> is <see langword="false"/> or if the specified <see cref="CancellationToken"/> has been canceled.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> object.</param>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        public void ThrowIfFailed(CancellationToken cancellationToken = default(CancellationToken))
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
            else
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        /// Converts the current <see cref="WhippetResultContainer{T}"/> object to one that contains an <see cref="IEnumerable{T}"/> item. If <see cref="Item"/> is <see langword="null"/>, the new result item will be an empty collection.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        public WhippetResultContainer<IEnumerable<T>> ToEnumerableResult()
        {
            return new WhippetResultContainer<IEnumerable<T>>(Result, Item == null ? Enumerable.Empty<T>() : new[] { Item });
        }

        /// <summary>
        /// Converts the current <see cref="WhippetResultContainer{T}"/> object's containing <see cref="WhippetResultContainer{T}.Item"/> to the specified type.
        /// </summary>
        /// <typeparam name="TCast">Type that <typeparamref name="T"/> derives from or implements.</typeparam>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="InvalidCastException" />
        public WhippetResultContainer<TCast> CastTo<TCast>()
        {
            return new WhippetResultContainer<TCast>(Result, (TCast)((object)(Item)));
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetResultContainer{T}"/> object's containing <see cref="WhippetResultContainer{T}.Item"/> to the specified type.
        /// </summary>
        /// <typeparam name="TCast">Type that <typeparamref name="TItem"/> derives from or implements.</typeparam>
        /// <typeparam name="TItem">Type that implements or is of type <typeparamref name="TCast"/>.</typeparam>
        /// <param name="resultContainer"><see cref="WhippetResultContainer{T}"/> object to cast.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetResultContainer<TCast> CastTo<TCast, TItem>(WhippetResultContainer<TItem> resultContainer) where TItem : TCast
        {
            if (resultContainer == null)
            {
                throw new ArgumentNullException(nameof(resultContainer));
            }
            else
            {
                return new WhippetResultContainer<TCast>(resultContainer.Result, resultContainer.Item);
            }
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetResultContainer{T}"/> object to a <see cref="WhippetResult"/> object.
        /// </summary>
        /// <param name="resultContainer"><see cref="WhippetResultContainer{T}"/> object to convert.</param>
        public static implicit operator WhippetResult(WhippetResultContainer<T> resultContainer)
        {
            return (resultContainer == null) ? null : resultContainer.Result;
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetResultContainer{T}"/> object to a <see cref="Tuple{T1, T2}"/> object.
        /// </summary>
        /// <param name="resultContainer"><see cref="WhippetResultContainer{T}"/> object to convert.</param>
        public static implicit operator Tuple<WhippetResult, T>(WhippetResultContainer<T> resultContainer)
        {
            return (resultContainer == null) ? null : new Tuple<WhippetResult, T>(resultContainer.Result, resultContainer.Item);
        }

        /// <summary>
        /// Converts the specified <see cref="Tuple{T1, T2}"/> object to a <see cref="WhippetResultContainer{T}"/> object.
        /// </summary>
        /// <param name="resultContainer"><see cref="Tuple{T1, T2}"/> object to convert.</param>
        public static implicit operator WhippetResultContainer<T>(Tuple<WhippetResult, T> resultContainer)
        {
            return (resultContainer == null) ? null : new WhippetResultContainer<T>(resultContainer.Item1, resultContainer.Item2);
        }

        /// <summary>
        /// Converts the specified <see cref="KeyValuePair{TKey, TValue}"/> object to a <see cref="WhippetResultContainer{T}"/> object.
        /// </summary>
        /// <param name="resultContainer"><see cref="KeyValuePair{T1, T2}"/> object to convert.</param>
        public static implicit operator WhippetResultContainer<T>(KeyValuePair<WhippetResult, T>? resultContainer)
        {
            return (resultContainer == null) ? null : new WhippetResultContainer<T>(resultContainer.Value.Key, resultContainer.Value.Value);
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetResultContainer{T}"/> object to a <see cref="KeyValuePair{TKey, TValue}"/> object.
        /// </summary>
        /// <param name="resultContainer"><see cref="WhippetResultContainer{T}"/> object to convert.</param>
        public static implicit operator KeyValuePair<WhippetResult, T>?(WhippetResultContainer<T> resultContainer)
        {
            return (resultContainer == null) ? null : new WhippetResultContainer<T>(resultContainer.Result, resultContainer.Item);
        }
    }
}
