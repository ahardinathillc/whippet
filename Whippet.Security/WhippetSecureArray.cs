using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isopoh.Cryptography.SecureArray;

namespace Athi.Whippet.Security
{
    /// <summary>
    /// Manages an array that holds sensitive information. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T">The type of the array. Limited to primitive types.</typeparam>
    public sealed class WhippetSecureArray<T> : IDisposable, IEnumerable<T>, IReadOnlyList<T>, IEqualityComparer<WhippetSecureArray<T>>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SecureArray{T}"/> object.
        /// </summary>
        private SecureArray<T> Array
        { get; set; }

        /// <summary>
        /// Gets the secure array buffer. This property is read-only.
        /// </summary>
        public T[] Buffer
        {
            get
            {
                return Array.Buffer;
            }
        }

        /// <summary>
        /// Gets or sets the element in the secure array.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element located at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public T this [int index]
        {
            get
            {
                return Array[index];
            }
            set
            {
                Array[index] = value;
            }
        }

        /// <summary>
        /// Gets the number of elements in the array. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return Buffer.Length;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureArray{T}"/> class with no arguments.
        /// </summary>
        private WhippetSecureArray()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureArray{T}"/> class with the specified <see cref="SecureArray{T}"/> object.
        /// </summary>
        /// <param name="secureArray"><see cref="SecureArray{T}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSecureArray(SecureArray<T> secureArray)
            : this()
        { 
            if(secureArray == null)
            {
                throw new ArgumentNullException(nameof(secureArray));
            }
            else
            {
                Array = secureArray;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureArray{T}"/> class with.
        /// </summary>
        /// <param name="size">The number of elements in the secure array.</param>
        /// <param name="type">The type of secure array to initialize.</param>
        /// <param name="call">The method(s) that get called to secure the array or <see langword="null"/> to use <see cref="SecureArray.DefaultCall"/>.</param>
        public WhippetSecureArray(int size, SecureArrayType type, SecureArrayCall call)
            : this(new SecureArray<T>(size, type, call))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureArray{T}"/> class with.
        /// </summary>
        /// <param name="size">The number of elements in the secure array.</param>
        /// <param name="type">The type of secure array to initialize.</param>
        public WhippetSecureArray(int size, SecureArrayType type)
            : this(new SecureArray<T>(size, type))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureArray{T}"/> class with.
        /// </summary>
        /// <param name="size">The number of elements in the secure array.</param>
        public WhippetSecureArray(int size)
            : this(new SecureArray<T>(size))
        { }

        /// <summary>
        /// Copies values from the specified array into the current array.
        /// </summary>
        /// <param name="values">Values to copy.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void CopyFromArray(T[] values)
        {
            if(values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if(values.Length > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(values.Length));
            }
            else
            {
                for(int i = 0; i < values.Length; i++)
                {
                    this[i] = values[i];
                }
            }
        }

        /// <summary>
        /// Returns the "best" secure array possible.
        /// </summary>
        /// <param name="size">The number of elements in the returned array.</param>
        /// <param name="call">The method(s) that get called to secure the array or <see langword="null"/> to use <see cref="SecureArray.DefaultCall"/>.</param>
        /// <returns><see cref="WhippetSecureArray{T}"/> object.</returns>
        public static WhippetSecureArray<T> CreateBestAttempt(int size, SecureArrayCall secureArrayCall)
        {
            return new WhippetSecureArray<T>(SecureArray<T>.Best(size, secureArrayCall));
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            Array.Dispose();
            Array = null;
        }

        /// <summary>
        /// Returns an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> used to iterate over each item.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> used to iterate over each item.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in Array.Buffer)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Compares the current array to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetSecureArray<T>);
        }

        /// <summary>
        /// Compares the current array to the specified array for equality.
        /// </summary>
        /// <param name="array">Array to compare against.</param>
        /// <returns><see langword="true"/> if the arrays are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetSecureArray<T> array)
        {
            return (array == null) ? false : Equals(this, array);
        }

        /// <summary>
        /// Compares the two secure arrays for equality.
        /// </summary>
        /// <param name="x">First array to compare.</param>
        /// <param name="y">Second array to compare.</param>
        /// <returns><see langword="true"/> if the arrays are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetSecureArray<T> x, WhippetSecureArray<T> y)
        {
            bool equals = false;

            if(x == null && y == null)
            {
                equals = true;
            }
            else if(x != null && y != null)
            {
                if(x.Count == y.Count)
                {
                    equals = true;

                    for(int i = 0; i < x.Count; i++)
                    {
                        if(x[i] == null && y[i] == null)
                        {
                            continue;
                        }
                        else if((x[i] != null && y[i] == null) || (x[i] == null && y[i] != null))
                        {
                            equals = false;
                            break;
                        }
                        else
                        {
                            if(!x[i].Equals(y[i]))
                            {
                                equals = false;
                                break;
                            }
                        }
                    }
                }
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return Array.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="array"><see cref="WhippetSecureArray{T}"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetSecureArray<T> array)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            else
            {
                return array.GetHashCode();
            }
        }
    }
}
