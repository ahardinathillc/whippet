using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using System.Buffers;
using System.Text;
using UnitsNet;

namespace Athi.Whippet
{
    /// <summary>
    /// Represents a <see cref="string"/> that can never be <see langword="null"/>. Typically used in data objects that have a <see cref="string"/> as a primary key.
    /// </summary>
    public struct WhippetNonNullableString : IComparable, IEnumerable, IConvertible, IEnumerable<char>, IComparable<WhippetNonNullableString>, IEquatable<WhippetNonNullableString>, ICloneable, IEqualityComparer<WhippetNonNullableString>
    {
        /// <summary>
        /// Represents the empty string. This property is read-only.
        /// </summary>
        public static WhippetNonNullableString Empty
        {
            get
            {
                return new WhippetNonNullableString(String.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the internal <see cref="string"/>.
        /// </summary>
        private string InternalString
        { get; set; }

        /// <summary>
        /// Gets the character at the specified index.
        /// </summary>
        /// <param name="index">Index of the character to retrieve.</param>
        /// <returns>Character located at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        public char this[int index]
        {
            get
            {
                return InternalString[index];
            }
        }

        /// <summary>
        /// Gets the numnber of characters in the current <see cref="WhippetNonNullableString"/> object. This property is read-only.
        /// </summary>
        public int Length
        {
            get
            {
                return InternalString.Length;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNonNullableString"/> structure with no arguments.
        /// </summary>
        static WhippetNonNullableString()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNonNullableString"/> structure with the specified <see cref="string"/>.
        /// </summary>
        /// <param name="value"><see cref="string"/> to initialize with.</param>
        public WhippetNonNullableString(string value)
            : this()
        {
            InternalString = (value == null) ? String.Empty : value;
        }

        /// <summary>
        /// Retrieves the system's reference to the specified <see cref="WhippetNonNullableString"/>.
        /// </summary>
        /// <param name="str"><see cref="WhippetNonNullableString"/> object.</param>
        /// <returns>The system's reference to <paramref name="str"/>, if it is interned; otherwise, a new reference to a string with the value of <paramref name="str"/>.</returns>
        public static WhippetNonNullableString Intern(WhippetNonNullableString str)
        {
            return new WhippetNonNullableString(String.Intern(str.ToString()));
        }

        /// <summary>
        /// Retrieves a reference to a specified <see cref="WhippetNonNullableString"/>.
        /// </summary>
        /// <param name="str">The string to search for in the intern pool.</param>
        /// <returns>A reference to <paramref name="str"/> if it is in the common language runtime intern pool; otherwise, <see langword="null"/>.</returns>
        public static WhippetNonNullableString? IsInterned(WhippetNonNullableString str)
        {
            string internedValue = String.IsInterned(str.ToString());
            return (internedValue == null) ? null : new WhippetNonNullableString(internedValue);
        }

        /// <summary>
        /// Compares two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        public static int Compare(WhippetNonNullableString a, WhippetNonNullableString b)
        {
            return String.Compare(a.ToString(), b.ToString());
        }

        /// <summary>
        /// Compares substrings of two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="indexA">The position of the substring within <paramref name="a"/>.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="indexB">The position of the substring within <paramref name="b"/>.</param>
        /// <param name="length">The maximum length of characters in the substrings to compare.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int Compare(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length)
        {
            return String.Compare(a.ToString(), indexA, b.ToString(), indexB, length);
        }

        /// <summary>
        /// Compares substrings of two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="indexA">The position of the substring within <paramref name="a"/>.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="indexB">The position of the substring within <paramref name="b"/>.</param>
        /// <param name="length">The maximum length of characters in the substrings to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int Compare(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length, bool ignoreCase)
        {
            return String.Compare(a.ToString(), indexA, b.ToString(), indexB, length, ignoreCase);
        }

        /// <summary>
        /// Compares substrings of two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="indexA">The position of the substring within <paramref name="a"/>.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="indexB">The position of the substring within <paramref name="b"/>.</param>
        /// <param name="length">The maximum length of characters in the substrings to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <param name="culture">An object that supplies culture-specific comparison information. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int Compare(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length, bool ignoreCase, CultureInfo culture)
        {
            return String.Compare(a.ToString(), indexA, b.ToString(), indexB, length, ignoreCase, culture);
        }

        /// <summary>
        /// Compares substrings of two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="indexA">The position of the substring within <paramref name="a"/>.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="indexB">The position of the substring within <paramref name="b"/>.</param>
        /// <param name="length">The maximum length of characters in the substrings to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <param name="culture">An object that supplies culture-specific comparison information. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <param name="options">Options to use when performing the comparison (such as ignoring case or symbols).</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int Compare(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length, bool ignoreCase, CultureInfo culture, CompareOptions options)
        {
            return String.Compare(a.ToString(), indexA, b.ToString(), indexB, length, culture, options);
        }

        /// <summary>
        /// Compares substrings of two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="indexA">The position of the substring within <paramref name="a"/>.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="indexB">The position of the substring within <paramref name="b"/>.</param>
        /// <param name="length">The maximum length of characters in the substrings to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int Compare(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length, StringComparison comparisonType)
        {
            return String.Compare(a.ToString(), indexA, b.ToString(), indexB, length, comparisonType);
        }

        /// <summary>
        /// Compares two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentException" />
        public static int Compare(WhippetNonNullableString a, WhippetNonNullableString b, StringComparison comparisonType)
        {
            return String.Compare(a.ToString(), b.ToString(), comparisonType);
        }

        /// <summary>
        /// Compares two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        public static int Compare(WhippetNonNullableString a, WhippetNonNullableString b, bool ignoreCase)
        {
            return String.Compare(a.ToString(), b.ToString(), ignoreCase);
        }

        /// <summary>
        /// Compares two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <param name="culture">An object that supplies culture-specific comparison information. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        public static int Compare(WhippetNonNullableString a, WhippetNonNullableString b, bool ignoreCase, CultureInfo culture)
        {
            return String.Compare(a.ToString(), b.ToString(), ignoreCase, culture);
        }

        /// <summary>
        /// Compares two specified <see cref="WhippetNonNullableString"/> objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="culture">An object that supplies culture-specific comparison information. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <param name="ignoreCase">Options to use when performing the comparison (such as ignoring case or symbols).</param>
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentException" />
        public static int Compare(WhippetNonNullableString a, WhippetNonNullableString b, bool ignoreCase, CultureInfo culture, CompareOptions options)
        {
            return String.Compare(a.ToString(), b.ToString(), culture, options);
        }

        /// <summary>
        /// Compares two <see cref="WhippetNonNullableString"/> objects by evaluating the numeric values of the corresponding <see cref="char"/> objects in each string.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <returns>An integer that indicates the lexical relationship between the two comperands.</returns>
        public static int CompareOrdinal(WhippetNonNullableString a, WhippetNonNullableString b)
        {
            return String.CompareOrdinal(a.ToString(), b.ToString());
        }

        /// <summary>
        /// Compares substrings of two <see cref="WhippetNonNullableString"/> objects by evaluating the numeric values of the corresponding <see cref="char"/> objects in each substring.
        /// </summary>
        /// <param name="a">The first string to use in the comparison.</param>
        /// <param name="indexA">The starting index of the substring in <paramref name="a"/>.</param>
        /// <param name="b">The second string to use in the comparison.</param>
        /// <param name="indexB">The starting index of the substring in <paramref name="b"/>.</param>
        /// <param name="length">The maximum number of characters in the substrings to compare.</param>
        /// <returns>An integer that indicates the lexical relationship between the two comperands.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int CompareOrdinal(WhippetNonNullableString a, int indexA, WhippetNonNullableString b, int indexB, int length)
        {
            return String.CompareOrdinal(a.ToString(), b.ToString());
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="WhippetNonNullableString"/> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string.
        /// </summary>
        /// <param name="str">The string to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="str"/> parameter.</returns>
        public int CompareTo(WhippetNonNullableString str)
        {
            return InternalString.CompareTo(str.ToString());
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="Object"/> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="Object"/>.
        /// </summary>
        /// <param name="value">An object that evaluates to a <see cref="WhippetNonNullableString"/>.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="str"/> parameter.</returns>
        /// <exception cref="ArgumentException" />
        public int CompareTo(object value)
        {
            return InternalString.CompareTo(value);
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the end of this instance; otherwise, <see langword="false"/>.</returns>
        public bool EndsWith(WhippetNonNullableString value)
        {
            return InternalString.EndsWith(value.ToString());
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and <paramref name="value"/> are compared.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the end of this instance; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public bool EndsWith(WhippetNonNullableString value, StringComparison comparisonType)
        {
            return InternalString.EndsWith(value.ToString(), comparisonType);
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string when compared using the specified culture.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <param name="culture">Culture information that determines how this instance and <paramref name="value"/> are compared. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the end of this instance; otherwise, <see langword="false"/>.</returns>
        public bool EndsWith(WhippetNonNullableString value, bool ignoreCase, CultureInfo culture)
        {
            return InternalString.EndsWith(value.ToString(), ignoreCase, culture);
        }

        /// <summary>
        /// Determines whether the start of this string instance matches the specified character.
        /// </summary>
        /// <param name="value">The character to compare to the character at the start of this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the start of this instance; otherwise, <see langword="false"/>.</returns>
        public bool EndsWith(char value)
        {
            return InternalString.EndsWith(value);
        }

        /// <summary>
        /// Determines whether the start of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the start of this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the start of this instance; otherwise, <see langword="false"/>.</returns>
        public bool StartsWith(WhippetNonNullableString value)
        {
            return InternalString.StartsWith(value.ToString());
        }

        /// <summary>
        /// Determines whether the start of this string instance matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the start of this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and <paramref name="value"/> are compared.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the start of this instance; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public bool StartsWith(WhippetNonNullableString value, StringComparison comparisonType)
        {
            return InternalString.StartsWith(value.ToString(), comparisonType);
        }

        /// <summary>
        /// Determines whether the start of this string instance matches the specified string when compared using the specified culture.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the start of this instance.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <param name="culture">Culture information that determines how this instance and <paramref name="value"/> are compared. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the start of this instance; otherwise, <see langword="false"/>.</returns>
        public bool StartsWith(WhippetNonNullableString value, bool ignoreCase, CultureInfo culture)
        {
            return InternalString.StartsWith(value.ToString(), ignoreCase, culture);
        }

        /// <summary>
        /// Determines whether the start of this string instance matches the specified character.
        /// </summary>
        /// <param name="value">The character to compare to the character at the start of this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the start of this instance; otherwise, <see langword="false"/>.</returns>
        public bool StartsWith(char value)
        {
            return InternalString.StartsWith(value);
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a <see cref="WhippetNonNullableString"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The string to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="WhippetNonNullableString"/> and its value is the same as this instance; otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.</returns>
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return InternalString.Equals(obj);
        }

        /// <summary>
        /// Determines whether this instance and another specified <see cref="WhippetNonNullableString"/> object have the same value.
        /// </summary>
        /// <param name="value">The string to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is the same value as this instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetNonNullableString value)
        {
            return InternalString.Equals(value.ToString());
        }

        /// <summary>
        /// Determines whether this instance and another specified <see cref="WhippetNonNullableString"/> object have the same value.
        /// </summary>
        /// <param name="value">The string to compare to this instance.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is the same value as this instance; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetNonNullableString value, StringComparison comparisonType)
        {
            return InternalString.Equals(value.ToString(), comparisonType);
        }

        /// <summary>
        /// Determines whether two specified <see cref="WhippetNonNullableString"/> objects have the same value.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetNonNullableString a, WhippetNonNullableString b)
        {
            return String.Equals(a.ToString(), b.ToString());
        }

        /// <summary>
        /// Determines whether two specified <see cref="WhippetNonNullableString"/> objects have the same value.
        /// </summary>
        /// <param name="a">The first string to compare.</param>
        /// <param name="b">The second string to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public bool Equals(WhippetNonNullableString a, WhippetNonNullableString b, StringComparison comparisonType)
        {
            return String.Equals(a.ToString(), b.ToString(), comparisonType);
        }

        /// <summary>
        /// Gets the hash code for this string.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return InternalString.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="WhippetNonNullableString"/> object.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public int GetHashCode(WhippetNonNullableString obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for this string using the specified rules.
        /// </summary>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public int GetHashCode(StringComparison comparisonType)
        {
            return InternalString.GetHashCode(comparisonType);
        }

        /// <summary>
        /// Returns the hash code for the provided read-only character span.
        /// </summary>
        /// <param name="value">A read-only character span.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public static int GetHashCode(ReadOnlySpan<char> value)
        {
            return String.GetHashCode(value);
        }

        /// <summary>
        /// Returns the hash code for the provided read-only character span using the specified rules.
        /// </summary>
        /// <param name="value">A read-only character span.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public static int GetHashCode(ReadOnlySpan<char> value, StringComparison comparisonType)
        {
            return String.GetHashCode(value, comparisonType);
        }

        /// <summary>
        /// Creates a new string by using the specified provider to control the formatting of the specified interpolated string.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="initialBuffer">The initial buffer that may be used as temporary space as part of the formatting operation. The contents of this buffer may be overwritten.</param>
        /// <param name="handler">The interpolated string, passed by reference.</param>
        /// <returns>The string that results for formatting the interpolated string using the specified format provider.</returns>
        public static WhippetNonNullableString Create(IFormatProvider provider, Span<char> initialBuffer, ref DefaultInterpolatedStringHandler handler)
        {
            return new WhippetNonNullableString(String.Create(provider, initialBuffer, ref handler));
        }

        /// <summary>
        /// Creates a new string by using the specified provider to control the formatting of the specified interpolated string.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="handler">The interpolated string, passed by reference.</param>
        /// <returns>The string that results for formatting the interpolated string using the specified format provider.</returns>
        public static WhippetNonNullableString Create(IFormatProvider provider, ref DefaultInterpolatedStringHandler handler)
        {
            return new WhippetNonNullableString(String.Create(provider, ref handler));
        }

        /// <summary>
        /// Creates a new string with a specific length and initializes it after creation by using the specified callback.
        /// </summary>
        /// <typeparam name="TState">The type of the element to pass to <paramref name="action"/>.</typeparam>
        /// <param name="length">The length of the string to create.</param>
        /// <param name="state">The element to pass to <paramref name="action"/>.</param>
        /// <param name="action">A callback to initialize the string.</param>
        /// <returns>The created string.</returns>
        public static WhippetNonNullableString Create<TState>(int length, TState state, SpanAction<char, TState> action)
        {
            return new WhippetNonNullableString(String.Create<TState>(length, state, action));
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return InternalString.Clone();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public WhippetNonNullableString Clone()
        {
            return new WhippetNonNullableString(Convert.ToString(((ICloneable)(this)).Clone()));
        }

        /// <summary>
        /// Concatenates the string representations of four specified read-only character spans.
        /// </summary>
        /// <param name="str0">The first read-only character span to concatenate.</param>
        /// <param name="str1">The second read-only character span to concatenate.</param>
        /// <param name="str2">The third read-only character span to concatenate.</param>
        /// <param name="str3">The fourth read-only character span to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/>, <paramref name="str1"/>, <paramref name="str2"/>, and <paramref name="str3"/>.</returns>
        public static WhippetNonNullableString Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1, str2, str3));
        }

        /// <summary>
        /// Concatenates the string representations of three specified read-only character spans.
        /// </summary>
        /// <param name="str0">The first read-only character span to concatenate.</param>
        /// <param name="str1">The second read-only character span to concatenate.</param>
        /// <param name="str2">The third read-only character span to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/>, <paramref name="str1"/>, and <paramref name="str2"/>.</returns>
        public static WhippetNonNullableString Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1, str2));
        }

        /// <summary>
        /// Concatenates the string representations of two specified read-only character spans.
        /// </summary>
        /// <param name="str0">The first read-only character span to concatenate.</param>
        /// <param name="str1">The second read-only character span to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/> and <paramref name="str1"/>.</returns>
        public static WhippetNonNullableString Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1));
        }

        /// <summary>
        /// Concatenates the string representations of three specified objects.
        /// </summary>
        /// <param name="str0">The first object to concatenate.</param>
        /// <param name="str1">The second object to concatenate.</param>
        /// <param name="str2">The third object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/>, <paramref name="str1"/>, and <paramref name="str2"/>.</returns>
        public static WhippetNonNullableString Concat(object str0, object str1, object str2)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1, str2));
        }

        /// <summary>
        /// Concatenates the string representations of two specified objects.
        /// </summary>
        /// <param name="str0">The first object to concatenate.</param>
        /// <param name="str1">The second object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/> and <paramref name="str1"/>.</returns>
        public static WhippetNonNullableString Concat(object str0, object str1)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1));
        }

        /// <summary>
        /// Concatenates the string representations of four specified strings.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <param name="str3">The fourth string to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/>, <paramref name="str1"/>, <paramref name="str2"/>, and <paramref name="str3"/>.</returns>
        public static WhippetNonNullableString Concat(string str0, string str1, string str2, string str3)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1, str2, str3));
        }

        /// <summary>
        /// Concatenates the string representations of three specified strings.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/>, <paramref name="str1"/>, and <paramref name="str2"/>.</returns>
        public static WhippetNonNullableString Concat(string str0, string str1, string str2)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1, str2));
        }

        /// <summary>
        /// Concatenates the string representations of two specified strings.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <returns>The concatenated string representations of the values of <paramref name="str0"/> and <paramref name="str1"/>.</returns>
        public static WhippetNonNullableString Concat(string str0, string str1)
        {
            return new WhippetNonNullableString(String.Concat(str0, str1));
        }

        /// <summary>
        /// Concatenates the elements of a specified <see cref="string"/> array.
        /// </summary>
        /// <param name="values">An array of strings instances.</param>
        /// <returns>The concatenated elements of <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Concat(params string[] values)
        {
            return new WhippetNonNullableString(String.Concat(values));
        }

        /// <summary>
        /// Concatenates the elements of a specified <see cref="object"/> array.
        /// </summary>
        /// <param name="values">An object array that contains the elements to concatenate.</param>
        /// <returns>The concatenated elements of <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Concat(params object[] values)
        {
            return new WhippetNonNullableString(String.Concat(values));
        }

        /// <summary>
        /// Concatenates the elements of a specified <see cref="string"/> collection.
        /// </summary>
        /// <param name="values">An <see cref="IEnumerable{T}"/> collection of string instances.</param>
        /// <returns>The concatenated elements of <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Concat(IEnumerable<string> values)
        {
            return new WhippetNonNullableString(String.Concat(values));
        }

        /// <summary>
        /// Concatenates the members of an <see cref="IEnumerable{T}"/> implementation.
        /// </summary>
        /// <typeparam name="T">The type of the members of <paramref name="values"/>.</typeparam>
        /// <param name="values">A collection object that implements the <see cref="IEnumerable{T}"/> interface.</param>
        /// <returns>The concatenated elements of <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Concat<T>(IEnumerable<T> values)
        {
            return new WhippetNonNullableString(String.Concat<T>(values));
        }

        /// <summary>
        /// Returns a value indicating whether a specified character occurs within this string.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
        public bool Contains(char value)
        {
            return InternalString.Contains(value);
        }

        /// <summary>
        /// Returns a value indicating whether a specified character occurs within this string.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
        public bool Contains(char value, StringComparison comparisonType)
        {
            return InternalString.Contains(value, comparisonType);
        }

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public bool Contains(string value)
        {
            return InternalString.Contains(value);
        }

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules to use in the comparison.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public bool Contains(string value, StringComparison comparisonType)
        {
            return InternalString.Contains(value, comparisonType);
        }

        /// <summary>
        /// Copies the contents of this string into the destination span.
        /// </summary>
        /// <param name="destination">The span into which to copy the string's contents.</param>
        /// <exception cref="ArgumentException" />
        public void CopyTo(Span<char> destination)
        {
            InternalString.CopyTo(destination);
        }

        /// <summary>
        /// Copies a specified number of characters from a specified position in this instance to a specified position in an array of Unicode characters.
        /// </summary>
        /// <param name="sourceIndex">The index of the first character in this instance to copy.</param>
        /// <param name="destination">An array of Unicode characters to which characters in this instance are copied.</param>
        /// <param name="destinationIndex">The index in <paramref name="destination"/> at which the copy operation begins.</param>
        /// <param name="count">The number of characters in this instance to copy to <paramref name="destination"/>.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            InternalString.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        /// <summary>
        /// Returns an enumeration of <see cref="Rune"/> from this string.
        /// </summary>
        /// <returns>A string rune enumerator.</returns>
        public StringRuneEnumerator EnumerateRunes()
        {
            return InternalString.EnumerateRunes();
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of corresponding objects in a specified array. An <see cref="IFormatProvider"/> parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of the corresponding objects in <paramref name="args"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(IFormatProvider provider, string format, params object[] args)
        {
            return new WhippetNonNullableString(String.Format(provider, format, args));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of three specified objects. An <see cref="IFormatProvider"/> parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <param name="arg2">The third object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
        {
            return new WhippetNonNullableString(String.Format(provider, format, arg0, arg1, arg2));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of two specified objects. An <see cref="IFormatProvider"/> parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/> and <paramref name="arg1"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(IFormatProvider provider, string format, object arg0, object arg1)
        {
            return new WhippetNonNullableString(String.Format(provider, format, arg0, arg1));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of an object. An <see cref="IFormatProvider"/> parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(IFormatProvider provider, string format, object arg0)
        {
            return new WhippetNonNullableString(String.Format(provider, format, arg0));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of corresponding objects in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of the corresponding objects in <paramref name="args"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(string format, params object[] args)
        {
            return new WhippetNonNullableString(String.Format(format, args));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of three specified objects.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <param name="arg2">The third object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(string format, object arg0, object arg1, object arg2)
        {
            return new WhippetNonNullableString(String.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of two specified objects.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/> and <paramref name="arg1"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(string format, object arg0, object arg1)
        {
            return new WhippetNonNullableString(String.Format(format, arg0, arg1));
        }

        /// <summary>
        /// Replaces the format items in a string with the string representation of an object.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static WhippetNonNullableString Format(string format, object arg0)
        {
            return new WhippetNonNullableString(String.Format(format, arg0));
        }

        /// <summary>
        /// Retrieves an object that can iterate through the individual characters in this string.
        /// </summary>
        /// <returns>An enumerator object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Retrieves an object that can iterate through the individual characters in this string.
        /// </summary>
        /// <returns>An enumerator object.</returns>
        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Retrieves an object that can iterate through the individual characters in this string.
        /// </summary>
        /// <returns>An enumerator object.</returns>
        public CharEnumerator GetEnumerator()
        {
            return InternalString.GetEnumerator();
        }

        /// <summary>
        /// Returns the <see cref="TypeCode"/> for the <see cref="WhippetNonNullableString"/> structure.
        /// </summary>
        /// <returns>The enumerated constant, <see cref="TypeCode.String"/>.</returns>
        public TypeCode GetTypeCode()
        {
            return InternalString.GetTypeCode();
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(string value, int startIndex, int count)
        {
            return InternalString.IndexOf(value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return InternalString.IndexOf(value, startIndex, count, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. Parameters specify the starting search position in the current string and the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return InternalString.IndexOf(value, startIndex, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public int IndexOf(string value, StringComparison comparisonType)
        {
            return InternalString.IndexOf(value, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(char value, int startIndex, int count)
        {
            return InternalString.IndexOf(value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in the current <see cref="WhippetNonNullableString"/> object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentException" />
        public int IndexOf(char value, StringComparison comparisonType)
        {
            return InternalString.IndexOf(value, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(char value, int startIndex)
        {
            return InternalString.IndexOf(value, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int IndexOf(string value, int startIndex)
        {
            return InternalString.IndexOf(value, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        public int IndexOf(string value)
        {
            return InternalString.IndexOf(value);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        public int IndexOf(char value)
        {
            return InternalString.IndexOf(value);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(string value, int startIndex, int count)
        {
            return InternalString.LastIndexOf(value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return InternalString.LastIndexOf(value, startIndex, count, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. Parameters specify the starting search position in the current string and the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return InternalString.LastIndexOf(value, startIndex, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in the current <see cref="WhippetNonNullableString"/> object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOf(string value, StringComparison comparisonType)
        {
            return InternalString.LastIndexOf(value, comparisonType);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(char value, int startIndex, int count)
        {
            return InternalString.LastIndexOf(value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified character in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(char value, int startIndex)
        {
            return InternalString.LastIndexOf(value, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public int LastIndexOf(string value, int startIndex)
        {
            return InternalString.LastIndexOf(value, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOf(string value)
        {
            return InternalString.LastIndexOf(value);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified character in this instance.
        /// </summary>
        /// <param name="value">The character to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that character is found, or, -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOf(char value)
        {
            return InternalString.LastIndexOf(value);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentNullException" />
        public int IndexOfAny(char[] anyOf)
        {
            return InternalString.IndexOfAny(anyOf);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            return InternalString.IndexOfAny(anyOf, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return InternalString.IndexOfAny(anyOf, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOfAny(char[] anyOf)
        {
            return InternalString.LastIndexOfAny(anyOf);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            return InternalString.LastIndexOfAny(anyOf, startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return InternalString.LastIndexOfAny(anyOf, startIndex, count);
        }

        /// <summary>
        /// Returns a new string in which a specified string is inserted at a specified index position in this instance.
        /// </summary>
        /// <param name="startIndex">The zero-based index position of the insertion.</param>
        /// <param name="value">The string to insert.</param>
        /// <returns>A new string that is equivalent to this instance, but with <paramref name="value"/> inserted at position <paramref name="startIndex"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString Insert(int startIndex, string value)
        {
            return new WhippetNonNullableString(InternalString.Insert(startIndex, value));
        }

        /// <summary>
        /// Indicates whether this string is in the specified Unicode normalization form.
        /// </summary>
        /// <param name="normalizationForm">A Unicode normalization form.</param>
        /// <returns><see langword="true"/> if this string is in the normalization form specified by the <paramref name="normalizationForm"/> parameter; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public bool IsNormalized(NormalizationForm normalizationForm)
        {
            return InternalString.IsNormalized(normalizationForm);
        }

        /// <summary>
        /// Indicates whether this string is in Unicode normalization form C.
        /// </summary>
        /// <returns><see langword="true"/> if this string is in normalization form C; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException" />
        public bool IsNormalized()
        {
            return InternalString.IsNormalized();
        }

        /// <summary>
        /// Indicates whether the specified string is <see langword="null"/> or an empty string ("").
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.</returns>
        public static bool IsNullOrEmpty(string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether the specified string is <see langword="null"/> or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter is <see langword="null"/> or consists only of white-space characters; otherwise, <see langword="false"/>.</returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Concatenates the string representations of an array of objects, using the specified separator between each member.
        /// </summary>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of objects whose string representations will be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> character or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(char separator, params object[] values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an array of strings, using the specified separator between each member.
        /// </summary>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of strings to be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> character or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(char separator, params string[] values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an <see cref="IEnumerable{T}"/> collection of objects, using the specified separator between each member.
        /// </summary>
        /// <typeparam name="T">The type of the members of <paramref name="values"/> to be concatenated.</typeparam>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An <see cref="IEnumerable{T}"/> collection of objects to be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> character or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join<T>(char separator, IEnumerable<T> values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an <see cref="IEnumerable{T}"/> collection of objects, using the specified separator between each member.
        /// </summary>
        /// <typeparam name="T">The type of the members of <paramref name="values"/> to be concatenated.</typeparam>
        /// <param name="separator">The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An <see cref="IEnumerable{T}"/> collection of objects to be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> string or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join<T>(string separator, IEnumerable<T> values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an array of strings, using the specified separator between each member, starting with the element in <paramref name="values"/> located at the <paramref name="startIndex"/> position, and concatenating up to <paramref name="count"/> elements.
        /// </summary>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of strings to be concatenated.</param>
        /// <param name="startIndex">The first item in <paramref name="values"/> to concatenate.</param>
        /// <param name="count">The number of elements from <paramref name="values"/> to concatenate, starting with the element in the <paramref name="startIndex"/> position.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> character or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(char separator, string[] values, int startIndex, int count)
        {
            return new WhippetNonNullableString(String.Join(separator, values, startIndex, count));
        }

        /// <summary>
        /// Concatenates an <see cref="IEnumerable{T}"/> collection of strings, using the specified separator between each member.
        /// </summary>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An <see cref="IEnumerable{T}"/> collection of string to be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> character or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(char separator, IEnumerable<string> values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates the string representations of an array of objects, using the specified separator between each member.
        /// </summary>
        /// <param name="separator">The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of objects whose string representations will be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> string or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(string separator, params object[] values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an array of strings, using the specified separator between each member.
        /// </summary>
        /// <param name="separator">The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of strings to be concatenated.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> string or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(string separator, params string[] values)
        {
            return new WhippetNonNullableString(String.Join(separator, values));
        }

        /// <summary>
        /// Concatenates an array of strings, using the specified separator between each member, starting with the element in <paramref name="values"/> located at the <paramref name="startIndex"/> position, and concatenating up to <paramref name="count"/> elements.
        /// </summary>
        /// <param name="separator">The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array of strings to be concatenated.</param>
        /// <param name="startIndex">The first item in <paramref name="values"/> to concatenate.</param>
        /// <param name="count">The number of elements from <paramref name="values"/> to concatenate, starting with the element in the <paramref name="startIndex"/> position.</param>
        /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the <paramref name="separator"/> string or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="values"/> has zero elements.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="OutOfMemoryException" />
        public static WhippetNonNullableString Join(string separator, string[] values, int startIndex, int count)
        {
            return new WhippetNonNullableString(String.Join(separator, values, startIndex, count));
        }

        /// <summary>
        /// Returns a new string whose textual value is the same as this string, but whose binary representation is in the specified Unicode normalization form.
        /// </summary>
        /// <param name="normalizationForm">A Unicode normalization form.</param>
        /// <returns>A new string whose textual value is the same as this string, but whose binary representation is in the normalization form specified by the <paramref name="normalizationForm"/> parameter.</returns>
        /// <exception cref="ArgumentException" />
        public WhippetNonNullableString Normalize(NormalizationForm normalizationForm)
        {
            return new WhippetNonNullableString(InternalString.Normalize(normalizationForm));
        }

        /// <summary>
        /// Returns a new string whose textual value is the same as this string, but whose binary representation is in Unicode normalization form C.
        /// </summary>
        /// <returns>A new, normalized string whose textual value is the same as this string, but whose binary representation is in normalization form C.</returns>
        /// <exception cref="ArgumentException" />
        public WhippetNonNullableString Normalize()
        {
            return new WhippetNonNullableString(InternalString.Normalize());
        }

        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding them with spaces on the left, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <returns>A new string that is equivalent to this instance, but right-aligned and padded on the left with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString PadLeft(int totalWidth)
        {
            return new WhippetNonNullableString(InternalString.PadLeft(totalWidth));
        }

        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>A new string that is equivalent to this instance, but right-aligned and padded on the left with as many <paramref name="paddingChar"/> characters needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString PadLeft(int totalWidth, char paddingChar)
        {
            return new WhippetNonNullableString(InternalString.PadLeft(totalWidth));
        }

        /// <summary>
        /// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString PadRight(int totalWidth)
        {
            return new WhippetNonNullableString(InternalString.PadLeft(totalWidth));
        }

        /// <summary>
        /// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString PadRight(int totalWidth, char paddingChar)
        {
            return new WhippetNonNullableString(InternalString.PadLeft(totalWidth));
        }

        /// <summary>
        /// Returns a new string in which all the characters in the current instance, beginning at a specified position and continuing through the last position, have been deleted.
        /// </summary>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <returns>A new string that is equivalent to this string except for the removed characters.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString Remove(int startIndex)
        {
            return new WhippetNonNullableString(InternalString.Remove(startIndex));
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters in the current instance beginning at a specified position have been deleted.
        /// </summary>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <param name="count">The number of characters to delete.</param>
        /// <returns>A new string that is equivalent to this string except for the removed characters.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString Remove(int startIndex, int count)
        {
            return new WhippetNonNullableString(InternalString.Remove(startIndex, count));
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="oldChar">The Unicode character to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of <paramref name="oldChar"/>.</param>
        /// <returns>A string that is equivalent to this instance except that all instances of <paramref name="oldChar"/> are replaced with <paramref name="newChar"/>. If <paramref name="oldChar"/> is not found in the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString Replace(char oldChar, char newChar)
        {
            return new WhippetNonNullableString(InternalString.Replace(oldChar, newChar));
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <returns>A string that is equivalent to this instance except that all instances of <paramref name="oldValue"/> are replaced with <paramref name="newValue"/>. If <paramref name="oldValue"/> is not found in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetNonNullableString Replace(string oldValue, string newValue)
        {
            return new WhippetNonNullableString(InternalString.Replace(oldValue, newValue));
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string using the provided comparison type.
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how <paramref name="oldValue"/> is searched within this instance.</param>
        /// <returns>A string that is equivalent to this instance except that all instances of <paramref name="oldValue"/> are replaced with <paramref name="newValue"/>. If <paramref name="oldValue"/> is not found in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public WhippetNonNullableString Replace(string oldValue, string newValue, StringComparison comparisonType)
        {
            return new WhippetNonNullableString(InternalString.Replace(oldValue, newValue, comparisonType));
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the provided culture and case sensitivity.
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore casing when comparing; <see langword="false"/> otherwise.</param>
        /// <param name="culture">The culture to use when comparing. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns></returns>
        public WhippetNonNullableString Replace(string oldValue, string newValue, bool ignoreCase, CultureInfo culture)
        {
            return new WhippetNonNullableString(InternalString.Replace(oldValue, newValue, ignoreCase, culture));
        }

        /// <summary>
        /// Replaces all newline sequences in the current string with <see cref="System.Environment.NewLine"/>.
        /// </summary>
        /// <returns>A string whose contents match the current string, but with all newline sequences replaced with <see cref="System.Environment.NewLine"/>.</returns>
        public WhippetNonNullableString ReplaceLineEndings()
        {
            return new WhippetNonNullableString(InternalString.ReplaceLineEndings());
        }

        /// <summary>
        /// Replaces all newline sequences in the current string with <paramref name="replacementText"/>.
        /// </summary>
        /// <param name="replacementText">The text to use as replacement.</param>
        /// <returns>A string whose contents match the current string, but with all newline sequences replaced with <paramref name="replacementText"/>.</returns>
        public WhippetNonNullableString ReplaceLineEndings(string replacementText)
        {
            return new WhippetNonNullableString(InternalString.ReplaceLineEndings(replacementText));
        }

        /// <summary>
        /// Converts the specified <see cref="String"/> array to a <see cref="WhippetNonNullableString"/> array.
        /// </summary>
        /// <param name="array"><see cref="String"/> array.</param>
        /// <returns><see cref="WhippetNonNullableString"/> array.</returns>
        private WhippetNonNullableString[] ConvertArray(string[] array)
        {
            WhippetNonNullableString[] newArray = null;

            if (array != null && array.Length > 0)
            {
                newArray = new WhippetNonNullableString[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = new WhippetNonNullableString(array[i]);
                }
            }

            return newArray;
        }

        /// <summary>
        /// Splits a string into substrings based on specified delimiting characters.
        /// </summary>
        /// <param name="separator">An array of delimiting characters, an empty array that contains no delimiters, or <see langword="null"/>.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in <paramref name="separator"/>.</returns>
        public WhippetNonNullableString[] Split(params char[] separator)
        {
            return ConvertArray(InternalString.Split(separator));
        }

        /// <summary>
        /// Splits a string into substrings based on a specified delimiting character and, optionally, options.
        /// </summary>
        /// <param name="separator">A character that delimits the substrings in this string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        public WhippetNonNullableString[] Split(char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return ConvertArray(InternalString.Split(separator, options));
        }

        /// <summary>
        /// Splits a string into a maximum number of substrings based on specified delimiting characters.
        /// </summary>
        /// <param name="separator">An array of characters that delimit the substrings in this string, an empty array that contains no delimiters, or <see langword="null"/>.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString[] Split(char[] separator, int count)
        {
            return ConvertArray(InternalString.Split(separator, count));
        }

        /// <summary>
        /// Splits a string into substrings based on specified delimiting characters and options.
        /// </summary>
        /// <param name="separator">An array of characters that delimit the substrings in this string, an empty array that contains no delimiters, or <see langword="null"/>.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentException" />
        public WhippetNonNullableString[] Split(char[] separator, StringSplitOptions options)
        {
            return ConvertArray(InternalString.Split(separator, options));
        }

        /// <summary>
        /// Splits a string into substrings that are based on the provided string separator.
        /// </summary>
        /// <param name="separator">A string that delimits the substrings in this string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        public WhippetNonNullableString[] Split(string separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return ConvertArray(InternalString.Split(separator, options));
        }

        /// <summary>
        /// Splits a string into substrings that are based on the provided string separator.
        /// </summary>
        /// <param name="separator">A string that delimits the substrings in this string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentException" />
        public WhippetNonNullableString[] Split(string[] separator, StringSplitOptions options)
        {
            return ConvertArray(InternalString.Split(separator, options));
        }

        /// <summary>
        /// Splits a string into a maximum number of substrings based on a specified delimiting character and, optionally, options. Splits a string into a maximum number of substrings based on the provided character separator, optionally omitting empty substrings from the result.
        /// </summary>
        /// <param name="separator">A character that delimits the substrings in this instance.</param>
        /// <param name="count">The maximum number of elements expected in the array.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array that contains at most <paramref name="count"/> substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        public WhippetNonNullableString[] Split(char separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return ConvertArray(InternalString.Split(separator, count, options));
        }

        /// <summary>
        /// Splits a string into a maximum number of substrings based on specified delimiting characters and, optionally, options.
        /// </summary>
        /// <param name="separator">An array of characters that delimit the substrings in this string, an empty array that contains no delimiters, or <see langword="null"/>.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array that contains at most <paramref name="count"/> substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString[] Split(char[] separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return ConvertArray(InternalString.Split(separator, count, options));
        }

        /// <summary>
        /// Splits a string into a maximum number of substrings based on a specified delimiting string and, optionally, options.
        /// </summary>
        /// <param name="separator">A string that delimits the substrings in this instance.</param>
        /// <param name="count">The maximum number of elements expected in the array.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array that contains at most <paramref name="count"/> substrings from this instance that are delimited by <paramref name="separator"/>.</returns>
        public WhippetNonNullableString[] Split(string separator, int count, StringSplitOptions options = StringSplitOptions.None)
        {
            return ConvertArray(InternalString.Split(separator, count, options));
        }

        /// <summary>
        /// Splits a string into a maximum number of substrings based on specified delimiting strings and, optionally, options.
        /// </summary>
        /// <param name="separator">The strings that delimit the substrings in this string, an empty array that contains no delimiters, or <see langword="null"/>.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specifies whether to trim substrings and include empty substrings.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString[] Split(string[] separator, int count, StringSplitOptions options)
        {
            return ConvertArray(InternalString.Split(separator, count, options));
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>A string that is equivalent to the substring that begins at <paramref name="startIndex"/> in this instance, or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString Substring(int startIndex)
        {
            return new WhippetNonNullableString(InternalString.Substring(startIndex));
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or <see cref="WhippetNonNullableString.Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance and <paramref name="length"/> is zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetNonNullableString Substring(int startIndex, int length)
        {
            return new WhippetNonNullableString(InternalString.Substring(startIndex, length));
        }

        /// <summary>
        /// Copies the characters in this instance to a Unicode character array.
        /// </summary>
        /// <returns>A Unicode character array whose elements are the individual characters of this instance. If this instance is an empty string, the returned array is empty and has a zero length.</returns>
        public char[] ToCharArray()
        {
            return InternalString.ToCharArray();
        }

        /// <summary>
        /// Copies the characters in a specified substring in this instance to a Unicode character array.
        /// </summary>
        /// <param name="startIndex">The starting position of a substring in this instance.</param>
        /// <param name="length">The length of the substring in this instance.</param>
        /// <returns>A Unicode character array whose elements are the <paramref name="length"/> number of characters in this instance starting from character position <paramref name="startIndex"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public char[] ToCharArray(int startIndex, int length)
        {
            return InternalString.ToCharArray(startIndex, length);
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase.
        /// </summary>
        /// <returns>A string in lowercase.</returns>
        public WhippetNonNullableString ToLower()
        {
            return new WhippetNonNullableString(InternalString.ToLower());
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase, using the casing rules of the specified culture.
        /// </summary>
        /// <param name="culture">An object that supplies culture-specific casing rules. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns>The lowercase equivalent of the current string.</returns>
        public WhippetNonNullableString ToLower(CultureInfo culture)
        {
            return new WhippetNonNullableString(InternalString.ToLower(culture));
        }

        /// <summary>
        /// Returns a copy of this <see cref="WhippetNonNullableString"/> object converted to lowercase using the casing rules of the invariant culture.
        /// </summary>
        /// <returns>The lowercase equivalent of the current string.</returns>
        public WhippetNonNullableString ToLowerInvariant()
        {
            return new WhippetNonNullableString(InternalString.ToLowerInvariant());
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <returns>A string in uppercase.</returns>
        public WhippetNonNullableString ToUpper()
        {
            return new WhippetNonNullableString(InternalString.ToUpper());
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase, using the casing rules of the specified culture.
        /// </summary>
        /// <param name="culture">An object that supplies culture-specific casing rules. If <paramref name="culture"/> is <see langword="null"/>, the current culture is used.</param>
        /// <returns>The uppercase equivalent of the current string.</returns>
        public WhippetNonNullableString ToUpper(CultureInfo culture)
        {
            return new WhippetNonNullableString(InternalString.ToUpper(culture));
        }

        /// <summary>
        /// Returns a copy of this <see cref="WhippetNonNullableString"/> object converted to uppercase using the casing rules of the invariant culture.
        /// </summary>
        /// <returns>The uppercase equivalent of the current string.</returns>
        public WhippetNonNullableString ToUpperInvariant()
        {
            return new WhippetNonNullableString(InternalString.ToUpperInvariant());
        }

        /// <summary>
        /// Removes all leading and trailing white-space characters from the current string.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString Trim()
        {
            return new WhippetNonNullableString(InternalString.Trim());
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the start and end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString Trim(params char[] trimChars)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChars));
        }

        /// <summary>
        /// Removes all leading and trailing instances of a character from the current string.
        /// </summary>
        /// <param name="trimChar">A Unicode character to remove.</param>
        /// <returns>The string that remains after all instances of the <paramref name="trimChar"/> character are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString Trim(char trimChar)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChar));
        }

        /// <summary>
        /// Removes all the trailing white-space characters from the current string.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimEnd()
        {
            return new WhippetNonNullableString(InternalString.Trim());
        }

        /// <summary>
        /// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimEnd(params char[] trimChars)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChars));
        }

        /// <summary>
        /// Removes all the trailing occurrences of a character from the current string.
        /// </summary>
        /// <param name="trimChar">A Unicode character to remove.</param>
        /// <returns>The string that remains after all instances of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimEnd(char trimChar)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChar));
        }

        /// <summary>
        /// Removes all the leading white-space characters from the current string.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the start of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimStart()
        {
            return new WhippetNonNullableString(InternalString.Trim());
        }

        /// <summary>
        /// Removes all the leading occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the start of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimStart(params char[] trimChars)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChars));
        }

        /// <summary>
        /// Removes all the leading occurrences of a character from the current string.
        /// </summary>
        /// <param name="trimChar">A Unicode character to remove.</param>
        /// <returns>The string that remains after all instances of the <paramref name="trimChar"/> character are removed from the start of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public WhippetNonNullableString TrimStart(char trimChar)
        {
            return new WhippetNonNullableString(InternalString.Trim(trimChar));
        }

        /// <summary>
        /// Copies the contents of this string into the destination span.
        /// </summary>
        /// <param name="destination">The span into which to copy this string's contents.</param>
        /// <returns><see langword="true"/> if the data was copied; <see langword="false"/> if the destination was too short to fit the contents of the string.</returns>
        public bool TryCopyTo(Span<char> destination)
        {
            return InternalString.TryCopyTo(destination);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return InternalString.ToString();
        }

        /// <summary>
        /// Returns this instance of <see cref="WhippetNonNullableString"/>; no actual conversion is performed.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The current string.</returns>
        public string ToString(IFormatProvider provider)
        {
            return InternalString.ToString(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A Boolean value equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToBoolean(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 8-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToByte(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent Unicode character using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A Unicode character equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToChar(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent <see cref="DateTime"/> using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="DateTime"/> instance equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToDateTime(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent double-precision floating-point number using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="Decimal"/> number equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToDecimal(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A double-precision floating-point number equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToDouble(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 16-bit signed integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToInt16(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 32-bit signed integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToInt32(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 64-bit signed integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToInt64(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 8-bit signed integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToSByte(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent single-precision floating-point number using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>A single-precision floating-point number equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToSingle(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an <see cref="object"/> of the specified <see cref="Type"/> that has an equivalent value, using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="conversionType">The <see cref="Type"/> to which the value of this instance is converted.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An <see cref="object"/> instance of type <paramref name="conversionType"/> whose value is equivalent to the value of this instance.</returns>
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToType(conversionType, provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 16-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToUInt16(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 32-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToUInt32(provider);
        }

        /// <summary>
        /// Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>An 64-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)(InternalString)).ToUInt64(provider);
        }

        public static bool operator == (WhippetNonNullableString a, WhippetNonNullableString b)
        {
            return a.Equals(b);
        }

        public static bool operator != (WhippetNonNullableString a, WhippetNonNullableString b)
        {
            return !a.Equals(b);
        }

        public static implicit operator ReadOnlySpan<char> (WhippetNonNullableString value)
        {
            return (ReadOnlySpan<char>)(value.ToString());
        }

        public static implicit operator string (WhippetNonNullableString value)
        {
            return value.ToString();
        }

        public static implicit operator WhippetNonNullableString (string value)
        {
            return new WhippetNonNullableString(value == null ? String.Empty : value);
        }
    }
}

