using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    ///  Represents the version number of an assembly, operating system, or the common language runtime.
    /// </summary>
    public class WhippetVersion : ICloneable, IEqualityComparer<WhippetVersion>, IComparable<WhippetVersion>, IEquatable<WhippetVersion>
    {
        private Version _version;

        /// <summary>
        /// Gets or sets the internal <see cref="System.Version"/> object.
        /// </summary>
        private Version Version
        {
            get
            {
                if (_version == null)
                {
                    _version = new Version();
                }

                return _version;
            }
            set
            {
                _version = value;
            }
        }

        /// <summary>
        /// Gets the value of the minor component of the version number. This property is read-only.
        /// </summary>
        public virtual int Minor 
        { 
            get
            {
                return Version.Minor < 0 ? 0 : Version.Minor;
            }
            protected set
            {
                Version = new Version(Major, value, Build, Revision);
            }
        }

        /// <summary>
        /// Gets the value of the major component of the version number. This property is read-only.
        /// </summary>
        public virtual int Major
        {
            get
            {
                return Version.Major < 0 ? 0 : Version.Major;
            }
            protected set
            {
                Version = new Version(value, Minor, Build, Revision);
            }
        }

        /// <summary>
        /// Gets the value of the build component of the version number. This property is read-only.
        /// </summary>
        public virtual int Build
        {
            get
            {
                return Version.Build < 0 ? 0 : Version.Build;
            }
            protected set
            {
                Version = new Version(Major, Minor, value, Revision);
            }
        }

        /// <summary>
        /// Gets the value of the revision component of the version number. This property is read-only.
        /// </summary>
        public virtual int Revision
        {
            get
            {
                return Version.Revision < 0 ? 0 : Version.Revision;
            }
            protected set
            {
                Version = new Version(Major, Minor, Build, Revision);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetVersion"/> class with no arguments.
        /// </summary>
        public WhippetVersion()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetVersion"/> class with the specified <see see="string"/>.
        /// </summary>
        /// <param name="version">Version string to parse.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public WhippetVersion(string version)
        {
            Version = new Version(version);
        }

        /// <summary>
        /// Initializes a new instnace of the <see cref="WhippetVersion"/> class with the specified major and minor values.
        /// </summary>
        /// <param name="major">Major value.</param>
        /// <param name="minor">Minor value.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetVersion(int major, int minor)
        {
            Version = new Version(major, minor);
        }

        /// <summary>
        /// Initializes a new instnace of the <see cref="WhippetVersion"/> class with the specified major, minor, and build values.
        /// </summary>
        /// <param name="major">Major value.</param>
        /// <param name="minor">Minor value.</param>
        /// <param name="build">Build value.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetVersion(int major, int minor, int build)
        {
            Version = new Version(major, minor, build);
        }

        /// <summary>
        /// Initializes a new instnace of the <see cref="WhippetVersion"/> class with the specified major, minor, build, and revision values.
        /// </summary>
        /// <param name="major">Major value.</param>
        /// <param name="minor">Minor value.</param>
        /// <param name="build">Build value.</param>
        /// <param name="revision">Revision value.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public WhippetVersion(int major, int minor, int build, int revision)
        {
            Version = new Version(major, minor, build, revision);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetVersion"/> class with the specified <see cref="System.Version"/> object.
        /// </summary>
        /// <param name="version"><see cref="System.Version"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetVersion(Version version)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            else
            {
                Version = version;
            }
        }

        /// <summary>
        /// Converts the specified read-only span of characters that represents a version number to an equivalent <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="input">A read-only span of characters that contains a version number to convert.</param>
        /// <returns>An object that is equivalent to the version number specified in the input parameter.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public static WhippetVersion Parse(ReadOnlySpan<char> input)
        {
            return Version.Parse(input);
        }

        /// <summary>
        /// Converts the specified string that represents a version number to an equivalent <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="input">A string that contains a version number to convert.</param>
        /// <returns>An object that is equivalent to the version number specified in the input parameter.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="FormatException" />
        /// <exception cref="OverflowException" />
        public static WhippetVersion Parse(string input)
        {
            return Version.Parse(input);
        }

        /// <summary>
        /// Attempts to convert the specified read-only span of characters that represents a version number to an equivalent <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="input">A read-only span of characters that contains a version number to convert.</param>
        /// <param name="result">An object that is equivalent to the version number specified in the input parameter or <see langword="null"/> if the conversion failed.</param>
        /// <returns><see langword="true"/> if the input parameter was successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(ReadOnlySpan<char> input, out WhippetVersion result)
        {
            Version version = null;
            bool bResult = Version.TryParse(input, out version);

            result = version;

            return bResult;
        }

        /// <summary>
        /// Attempts to convert the specified string that represents a version number to an equivalent <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="input">A string that contains a version number to convert.</param>
        /// <param name="result">An object that is equivalent to the version number specified in the input parameter or <see langword="null"/> if the conversion failed.</param>
        /// <returns><see langword="true"/> if the input parameter was successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string input, out WhippetVersion result)
        {
            Version version = null;
            bool bResult = Version.TryParse(input, out version);

            result = version;

            return bResult;
        }

        /// <summary>
        /// Returns a new <see cref="WhippetVersion"/> object whose value is the same as the current instance.
        /// </summary>
        /// <returns>A new <see cref="WhippetVersion"/> object whose values are a copy of the current instance.</returns>
        public object Clone()
        {
            return Version.Clone();
        }

        /// <summary>
        /// Compares the current <see cref="WhippetVersion"/> object to a specified object and returns an indication of their relative values.
        /// </summary>
        /// <param name="version">An object to compare or <see langword="null"/>.</param>
        /// <returns>A signed integer that indicates the relative values of the two objects.</returns>
        /// <exception cref="ArgumentException" />
        public int CompareTo(object version)
        {
            return Version.CompareTo(version);
        }

        /// <summary>
        /// Compares the current <see cref="WhippetVersion"/> object to a specified object and returns an indication of their relative values.
        /// </summary>
        /// <param name="version">An object to compare or <see langword="null"/>.</param>
        /// <returns>A signed integer that indicates the relative values of the two objects.</returns>
        /// <exception cref="ArgumentException" />
        public int CompareTo(WhippetVersion version)
        {
            return Version.CompareTo(version);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetVersion);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetVersion obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = Version.Equals(obj.Version);
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetVersion a, WhippetVersion b)
        {
            return (a == null && b == null) || (a != null && b == null) || (a == null && b != null) || (a != null && b != null && a.Equals(b));
        }

        /// <summary>
        /// Returns a hash code for the current <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Version.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="version"><see cref="WhippetVersion"/> object.</param>
        /// <returns>A 32-bit signed integer hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetHashCode(WhippetVersion version)
        {
            if(version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            else
            {
                return version.GetHashCode();
            }
        }

        /// <summary>
        /// Converts the value of the current <see cref="WhippetVersion"/> object to its equivalent <see cref="String"/> representation.
        /// </summary>
        /// <returns><see cref="String"/> representation of the current object.</returns>
        public override string ToString()
        {
            return Version.ToString();
        }

        /// <summary>
        /// Converts the value of the current <see cref="WhippetVersion"/> object to its equivalent <see cref="String"/> representation.
        /// </summary>
        /// <param name="fieldCount">The number of components to return.</param>
        /// <returns><see cref="String"/> representation of the current object.</returns>
        /// <exception cref="ArgumentException" />
        public string ToString(int fieldCount)
        {
            return Version.ToString(fieldCount);
        }

        /// <summary>
        /// Tries to format this version instance into a span of characters.
        /// </summary>
        /// <param name="destination">When this method returns, the formatted version in the span of characters.</param>
        /// <param name="fieldCount">The number of components to return.</param>
        /// <param name="charsWritten">When this method returns, the number of characters that were written in destination.</param>
        /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
        public bool TryFormat(Span<char> destination, int fieldCount, out int charsWritten)
        {
            return Version.TryFormat(destination, fieldCount, out charsWritten);
        }

        /// <summary>
        /// Tries to format this version instance into a span of characters.
        /// </summary>
        /// <param name="destination">When this method returns, the formatted version in the span of characters.</param>
        /// <param name="charsWritten">When this method returns, the number of characters that were written in destination.</param>
        /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
        public bool TryFormat(Span<char> destination, out int charsWritten)
        {
            return Version.TryFormat(destination, out charsWritten);
        }

        /// <summary>
        /// Determines whether two <see cref="WhippetVersion"/> objects are equal.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) == ((Version)(v2));
        }

        /// <summary>
        /// Determines whether two <see cref="WhippetVersion"/> objects are not equal.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the objects are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) != ((Version)(v2));
        }

        /// <summary>
        /// Determines whether the first <see cref="WhippetVersion"/> object is less than the second one.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the first object is less than the second; otherwise, <see langword="false"/>.</returns>
        public static bool operator <(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) < ((Version)(v2));
        }

        /// <summary>
        /// Determines whether the first <see cref="WhippetVersion"/> object is greater than the second one.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the first object is greater than the second; otherwise, <see langword="false"/>.</returns>
        public static bool operator >(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) > ((Version)(v2));
        }

        /// <summary>
        /// Determines whether the first <see cref="WhippetVersion"/> object is less than or equal to the second one.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the first object is less than or equal to the second; otherwise, <see langword="false"/>.</returns>
        public static bool operator <=(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) <= ((Version)(v2));
        }

        /// <summary>
        /// Determines whether the first <see cref="WhippetVersion"/> object is greater than or equal to the second one.
        /// </summary>
        /// <param name="v1">The first <see cref="WhippetVersion"/> object.</param>
        /// <param name="v2">The second <see cref="WhippetVersion"/> object.</param>
        /// <returns><see langword="true"/> if the first object is greater than or equal to the second; otherwise, <see langword="false"/>.</returns>
        public static bool operator >=(WhippetVersion v1, WhippetVersion v2)
        {
            return ((Version)(v1)) >= ((Version)(v2));
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetVersion"/> object to a <see cref="System.Version"/> object.
        /// </summary>
        /// <param name="version"><see cref="WhippetVersion"/> object.</param>
        public static implicit operator Version(WhippetVersion version)
        {
            return version?.Version;
        }

        /// <summary>
        /// Converts the specified <see cref="System.Version"/> object to a <see cref="WhippetVersion"/> object.
        /// </summary>
        /// <param name="version"><see cref="System.Version"/> object.</param>
        public static implicit operator WhippetVersion(Version version)
        {
            return (version == null) ? null : new WhippetVersion(version);
        }
    }
}
