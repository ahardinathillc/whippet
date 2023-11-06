using System;
using System.Text;
using System.Numerics;
using System.Runtime.Serialization;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using NodaMoney;

namespace Athi.Whippet.Localization
{
    /// <summary>
    /// Represents a <see cref="decimal"/> value that is displayed as a currency based on a supplied <see cref="CultureInfo"/>.
    /// </summary>
    public struct CurrencyValue : IComparable<CurrencyValue>, IConvertible, IEquatable<CurrencyValue>, IParsable<CurrencyValue>, ISpanParsable<CurrencyValue>, IAdditionOperators<CurrencyValue, CurrencyValue, CurrencyValue>, IAdditiveIdentity<CurrencyValue, CurrencyValue>, IComparisonOperators<CurrencyValue, CurrencyValue, bool>, IDecrementOperators<CurrencyValue>, IDivisionOperators<CurrencyValue, CurrencyValue, CurrencyValue>, IEqualityOperators<CurrencyValue, CurrencyValue, bool>, IFloatingPoint<CurrencyValue>, IFloatingPointConstants<CurrencyValue>, IIncrementOperators<CurrencyValue>, IMinMaxValue<CurrencyValue>, IModulusOperators<CurrencyValue, CurrencyValue, CurrencyValue>, IMultiplicativeIdentity<CurrencyValue, CurrencyValue>, IMultiplyOperators<CurrencyValue, CurrencyValue, CurrencyValue>, INumber<CurrencyValue>, INumberBase<CurrencyValue>, ISignedNumber<CurrencyValue>, ISubtractionOperators<CurrencyValue, CurrencyValue, CurrencyValue>, IUnaryNegationOperators<CurrencyValue, CurrencyValue>, IUnaryPlusOperators<CurrencyValue, CurrencyValue>, IDeserializationCallback, ISerializable
    {
        private const byte DEFAULT_DECIMAL_PLACES = 2;

        /// <summary>
        /// Gets the internal <see cref="decimal"/> value. This field is read-only.
        /// </summary>
        private readonly decimal _Value;

        private readonly CultureInfo _Culture;

        /// <summary>
        /// Represents the largest possible value of <see cref="CurrencyValue"/>. This property is read-only.
        /// </summary>
        public static CurrencyValue MaxValue
        {
            get
            {
                return decimal.MaxValue;
            }
        }

        /// <summary>
        /// Represents the smallest possible value of <see cref="CurrencyValue"/>. This property is read-only.
        /// </summary>
        public static CurrencyValue MinValue
        {
            get
            {
                return decimal.MinValue;
            }
        }

        /// <summary>
        /// Represents the number negative one (-1). This property is read-only.
        /// </summary>
        public static CurrencyValue MinusOne
        {
            get
            {
                return decimal.MinusOne;
            }
        }

        /// <summary>
        /// Represents the number one (1). This property is read-only.
        /// </summary>
        public static CurrencyValue One
        {
            get
            {
                return decimal.One;
            }
        }

        /// <summary>
        /// Represents the number zero (0). This property is read-only.
        /// </summary>
        public static CurrencyValue Zero
        {
            get
            {
                return decimal.Zero;
            }
        }

        /// <summary>
        /// Gets the value 1 for the type. This property is read-only.
        /// </summary>
        static CurrencyValue INumberBase<CurrencyValue>.One
        {
            get
            {
                return decimal.One;
            }
        }

        /// <summary>
        /// Gets the value -1 for the type. This property is read-only.
        /// </summary>
        static CurrencyValue ISignedNumber<CurrencyValue>.NegativeOne
        {
            get
            {
                return -One;
            }
        }

        /// <summary>
        /// Gets the radix, or base, for the type. This property is read-only.
        /// </summary>
        static int INumberBase<CurrencyValue>.Radix
        {
            get
            {
                return 10;  // base 10
            }
        }

        /// <summary>
        /// Gets the scaling factor of the decimal, which is a number from 0 to 28 that represents the number of decimal digits. This property is read-only.
        /// </summary>
        public byte Scale
        {
            get
            {
                return _Value.Scale;
            }
        }

        /// <summary>
        /// Gets the additive identity of the current type. This property is read-only.
        /// </summary>
        static CurrencyValue IAdditiveIdentity<CurrencyValue, CurrencyValue>.AdditiveIdentity
        {
            get
            {
                return default(CurrencyValue);
            }
        }

        /// <summary>
        /// This property is not supported in this context.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        static CurrencyValue IFloatingPointConstants<CurrencyValue>.E
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// This property is not supported in this context.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        static CurrencyValue IFloatingPointConstants<CurrencyValue>.Pi
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// This property is not supported in this context.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        static CurrencyValue IFloatingPointConstants<CurrencyValue>.Tau
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the maximum value of the current type. This property is read-only.
        /// </summary>
        static CurrencyValue IMinMaxValue<CurrencyValue>.MaxValue
        {
            get
            {
                return decimal.MaxValue;
            }
        }

        /// <summary>
        /// Gets the minimum value of the current type. This property is read-only.
        /// </summary>
        static CurrencyValue IMinMaxValue<CurrencyValue>.MinValue
        {
            get
            {
                return decimal.MinValue;
            }
        }

        /// <summary>
        /// Gets the multiplicative identity of the current type.
        /// </summary>
        static CurrencyValue IMultiplicativeIdentity<CurrencyValue, CurrencyValue>.MultiplicativeIdentity
        {
            get
            {
                return default(decimal);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with no arguments.
        /// </summary>
        static CurrencyValue()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(decimal value, CultureInfo culture = null)
            : this()
        {
            _Value = value;
            _Culture = culture ?? CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(float value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(double value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(byte value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(int value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(long value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(short value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(sbyte value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(uint value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(ulong value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value">Value to initialize with.</param>
        /// <param name="culture">Culture to display the value in. If <see langword="null"/>, the current culture will be used.</param>
        public CurrencyValue(ushort value, CultureInfo culture = null)
            : this(Convert.ToDecimal(value), culture)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyValue"/> struct with the specified value.
        /// </summary>
        /// <param name="value"><see cref="Money"/> value to initialize with.</param>
        public CurrencyValue(Money value)
            : this(value.Amount)
        { }

        /// <summary>
        /// Computes the absolute of a value.
        /// </summary>
        /// <param name="value">The value for which to get its absolute.</param>
        /// <returns>The absolute of <paramref name="value"/>.</returns>
        public static CurrencyValue Abs(CurrencyValue value)
        {
            return decimal.Abs(value);
        }

        /// <summary>
        /// Adds to specified <see cref="CurrencyValue"/> values.
        /// </summary>
        /// <param name="d1">The first value to add.</param>
        /// <param name="d2">The second value to add.</param>
        /// <returns>The sum of <paramref name="d1"/> and <paramref name="d2"/>.</returns>
        /// <exception cref="OverflowException" />
        public static CurrencyValue Add(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Add(d1, d2);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// <param name="d">A decimal number.</param>
        /// <returns>The smallest integral value that is greater than or equal to the <paramref name="d"/> parameter. Note that this method returns a <see cref="CurrencyValue"/> instead of an integral type.</returns>
        public static CurrencyValue Ceiling(CurrencyValue d)
        {
            return decimal.Ceiling(d);
        }

        /// <summary>
        /// Clamps a value to an inclusive minimum and maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The inclusive minimum to which <paramref name="value"/> should clamp.</param>
        /// <param name="max">The inclusive maximum to which <paramref name="value"/> should clamp.</param>
        /// <returns>The result of clamping <paramref name="value"/> to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.</returns>
        public static CurrencyValue Clamp(CurrencyValue value, CurrencyValue min, CurrencyValue max)
        {
            return decimal.Clamp(value, min, max);
        }

        /// <summary>
        /// Compares two specified <see cref="CurrencyValue"/> values.
        /// </summary>
        /// <param name="d1">The first value to compare.</param>
        /// <param name="d2">The second value to compare.</param>
        /// <returns>A signed number indicating the relative values of <paramref name="d1"/> and <paramref name="d2"/>. A value less than zero indicates that <paramref name="d1"/> is less than <paramref name="d2"/>; a value greater than zero indicates that <paramref name="d1"/> is greater than <paramref name="d2"/>; a value of zero indicates that the values are equal.</returns>
        public static int Compare(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Compare(d1, d2);
        }

        /// <summary>
        /// Compares this instance to a specified object or <see cref="CurrencyValue"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="value">The object to compare with this instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>. A value less than zero indicates that this instance is less than <paramref name="value"/>; a value greater than zero indicates that this instance is greater than <paramref name="value"/>; a value of zero indicates that this instance and <see cref="value"/> are equal.</returns>
        public int CompareTo(CurrencyValue value)
        {
            return _Value.CompareTo(value);
        }

        /// <summary>
        /// Compares this instance to a specified object or <see cref="CurrencyValue"/> and returns an indication of their relative values.
        /// </summary>
        /// <param name="value">The object to compare with this instance, or <see langword="null"/>.</param>
        /// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>. A value less than zero indicates that this instance is less than <paramref name="value"/>; a value greater than zero indicates that this instance is greater than <paramref name="value"/>; a value of zero indicates that this instance and <see cref="value"/> are equal.</returns>
        /// <exception cref="ArgumentException" />
        public int CompareTo(object value)
        {
            return _Value.CompareTo(value);
        }

        /// <summary>
        /// Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <see cref="CurrencyValue"/>.</param>
        /// <returns>An instance of <see cref="CurrencyValue"/> created from <paramref name="value"/>.</returns>
        public static CurrencyValue CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>
        {
            return decimal.CreateChecked<TOther>(value);
        }

        /// <summary>
        /// Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <see cref="CurrencyValue"/>.</param>
        /// <returns>An instance of <see cref="CurrencyValue"/> created from <paramref name="value"/>, saturating if <paramref name="value"/> falls outside the representable range of <see cref="CurrencyValue"/>.</returns>
        public static CurrencyValue CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>
        {
            return decimal.CreateSaturating<TOther>(value);
        }

        /// <summary>
        /// Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <see cref="CurrencyValue"/>.</param>
        /// <returns>An instance of <see cref="CurrencyValue"/> created from <paramref name="value"/>, truncating if <paramref name="value"/> falls outside the representable range of <see cref="CurrencyValue"/>.</returns>
        public static CurrencyValue CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>
        {
            return decimal.CreateTruncating<TOther>(value);
        }

        /// <summary>
        /// Divides two specified <see cref="CurrencyValue"/> values.
        /// </summary>
        /// <param name="d1">The dividend.</param>
        /// <param name="d2">The divisor.</param>
        /// <returns>The result of dividing <paramref name="d1"/> by <paramref name="d2"/>.</returns>
        /// <exception cref="DivideByZeroException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Divide(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Divide(d1, d2);
        }

        /// <summary>
        /// Copies the sign of a value to the sign of another value.
        /// </summary>
        /// <param name="value">The sign whose magnitude is used in the result.</param>
        /// <param name="sign">The value whose sign is used in the result.</param>
        /// <returns>A value with the magnitude of <paramref name="value"/> and the sign of <paramref name="sign"/>.</returns>
        public static CurrencyValue CopySign(CurrencyValue value, CurrencyValue sign)
        {
            return decimal.CopySign(value, sign);
        }

        /// <summary>
        /// Returns a value indicating whether two instances of <see cref="CurrencyValue"/> represent the same value.
        /// </summary>
        /// <param name="d1">The first value to compare.</param>
        /// <param name="d2">The second value to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="d1"/> and <paramref name="d2"/> are equal; otherwise, <see langword="false"/>.</returns>
        public static bool Equals(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Equals(d1, d2);
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified <see cref="Object"/> represent the same type and value.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="CurrencyValue"/> and equal to this instance; otherwise, <see langword="false"/>.</returns>
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return _Value.Equals(obj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified <see cref="CurrencyValue"/> represent the same value.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CurrencyValue value)
        {
            return _Value.Equals(value);
        }

        /// <summary>
        /// Rounds a specified <see cref="CurrencyValue"/> number to the closest integer toward negative infinity.
        /// </summary>
        /// <param name="d">The value to round.</param>
        /// <returns>If <paramref name="d"/> has a fractional part, the next whole <see cref="CurrencyValue"/> number toward negative infinity that is less than <paramref name="d"/>; otherwise, the unchanged value of <paramref name="d"/>.</returns>
        public static CurrencyValue Floor(CurrencyValue d)
        {
            return decimal.Floor(d);
        }

        /// <summary>
        /// Converts the specified 64-bit signed integer, which contains an OLE Automation Currency value, to the equivalent <see cref="CurrencyValue"/> value.
        /// </summary>
        /// <param name="cy">An OLE Automation Currency value.</param>
        /// <returns>A <see cref="CurrencyValue"/> that contains the equivalent of <paramref name="cy"/>.</returns>
        public static CurrencyValue FromOACurrency(long cy)
        {
            return decimal.FromOACurrency(cy);
        }

        /// <summary>
        /// Converts the value of a specified instance of <see cref="CurrencyValue"/> to its equivalent binary representation.
        /// </summary>
        /// <param name="d">The value to convert.</param>
        /// <returns>A 32-bit signed integer array with four elements that contains the binary representation of <paramref name="d"/>.</returns>
        public static int[] GetBits(CurrencyValue d)
        {
            return decimal.GetBits(d);
        }

        /// <summary>
        /// Converts the value of a specified instance of <see cref="CurrencyValue"/> to its equivalent binary representation.
        /// </summary>
        /// <param name="d">The value to convert.</param>
        /// <param name="destination">The span into which to store the four-integer binary representation.</param>
        /// <returns>The number of integers (4) in the binary representation.</returns>
        /// <exception cref="ArgumentException" />
        public static int GetBits(CurrencyValue d, Span<int> destination)
        {
            return decimal.GetBits(d, destination);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _Value.GetHashCode();
        }

        /// <summary>
        /// Returns the <see cref="TypeCode"/> for value type <see cref="Decimal"/>.
        /// </summary>
        /// <returns>The enumerated constant <see cref="TypeCode.Decimal"/>.</returns>
        public TypeCode GetTypeCode()
        {
            return _Value.GetTypeCode();
        }

        /// <summary>
        /// Determines if a value is in its canonical representation.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is in its canonical representation; otherwise, <see langword="false"/>.</returns>
        public static bool IsCanonical(CurrencyValue value)
        {
            return decimal.IsCanonical(value);
        }

        /// <summary>
        /// Determines if a value represents an even integral number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is an even integer; otherwise, <see langword="false"/>.</returns>
        public static bool IsEvenInteger(CurrencyValue value)
        {
            return decimal.IsEvenInteger(value);
        }

        /// <summary>
        /// Determines if a value represents an integral number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is an integer; otherwise, <see langword="false"/>.</returns>
        public static bool IsInteger(CurrencyValue value)
        {
            return decimal.IsInteger(value);
        }

        /// <summary>
        /// Determines if a value is negative.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is negative; otherwise, <see langword="false"/>.</returns>
        public static bool IsNegative(CurrencyValue value)
        {
            return decimal.IsNegative(value);
        }

        /// <summary>
        /// Determines if a value represents an odd integral number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is an odd integer; otherwise, <see langword="false"/>.</returns>
        public static bool IsOddInteger(CurrencyValue value)
        {
            return decimal.IsOddInteger(value);
        }

        /// <summary>
        /// Determines if a value is positive.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is positive; otherwise, <see langword="false"/>.</returns>
        public static bool IsPositive(CurrencyValue value)
        {
            return decimal.IsPositive(value);
        }

        /// <summary>
        /// Compares two values to compute which is greater.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is greater than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        public static CurrencyValue Max(CurrencyValue x, CurrencyValue y)
        {
            return decimal.Max(x, y);
        }

        /// <summary>
        /// Compares two values to compute which is greater.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is greater than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        public static CurrencyValue MaxMagnitude(CurrencyValue x, CurrencyValue y)
        {
            return decimal.MaxMagnitude(x, y);
        }

        /// <summary>
        /// Compares two values to compute which is lesser.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is lesser than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        public static CurrencyValue Min(CurrencyValue x, CurrencyValue y)
        {
            return decimal.Min(x, y);
        }

        /// <summary>
        /// Compares two values to compute which is lesser.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is lesser than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        public static CurrencyValue MinMagnitude(CurrencyValue x, CurrencyValue y)
        {
            return decimal.MinMagnitude(x, y);
        }

        /// <summary>
        /// Multiplies two specified <see cref="CurrencyValue"/> values.
        /// </summary>
        /// <param name="d1">The multiplicand.</param>
        /// <param name="d2">The multiplier.</param>
        /// <returns>The result of multiplying <paramref name="d1"/> and <paramref name="d2"/>.</returns>
        /// <exception cref="OverflowException" />
        public static CurrencyValue Multiply(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Multiply(d1, d2);
        }

        /// <summary>
        /// Returns the result of multiplying the specified <see cref="CurrencyValue"/> value by negative one.
        /// </summary>
        /// <param name="d">The value to negate.</param>
        /// <returns>A decimal number with the value of <paramref name="d"/>, but the opposite sign; alternatively, zero if <paramref name="d"/> is zero.</returns>
        public static CurrencyValue Negate(CurrencyValue d)
        {
            return decimal.Negate(d);
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="CurrencyValue"/> equivalent.
        /// </summary>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <returns>The equivalent to the number contained in <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Parse(string s)
        {
            return decimal.Parse(s);
        }

        /// <summary>
        /// Parses a span of characters into a value.
        /// </summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>The result of parsing <paramref name="s"/>.</returns>
        public static CurrencyValue Parse(ReadOnlySpan<char> s, IFormatProvider provider)
        {
            return decimal.Parse(s, provider);
        }

        /// <summary>
        /// Converts the string representation of a number in a specified style to its <see cref="CurrencyValue"/> equivalent.
        /// </summary>
        /// <param name="s">The string representation.</param>
        /// <param name="style">A bitwise combination of <see cref="NumberStyles"/> values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="NumberStyles.Number"/>.</param>
        /// <returns>The <see cref="CurrencyValue"/> number equivalent to the number contained in <paramref name="s"/> as specified by <paramref name="style"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Parse(string s, NumberStyles style)
        {
            return decimal.Parse(s, style);
        }

        /// <summary>
        /// Parses a string representation of a number to its <see cref="CurrencyValue"/> equivalent using the specified culture-specific format information.
        /// </summary>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>The result of parsing <paramref name="s"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Parse(string s, IFormatProvider provider)
        {
            return decimal.Parse(s, provider);
        }

        /// <summary>
        /// Parses a span of characters into its <see cref="CurrencyValue"/> equivalent using the specified culture-specific format information.
        /// </summary>
        /// <param name="s">The span containing the characters representing the number to convert.</param>
        /// <param name="style">A bitwise combination of <see cref="NumberStyles"/> values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="NumberStyles.Number"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>The <see cref="CurrencyValue"/> number equivalent to the number contained in <paramref name="s"/> as specified by <paramref name="style"/> and <paramref name="provider"/>.</returns>
        public static CurrencyValue Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Number, IFormatProvider provider = default)
        {
            return decimal.Parse(s, style, provider);
        }

        /// <summary>
        /// Parses a string representation of a number to its <see cref="CurrencyValue"/> equivalent using the specified culture-specific format information.
        /// </summary>
        /// <param name="s">The string representing the number to convert.</param>
        /// <param name="style">A bitwise combination of <see cref="NumberStyles"/> values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="NumberStyles.Number"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>The <see cref="CurrencyValue"/> number equivalent to the number contained in <paramref name="s"/> as specified by <paramref name="style"/> and <paramref name="provider"/>.</returns>
        public static CurrencyValue Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            return decimal.Parse(s, style, provider);
        }

        /// <summary>
        /// Computes the remainder after dividing two <see cref="CurrencyValue"/> values.
        /// </summary>
        /// <param name="d1">The dividend.</param>
        /// <param name="d2">The divisor.</param>
        /// <returns>The remainder after dividing <paramref name="d1"/> by <paramref name="d2"/>.</returns>
        /// <exception cref="DivideByZeroException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Remainder(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Remainder(d1, d2);
        }

        /// <summary>
        /// Rounds a <see cref="CurrencyValue"/> value to the specified precision using the specified rounding strategy.
        /// </summary>
        /// <param name="d">A <see cref="CurrencyValue"/> number to round.</param>
        /// <param name="decimals">The number of significant decimal places (precision) in the return value.</param>
        /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
        /// <returns>The number that <paramref name="d"/> is rounded to using the <paramref name="mode"/> rounding strategy and with a precision of <paramref name="decimals"/>. If the precision of <paramref name="d"/> is less than <paramref name="decimals"/>, <paramref name="d"/> is returned unchanged.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Round(CurrencyValue d, int decimals, MidpointRounding mode)
        {
            return decimal.Round(d, decimals, mode);
        }

        /// <summary>
        /// Rounds a <see cref="CurrencyValue"/> value to the specified precision using the specified rounding strategy.
        /// </summary>
        /// <param name="d">A <see cref="CurrencyValue"/> number to round.</param>
        /// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
        /// <returns>The number that <paramref name="d"/> is rounded to using the <paramref name="mode"/> rounding strategy.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="OverflowException" />
        public static CurrencyValue Round(CurrencyValue d, MidpointRounding mode)
        {
            return decimal.Round(d, mode);
        }

        /// <summary>
        /// Rounds a <see cref="CurrencyValue"/> value to the nearest integer.
        /// </summary>
        /// <param name="d">A <see cref="CurrencyValue"/> number to round.</param>
        /// <returns>The integer that is nearest to the <paramref name="d"/> parameter. If <paramref name="d"/> is halfway between two integers, one of which is even and the other odd, the even number is returned.</returns>
        /// <exception cref="OverflowException" />
        public static CurrencyValue Round(CurrencyValue d)
        {
            return decimal.Round(d);
        }

        /// <summary>
        /// Rounds a <see cref="CurrencyValue"/> value to a specified number of decimal places.
        /// </summary>
        /// <param name="d">A <see cref="CurrencyValue"/> number to round.</param>
        /// <param name="decimals">A value from 0 to 28 that specifies the number of decimal places to round to.</param>
        /// <returns>The <see cref="CurrencyValue"/> number equivalent to <paramref name="d"/> rounded to <paramref name="decimals"/> decimal places.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static CurrencyValue Round(CurrencyValue d, int decimals)
        {
            return decimal.Round(d, decimals);
        }

        /// <summary>
        /// Computes the sign of a value.
        /// </summary>
        /// <param name="d">The value whose sign is to be computed.</param>
        /// <returns>A positive value if <paramref name="d"/> is positive, <see cref="INumberBase{TSelf}.Zero"/> if <paramref name="d"/> is zero, and a negative value if <paramref name="d"/> is negative.</returns>
        public static int Sign(CurrencyValue d)
        {
            return decimal.Sign(d);
        }

        /// <summary>
        /// Subtracts one specified <see cref="CurrencyValue"/> value from another.
        /// </summary>
        /// <param name="d1">The minuend.</param>
        /// <param name="d2">The subtrahend.</param>
        /// <returns>The result of subtracting <paramref name="d2"/> from <paramref name="d1"/>.</returns>
        /// <exception cref="OverflowException" />
        public static CurrencyValue Subtract(CurrencyValue d1, CurrencyValue d2)
        {
            return decimal.Subtract(d1, d2);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>An 8-bit unsigned integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static byte ToByte(CurrencyValue value)
        {
            return decimal.ToByte(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A double-precision floating-point number equivalent to <paramref name="value"/>.</returns>
        public static double ToDouble(CurrencyValue value)
        {
            return decimal.ToDouble(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 16-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static short ToInt16(CurrencyValue value)
        {
            return decimal.ToInt16(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static int ToInt32(CurrencyValue value)
        {
            return decimal.ToInt32(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 64-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static long ToInt64(CurrencyValue value)
        {
            return decimal.ToInt64(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent OLE Automation Currency value, which is contained in a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 64-bit signed integer that contains the OLE Automation equivalent to <paramref name="value"/>.</returns>
        public static long ToOACurrency(CurrencyValue value)
        {
            return decimal.ToOACurrency(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>An 8-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static sbyte ToSByte(CurrencyValue value)
        {
            return decimal.ToSByte(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent single-precision floating-point number.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A single-precision floating-point number equivalent to <paramref name="value"/>.</returns>
        public static float ToSingle(CurrencyValue value)
        {
            return decimal.ToInt64(value);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>String representation of the current instance.</returns>
        public override string ToString()
        {
            return ToString(DEFAULT_DECIMAL_PLACES);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="decimals">Number of decimal places to display.</param>
        /// <returns>String representation of the current instance.</returns>
        public string ToString(int decimals)
        {
            if (decimals < 0)
            {
                decimals = 0;
            }

            return _Value.ToString(("C" + (decimals > 0 ? decimals.ToString() : "")).Trim(), _Culture);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">The format to use or <see langword="null"/> to use the default format defined for the type of the <see cref="IFormattable"/> implementation.</param>
        /// <param name="formatProvider">The provider to use to format the value or <see langword="null"/> to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>The value of the current instance in the specified format.</returns>
        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return _Value.ToString(format, formatProvider);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 16-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static ushort ToUInt16(CurrencyValue value)
        {
            return decimal.ToUInt16(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static uint ToUInt32(CurrencyValue value)
        {
            return decimal.ToUInt32(value);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="CurrencyValue"/> to the equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">The <see cref="CurrencyValue"/> number to convert.</param>
        /// <returns>A 64-bit signed integer equivalent to <paramref name="value"/>.</returns>
        /// <exception cref="OverflowException" />
        public static ulong ToUInt64(CurrencyValue value)
        {
            return decimal.ToUInt64(value);
        }

        /// <summary>
        /// Returns the integral digits of the specified <see cref="CurrencyValue"/>; any fractional digits are discarded.
        /// </summary>
        /// <param name="d">The <see cref="CurrencyValue"/> number to truncate.</param>
        /// <returns>The result of <paramref name="d"/> rounded toward zero, to the nearest whole number.</returns>
        public static CurrencyValue Truncate(CurrencyValue d)
        {
            return decimal.Truncate(d);
        }

        /// <summary>
        /// Tries to format the value of the current <see cref="CurrencyValue"/> instance into the provided span of characters.
        /// </summary>
        /// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
        /// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination"/>.</param>
        /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="destination"/>.</param>
        /// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = default)
        {
            return _Value.TryFormat(destination, out charsWritten, format, provider);
        }

        /// <summary>
        /// Tries to convert the value of a specified instance of <see cref="CurrencyValue"/> to its equivalent binary representation.
        /// </summary>
        /// <param name="d">The value to convert.</param>
        /// <param name="destination">The span into which to store the binary representation.</param>
        /// <param name="valuesWritten">When this method returns, the number of integers written to the destination.</param>
        /// <returns><see langword="true"/> if the decimal's binary representation was written to the destination; <see langword="false"/> if the destination wasn't long enough.</returns>
        public static bool TryGetBits(CurrencyValue d, Span<int> destination, out int valuesWritten)
        {
            return decimal.TryGetBits(d, destination, out valuesWritten);
        }

        /// <summary>
        /// Converts the span representation of a number to its <see cref="CurrencyValue"/> equivalent using the specified style and culture-specific format. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A span containing the characters representing the number to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(ReadOnlySpan<char> s, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="CurrencyValue"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string s, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Converts the span representation of a number to its <see cref="CurrencyValue"/> equivalent using the specified style and culture-specific format. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A span containing the characters representing the number to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, provider, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="CurrencyValue"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string s, IFormatProvider provider, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, provider, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Converts the span representation of a number to its <see cref="CurrencyValue"/> equivalent using the specified style and culture-specific format. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A span containing the characters representing the number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the permitted format of <paramref name="s"/>. A typical value to specify is <see cref="NumberStyles.Number"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, style, provider, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="CurrencyValue"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the permitted format of <paramref name="s"/>. A typical value to specify is <see cref="NumberStyles.Number"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="CurrencyValue"/> number that is equivalent to the numeric value contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out CurrencyValue result)
        {
            decimal val;
            bool parsed = decimal.TryParse(s, style, provider, out val);

            result = default(CurrencyValue);

            if (parsed)
            {
                result = val;
            }

            return parsed;
        }

        /// <summary>
        /// Compares two values to compute which is greater and returning the other value if an input is not a number (NaN).
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is greater than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        static CurrencyValue INumber<CurrencyValue>.MaxNumber(CurrencyValue x, CurrencyValue y)
        {
            return CurrencyValue.Max(x, y);
        }

        /// <summary>
        /// Compares two values to compute which is lesser.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is lesser than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        static CurrencyValue INumber<CurrencyValue>.MinNumber(CurrencyValue x, CurrencyValue y)
        {
            return CurrencyValue.Min(x, y);
        }

        /// <summary>
        /// Determines if a value represents a complex number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is a complex number; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsComplexNumber(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is finite.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is a finite number; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsFinite(CurrencyValue value)
        {
            return true;
        }

        /// <summary>
        /// Determines if a value represents a pure imaginary number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is an imaginary number; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsImaginaryNumber(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is infinite.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is infinite; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsInfinity(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is not a number (NaN).
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is not a number; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsNaN(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is negatively infinite.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is negatively infinite; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsNegativeInfinity(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is normal.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is normal; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsNormal(CurrencyValue value)
        {
            return true;
        }

        /// <summary>
        /// Determines if a value is positively infinite.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is positively infinite; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsPositiveInfinity(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is real number.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is a real number; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsRealNumber(CurrencyValue value)
        {
            return true;
        }

        /// <summary>
        /// Determines if a value is subnormal.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is subnormal; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsSubnormal(CurrencyValue value)
        {
            return false;
        }

        /// <summary>
        /// Determines if a value is zero.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is a zero; otherwise, <see langword="false"/>.</returns>
        static bool INumberBase<CurrencyValue>.IsZero(CurrencyValue value)
        {
            return CurrencyValue.Zero.Equals(value);
        }

        /// <summary>
        /// Compares two values to compute which is greater.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is greater than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        static CurrencyValue INumberBase<CurrencyValue>.MaxMagnitudeNumber(CurrencyValue x, CurrencyValue y)
        {
            return MaxMagnitude(x, y);
        }

        /// <summary>
        /// Compares two values to compute which is lesser.
        /// </summary>
        /// <param name="x">The value to compare with <paramref name="y"/>.</param>
        /// <param name="y">The value to compare with <paramref name="x"/>.</param>
        /// <returns><paramref name="x"/> if it is lesser than <paramref name="y"/>; otherwise, <paramref name="y"/>.</returns>
        static CurrencyValue INumberBase<CurrencyValue>.MinMagnitudeNumber(CurrencyValue x, CurrencyValue y)
        {
            return MinMagnitude(x, y);
        }

        /// <summary>
        /// Gets the number of bytes that will be written as part of <see cref="IFloatingPoint{TSelf}.TryWriteExponentLittleEndian(Span{byte}, out int)"/>.
        /// </summary>
        /// <returns>The number of bytes that will be written as part of <see cref="IFloatingPoint{TSelf}.TryWriteExponentLittleEndian(Span{byte}, out int)"/>.</returns>
        int IFloatingPoint<CurrencyValue>.GetExponentByteCount()
        {
            return ((IFloatingPoint<decimal>)(_Value)).GetExponentByteCount();
        }

        /// <summary>
        /// Gets the length, in bits, of the shortest two's complement representation of the current exponent.The length, in bits, of the shortest two's complement representation of the current exponent.
        /// </summary>
        /// <returns>The length, in bits, of the shortest two's complement representation of the current exponent.</returns>
        int IFloatingPoint<CurrencyValue>.GetExponentShortestBitLength()
        {
            return ((IFloatingPoint<decimal>)(_Value)).GetExponentShortestBitLength();
        }

        /// <summary>
        /// Gets the length, in bits, of the current significand.
        /// </summary>
        /// <returns>The length, in bits, of the current significand.</returns>
        int IFloatingPoint<CurrencyValue>.GetSignificandBitLength()
        {
            return ((IFloatingPoint<decimal>)(_Value)).GetSignificandBitLength();
        }

        /// <summary>
        /// Gets the number of bytes that will be written as part of <see cref="IFloatingPoint{TSelf}.TryWriteSignificandLittleEndian(Span{byte}, out int)"/>.
        /// </summary>
        /// <returns>The number of bytes that will be written as part of <see cref="IFloatingPoint{TSelf}.TryWriteSignificandLittleEndian(Span{byte}, out int)"/>.</returns>
        int IFloatingPoint<CurrencyValue>.GetSignificandByteCount()
        {
            return ((IFloatingPoint<decimal>)(_Value)).GetSignificandByteCount();
        }

        /// <summary>
        /// Tries to write the current exponent, in big-endian format, to a given span.
        /// </summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <param name="bytesWritten">When this method returns, contains the number of bytes written to <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the exponent was successfully written to <paramref name="destination"/>; otherwise, <see langword="false"/>.</returns>
        bool IFloatingPoint<CurrencyValue>.TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten)
        {
            return ((IFloatingPoint<decimal>)(_Value)).TryWriteExponentBigEndian(destination, out bytesWritten);
        }

        /// <summary>
        /// Tries to write the current exponent, in little-endian format, to a given span.
        /// </summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <param name="bytesWritten">When this method returns, contains the number of bytes written to <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the exponent was successfully written to <paramref name="destination"/>; otherwise, <see langword="false"/>.</returns>
        bool IFloatingPoint<CurrencyValue>.TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten)
        {
            return ((IFloatingPoint<decimal>)(_Value)).TryWriteExponentLittleEndian(destination, out bytesWritten);
        }

        /// <summary>
        /// Tries to write the current significand, in big-endian format, to a given span.
        /// </summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <param name="bytesWritten">When this method returns, contains the number of bytes written to <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the significand was successfully written to <paramref name="destination"/>; otherwise, <see langword="false"/>.</returns>
        bool IFloatingPoint<CurrencyValue>.TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten)
        {
            return ((IFloatingPoint<decimal>)(_Value)).TryWriteSignificandBigEndian(destination, out bytesWritten);
        }

        /// <summary>
        /// Tries to write the current significand, in little-endian format, to a given span.
        /// </summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <param name="bytesWritten">When this method returns, contains the number of bytes written to <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the significand was successfully written to <paramref name="destination"/>; otherwise, <see langword="false"/>.</returns>
        bool IFloatingPoint<CurrencyValue>.TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten)
        {
            return ((IFloatingPoint<decimal>)(_Value)).TryWriteSignificandLittleEndian(destination, out bytesWritten);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToBoolean(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns><see langword="true"/> if the value of the current instance is non-zero; otherwise, <see langword="false"/>.</returns>
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToBoolean(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToByte(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="Byte"/>.</returns>
        /// <exception cref="OverflowException" />
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToByte(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToChar(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>None. This conversion is not supported.</returns>
        /// <exception cref="InvalidCastException" />
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToChar(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToBoolean(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>None. This conversion is not supported.</returns>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToDateTime(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToDecimal(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, unchanged.</returns>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToDecimal(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToDouble(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="Double"/>.</returns>
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToDouble(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt16(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="Int16"/>.</returns>
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToInt16(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt32(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="Int32"/>.</returns>
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToInt32(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt64(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="Int64"/>.</returns>
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToInt64(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToSByte(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="SByte"/>.</returns>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToSByte(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToSingle(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="Single"/>.</returns>
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToSingle(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToType(Type, IFormatProvider)"/>.
        /// </summary>
        /// <param name="type">The type to which to convert the value of this <see cref="CurrencyValue"/> instance.</param>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <paramref name="type"/>.</returns>
        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToType(type, provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt16(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="UInt16"/>.</returns>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToUInt16(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt32(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="UInt32"/>.</returns>
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToUInt32(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt64(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="UInt64"/>.</returns>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)(_Value)).ToUInt64(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToString(IFormatProvider?)"/>.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to a <see cref="String"/>.</returns>
        string IConvertible.ToString(IFormatProvider provider)
        {
            return _Value.ToString(provider);
        }

        /// <summary>
        /// Runs when the deserialization of an object has been completed.
        /// </summary>
        /// <param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented.</param>
        /// <exception cref="SerializationException" />
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            ((IDeserializationCallback)(_Value)).OnDeserialization(sender);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination for this serialization.</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)(_Value)).GetObjectData(info, context);
        }

        static bool INumberBase<CurrencyValue>.TryConvertFromChecked<TOther>(TOther value, out CurrencyValue result)
        {
            bool success = true;

            result = default(CurrencyValue);

            try
            {
                success = CurrencyValue.TryParse(value?.ToString(), out result);
            }
            catch
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Tries to convert a value to an instance of the the current type, saturating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TOther"/>.</param>
        /// <param name="result">When this method returns, contains an instance of <see cref="CurrencyValue"/> converted from <paramref name="value"/>.</param>
        /// <returns><see langword="false"/> if <typeparamref name="TOther"/> is not supported; otherwise, <see langword="true"/>.</returns>
        static bool INumberBase<CurrencyValue>.TryConvertFromSaturating<TOther>(TOther value, out CurrencyValue result)
        {
            bool success = true;

            result = default(CurrencyValue);

            try
            {
                result = CreateSaturating<TOther>(value);
            }
            catch
            {
                success = false;
            }            

            return success;
        }

        /// <summary>
        /// Tries to convert a value to an instance of the the current type, truncating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TOther"/>.</param>
        /// <param name="result">When this method returns, contains an instance of <see cref="CurrencyValue"/> converted from <paramref name="value"/>.</param>
        /// <returns><see langword="false"/> if <typeparamref name="TOther"/> is not supported; otherwise, <see langword="true"/>.</returns>
        static bool INumberBase<CurrencyValue>.TryConvertFromTruncating<TOther>(TOther value, out CurrencyValue result)
        {
            bool success = true;

            result = default(CurrencyValue);

            try
            {
                result = CreateTruncating<TOther>(value);
            }
            catch
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TOther"/>.</param>
        /// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther"/> converted from <paramref name="value"/>.</param>
        /// <returns><see langword="false"/> if <typeparamref name="TOther"/> is not supported; otherwise, <see langword="true"/>.</returns>
        /// <exception cref="OverflowException" />
        static bool INumberBase<CurrencyValue>.TryConvertToChecked<TOther>(CurrencyValue value, out TOther result)
        {
            bool success = true;

            result = default(TOther);

            try
            {
                result = (TOther)(Convert.ChangeType(value, typeof(TOther)));
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Tries to convert an instance of the the current type to another type, saturating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TOther"/>.</param>
        /// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther"/> converted from <paramref name="value"/>.</param>
        /// <returns><see langword="false"/> if <typeparamref name="TOther"/> is not supported; otherwise, <see langword="true"/>.</returns>
        static bool INumberBase<CurrencyValue>.TryConvertToSaturating<TOther>(CurrencyValue value, out TOther result)
        {
            result = default(TOther);
            return false;
        }

        /// <summary>
        /// Tries to convert an instance of the the current type to another type, truncating any values that fall outside the representable range of the current type.
        /// </summary>
        /// <typeparam name="TOther">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="TOther"/>.</param>
        /// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther"/> converted from <paramref name="value"/>.</param>
        /// <returns><see langword="false"/> if <typeparamref name="TOther"/> is not supported; otherwise, <see langword="true"/>.</returns>
        static bool INumberBase<CurrencyValue>.TryConvertToTruncating<TOther>(CurrencyValue value, out TOther result)
        {
            result = default(TOther);
            return false;
        }

        public static CurrencyValue operator +(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value + d2._Value;
        }

        public static CurrencyValue operator -(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value - d2._Value;
        }

        public static CurrencyValue operator /(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value / d2._Value;
        }

        public static CurrencyValue operator -(CurrencyValue d)
        {
            return new CurrencyValue(-d._Value, d._Culture);
        }

        public static CurrencyValue operator +(CurrencyValue d)
        {
            return new CurrencyValue(+d._Value, d._Culture);
        }

        public static CurrencyValue operator --(CurrencyValue d)
        {
            return new CurrencyValue(d._Value - 1, d._Culture);
        }

        public static CurrencyValue operator ++(CurrencyValue d)
        {
            return new CurrencyValue(d._Value + 1, d._Culture);
        }

        public static bool operator ==(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value == d2._Value;
        }

        public static bool operator !=(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value != d2._Value;
        }

        public static CurrencyValue operator *(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value * d2._Value;
        }

        public static CurrencyValue operator %(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value % d2._Value;
        }

        public static bool operator >(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value > d2._Value;
        }

        public static bool operator >=(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value >= d2._Value;
        }

        public static bool operator <(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value < d2._Value;
        }

        public static bool operator <=(CurrencyValue d1, CurrencyValue d2)
        {
            return d1._Value <= d2._Value;
        }

        public static implicit operator decimal(CurrencyValue value)
        {
            return value._Value;
        }

        public static implicit operator CurrencyValue(decimal value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(int value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(short value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(long value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(char value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(byte value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(ulong value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(uint value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(ushort value)
        {
            return new CurrencyValue(value);
        }

        public static implicit operator CurrencyValue(sbyte value)
        {
            return new CurrencyValue(value);
        }

        public static explicit operator CurrencyValue(float value)
        {
            return new CurrencyValue(value);
        }

        public static explicit operator CurrencyValue(double value)
        {
            return new CurrencyValue(value);
        }
    }
}

