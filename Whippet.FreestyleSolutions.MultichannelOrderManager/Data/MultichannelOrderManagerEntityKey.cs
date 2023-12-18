using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Represents an individual database table key (primary or foreign) within a Multichannel Order Manager database.  
    /// </summary>
    /// <typeparam name="T">Type of key being stored.</typeparam>
    [CLSCompliant(false)]
    public struct MultichannelOrderManagerEntityKey<T> : IEqualityComparer<MultichannelOrderManagerEntityKey<T>>, IMultichannelOrderManagerEntityKey, IEqualityComparer<IMultichannelOrderManagerEntityKey>, IEquatable<IMultichannelOrderManagerEntityKey>, IConvertible where T : struct
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
            typeof(WhippetNonNullableString),
            typeof(Guid)
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
        
        #region IConvertible implementation

        /// <summary>Returns the <see cref="T:System.TypeCode" /> for this instance.</summary>
        /// <returns>The enumerated constant that is the <see cref="T:System.TypeCode" /> of the class or value type that implements this interface.</returns>
        TypeCode IConvertible.GetTypeCode()
        {
            TypeCode code = default(TypeCode);

            if (_KeyValue is IConvertible)
            {
                code = ((IConvertible)(_KeyValue)).GetTypeCode();
            }
            else
            {
                code = TypeCode.Object;
            }

            return code;
        }

        /// <summary>Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A Boolean value equivalent to the value of this instance.</returns>
        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {
            bool value = default(bool);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToBoolean(provider);
            }
            else
            {
                value = Convert.ToBoolean(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent Unicode character using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A Unicode character equivalent to the value of this instance.</returns>
        char IConvertible.ToChar(IFormatProvider? provider)
        {
            char value = default(char);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToChar(provider);
            }
            else
            {
                value = Convert.ToChar(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 8-bit signed integer equivalent to the value of this instance.</returns>
        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {
            sbyte value = default(sbyte);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToSByte(provider);
            }
            else
            {
                value = Convert.ToSByte(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 8-bit unsigned integer equivalent to the value of this instance.</returns>
        byte IConvertible.ToByte(IFormatProvider? provider)
        {
            byte value = default(byte);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToByte(provider);
            }
            else
            {
                value = Convert.ToByte(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 16-bit signed integer equivalent to the value of this instance.</returns>
        short IConvertible.ToInt16(IFormatProvider? provider)
        {
            short value = default(short);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToInt16(provider);
            }
            else
            {
                value = Convert.ToInt16(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 16-bit unsigned integer equivalent to the value of this instance.</returns>
        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {
            ushort value = default(ushort);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToUInt16(provider);
            }
            else
            {
                value = Convert.ToUInt16(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 32-bit signed integer equivalent to the value of this instance.</returns>
        int IConvertible.ToInt32(IFormatProvider? provider)
        {
            int value = default(int);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToInt32(provider);
            }
            else
            {
                value = Convert.ToInt32(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 32-bit unsigned integer equivalent to the value of this instance.</returns>
        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {
            uint value = default(uint);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToUInt32(provider);
            }
            else
            {
                value = Convert.ToUInt32(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 64-bit signed integer equivalent to the value of this instance.</returns>
        long IConvertible.ToInt64(IFormatProvider? provider)
        {
            long value = default(long);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToInt64(provider);
            }
            else
            {
                value = Convert.ToInt64(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 64-bit unsigned integer equivalent to the value of this instance.</returns>
        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {
            ulong value = default(ulong);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToUInt64(provider);
            }
            else
            {
                value = Convert.ToUInt64(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent single-precision floating-point number using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A single-precision floating-point number equivalent to the value of this instance.</returns>
        float IConvertible.ToSingle(IFormatProvider? provider)
        {
            float value = default(float);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToSingle(provider);
            }
            else
            {
                value = Convert.ToSingle(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent double-precision floating-point number using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A double-precision floating-point number equivalent to the value of this instance.</returns>
        double IConvertible.ToDouble(IFormatProvider? provider)
        {
            double value = default(double);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToDouble(provider);
            }
            else
            {
                value = Convert.ToDouble(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent <see cref="T:System.Decimal" /> number using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="T:System.Decimal" /> number equivalent to the value of this instance.</returns>
        Decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {
            decimal value = default(decimal);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToDecimal(provider);
            }
            else
            {
                value = Convert.ToDecimal(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent <see cref="T:System.DateTime" /> using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="T:System.DateTime" /> instance equivalent to the value of this instance.</returns>
        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {
            DateTime value = default(DateTime);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToDateTime(provider);
            }
            else
            {
                value = Convert.ToDateTime(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an equivalent <see cref="T:System.String" /> using the specified culture-specific formatting information.</summary>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="T:System.String" /> instance equivalent to the value of this instance.</returns>
        string IConvertible.ToString(IFormatProvider? provider)
        {
            string value = default(string);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToString(provider);
            }
            else
            {
                value = Convert.ToString(_KeyValue, provider);
            }

            return value;
        }

        /// <summary>Converts the value of this instance to an <see cref="T:System.Object" /> of the specified <see cref="T:System.Type" /> that has an equivalent value, using the specified culture-specific formatting information.</summary>
        /// <param name="conversionType">The <see cref="T:System.Type" /> to which the value of this instance is converted.</param>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An <see cref="T:System.Object" /> instance of type <paramref name="conversionType" /> whose value is equivalent to the value of this instance.</returns>
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            object value = default(object);
            
            if (_KeyValue is IConvertible)
            {
                value = ((IConvertible)(_KeyValue)).ToType(conversionType, provider);
            }
            else
            {
                value = Convert.ChangeType(_KeyValue, conversionType, provider);
            }

            return value;
        }
        
        #endregion
    }
}
