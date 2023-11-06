using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;
using System.IO;
using System.Reflection;
using Athi.Whippet.Localization;

namespace Athi.Whippet
{
    /// <summary>
    /// Base class for all Whippet exceptions. This class must be inherited.
    /// </summary>
    public abstract class WhippetException : Exception
    {
        /// <summary>
        /// Represents the resource file for exception messages.
        /// </summary>
        protected const string EXCEPTION_RESOURCE_FILE = "{0}.Exceptions.xml";

        /// <summary>
        /// Gets the culture of the current thread. This property is read-only.
        /// </summary>
        protected static CultureInfo CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentCulture;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetException"/> class with no arguments.
        /// </summary>
        protected WhippetException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetException"/> class with the specified exception message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected WhippetException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception or <see langword="null"/> if no inner exception is specified.</param>
        protected WhippetException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetException"/> class with serialized data.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="SerializationInfo"/> object that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        protected WhippetException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Retrieves a <see cref="string"/> resource from the exceptions resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <param name="culture">Current culture of the user interface or <see langword="null"/> to use a default invariant.</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        protected static string LocalizeString(string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null)
        {
            return LocalizeString(String.Format(EXCEPTION_RESOURCE_FILE, Assembly.GetCallingAssembly().GetName().Name), resourceName, parameters, culture);
        }

        /// <summary>
        /// Retrieves a <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
        /// </summary>
        /// <param name="resourceFile">Target resource file to load the resource from.</param>
        /// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
        /// <param name="parameters">Parameters to apply to the resource value (if any).</param>
        /// <param name="culture">Current culture of the user interface or <see langword="null"/> to use a default invariant.</param>
        /// <returns>Resource string value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="IOException" />
        /// <exception cref="FormatException" />
        protected static string LocalizeString(string resourceFile, string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null)
        {
            return LocalizedStringResourceLoader.GetResource(resourceFile, resourceName, parameters, culture);
        }
    }
}
