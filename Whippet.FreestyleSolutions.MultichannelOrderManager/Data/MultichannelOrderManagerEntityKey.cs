using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Represents an individual database table key (primary or foreign) within a Multichannel Order Manager database.  
    /// </summary>
    /// <typeparam name="T">Type of key being stored.</typeparam>
    public struct MultichannelOrderManagerEntityKey<T> : IEqualityComparer<MultichannelOrderManagerEntityKey<T>>, IMultichannelOrderManagerEntityKey, IEqualityComparer<IMultichannelOrderManagerEntityKey>, IEquatable<IMultichannelOrderManagerEntityKey> where T : struct
    {
        private readonly T _KeyValue;

        private readonly Type[] _AllowedTypes = new[]
        {
            typeof(byte), 
            typeof(sbyte), 
            typeof(short), 
            typeof(ushort), 
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(bool),
            typeof(char),
            typeof(decimal),
            typeof(WhippetNonNullableString)
        };

        /// <summary>
        /// Gets the <see cref="Type"/> of the underlying value. This property is read-only.
        /// </summary>
        Type IMultichannelOrderManagerEntityKey.ValueType
        {
            get
            {
                return _KeyValue.GetType();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntityKey{T}"/> struct with no arguments.
        /// </summary>
        static MultichannelOrderManagerEntityKey()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntityKey{T}"/> struct with no arguments.
        /// </summary>
        public MultichannelOrderManagerEntityKey()
            : this(default(T))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntityKey{T}"/> struct with the specified key value.
        /// </summary>
        /// <param name="keyValue">Key value to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerEntityKey(T keyValue)
        {
            if (!_AllowedTypes.Contains(typeof(T)))
            {
                throw new InvalidOperationException();
            }
            else
            {
                _KeyValue = keyValue;
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            bool equals = default(bool);
            
            if (obj == null || (!(obj is MultichannelOrderManagerEntityKey<T>) && !(obj is IMultichannelOrderManagerEntityKey)))
            {
                equals = false;
            }
            else
            {
                if (obj is MultichannelOrderManagerEntityKey<T>)
                {
                    equals = Equals((MultichannelOrderManagerEntityKey<T>)(obj));
                }
                else
                {
                    equals = ((IEqualityComparer<IMultichannelOrderManagerEntityKey>)(this)).Equals(obj);
                }
            }

            return equals;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerEntityKey<T> obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise <see langword="false"/>.</returns>
        bool IEquatable<IMultichannelOrderManagerEntityKey>.Equals(IMultichannelOrderManagerEntityKey obj)
        {
            return ((IEqualityComparer<IMultichannelOrderManagerEntityKey>)(this)).Equals(this, obj);
        }
        
        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerEntityKey<T> x, MultichannelOrderManagerEntityKey<T> y)
        {
            return x.ToValue().Equals(y.ToValue());
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        bool IEqualityComparer<IMultichannelOrderManagerEntityKey>.Equals(IMultichannelOrderManagerEntityKey x, IMultichannelOrderManagerEntityKey y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Equals(y);   // use the default implementation of the underlying class
            }

            return equals;
        }
        
        /// <summary>
        /// Returns the inner value of the current <see cref="MultichannelOrderManagerEntityKey{T}"/> object.
        /// </summary>
        /// <returns>Inner value.</returns>
        public T ToValue()
        {
            return _KeyValue;
        }

        /// <summary>
        /// Returns the inner value of the current <see cref="IMultichannelOrderManagerEntityKey"/> object.
        /// </summary>
        /// <typeparam name="TValue">Type of value stored in the <see cref="IMultichannelOrderManagerEntityKey"/>. Values who are of a different type will attempt to be converted.</typeparam>
        /// <returns>Inner value.</returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        TValue IMultichannelOrderManagerEntityKey.ToValue<TValue>() where TValue : struct
        {
            if (!_AllowedTypes.Contains(typeof(TValue)))
            {
                throw new InvalidOperationException();
            }
            else
            {
                return (TValue)(Convert.ChangeType(_KeyValue, typeof(TValue)));
            }
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return _KeyValue.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        public int GetHashCode(MultichannelOrderManagerEntityKey<T> obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        int IEqualityComparer<IMultichannelOrderManagerEntityKey>.GetHashCode(IMultichannelOrderManagerEntityKey obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string value of the current object.
        /// </summary>
        /// <returns>String value of the current object.</returns>
        public override string ToString()
        {
            return _KeyValue.ToString();
        }

        public static implicit operator T(MultichannelOrderManagerEntityKey<T> value)
        {
            return value.ToValue();
        }

        public static implicit operator MultichannelOrderManagerEntityKey<T>(T value)
        {
            return new MultichannelOrderManagerEntityKey<T>(value);
        }
    }
}
