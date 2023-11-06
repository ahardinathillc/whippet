using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Security;
using Athi.Whippet.ResourceManagement;

namespace Athi.Whippet.Localization
{
	/// <summary>
	/// Used for loading Whippet string resource files. This class cannot be inherited.
	/// </summary>
	public class LocalizedStringResourceLoader : StringResourceLoader
	{
		private const string ERROR_RESOURCE_NOT_FOUND_CULTURE = "Could not find resource {0} for culture {1}.";
		private const string ATTRIB_CULTURE = "culture";

		/// <summary>
		/// Initializes a new instance of the <see cref="LocalizedStringResourceLoader"/> class on the stack.
		/// </summary>
		static LocalizedStringResourceLoader()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="LocalizedStringResourceLoader"/> class with no arguments.
		/// </summary>
		protected LocalizedStringResourceLoader()
			: base()
		{ }

		/// <summary>
		/// Retrieves a <see cref="string"/> resource from the common (shared) Whippet exception resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
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
		public static string GetSharedException(string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null)
		{
			return GetResource(typeof(Exception), resourceName, parameters, culture);
		}

		/// <summary>
		/// Retrieves a <see cref="string"/> resource from the Whippet exception resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
		/// </summary>
		/// <typeparam name="T">Class type that maps to the exception file to load.</typeparam>
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
		public static string GetException<T>(string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null)
		{
			return GetResource(typeof(T).Assembly.GetName().Name + ".Exceptions." + DEFAULT_EXT, resourceName, parameters, culture);
		}

		/// <summary>
		/// Retrieves a <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
		/// </summary>
		/// <param name="classType"><see cref="Type"/> of the class resource file to load the resource from.</param>
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
		public static string GetResource(Type classType, string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null)
		{
			if(classType == null)
			{
				throw new ArgumentNullException(nameof(classType));
			}
			else
			{
				return GetResource(classType.FullName + "." + DEFAULT_EXT, resourceName, parameters, culture);
			}
		}

		/// <summary>
		/// Retrieves a <see cref="string"/> resource from the specified Whippet resource file. Will also apply parameters supplied (if any) via <see cref="String.Format(string, object?[])"/>.
		/// </summary>
		/// <param name="resourceFile">Target resource file to load the resource from.</param>
		/// <param name="resourceName">Name of the resource file to load from <paramref name="resourceFile"/>.</param>
		/// <param name="parameters">Parameters to apply to the resource value (if any).</param>
		/// <param name="culture">Current culture of the user interface or <see langword="null"/> to use a default invariant.</param>
		/// <param name="fallbackToDefaultCulture">If <see langword="true"/>, will default to the default culture if the specified value in <paramref name="culture"/> could not be located. Otherwise, will display an error message.</param>
		/// <param name="throwOnCultureNotFound">If <see langword="true"/>, will throw an <see cref="Exception"/> if the resource for the specified <paramref name="culture"/> coudl not be located.</param>
		/// <returns>Resource string value.</returns>
		/// <exception cref="Exception" />
		/// <exception cref="ArgumentNullException" />
		/// <exception cref="ArgumentException" />
		/// <exception cref="FileNotFoundException" />
		/// <exception cref="DirectoryNotFoundException" />
		/// <exception cref="IOException" />
		/// <exception cref="FormatException" />
		public static string GetResource(string resourceFile, string resourceName, IEnumerable<object> parameters = null, CultureInfo culture = null, bool fallbackToDefaultCulture = false, bool throwOnCultureNotFound = false)
		{
			if(String.IsNullOrWhiteSpace(resourceFile))
			{
				throw new ArgumentNullException(nameof(resourceFile));
			}
			else if(String.IsNullOrWhiteSpace(resourceName))
			{
				throw new ArgumentNullException(nameof(resourceName));
			}
			else
			{
				XmlReader xmlReader = null;

				string value = String.Empty;

				bool cultureIsNotDefault = (culture != null && !culture.Equals(DefaultCulture));
				bool cultureIsNotDefault_ValueFound = false;

				if (culture == null || String.Equals(culture.TwoLetterISOLanguageName, "iv", StringComparison.InvariantCultureIgnoreCase))	// culture is null or invariant, default to Culture value
				{
					culture = Culture;
				}

				if(!String.Equals(Path.GetExtension(resourceFile), DEFAULT_EXT, StringComparison.InvariantCultureIgnoreCase))
				{
					resourceFile = Path.ChangeExtension(resourceFile, DEFAULT_EXT);
				}

				resourceFile = Path.Combine(Path.GetDirectoryName(typeof(LocalizedStringResourceLoader).Assembly.Location), DIRECTORY, resourceFile);

				if (!File.Exists(resourceFile))
				{
					throw new FileNotFoundException(resourceFile);
				}
				else
				{
					try
					{
						xmlReader = XmlReader.Create(new StreamReader(resourceFile));

						while (xmlReader.Read())
						{
							if (xmlReader.HasAttributes
								&& !String.IsNullOrWhiteSpace(xmlReader.GetAttribute(ATTRIB_NAME))
								&& String.Equals(resourceName, xmlReader.GetAttribute(ATTRIB_NAME), StringComparison.InvariantCultureIgnoreCase))
							{
								if (String.Equals(culture.TwoLetterISOLanguageName, xmlReader.GetAttribute(ATTRIB_CULTURE), StringComparison.InvariantCultureIgnoreCase))
								{
									if (parameters != null && parameters.Any())
									{
										value = String.Format(xmlReader.GetAttribute(ATTRIB_VALUE), parameters.ToArray());
										cultureIsNotDefault_ValueFound = true;
									}
									else
									{
										value = xmlReader.GetAttribute(ATTRIB_VALUE);
										cultureIsNotDefault_ValueFound = true;
									}

									break;
								}
								else if ((culture.LCID != DefaultCulture.LCID)
									&& String.Equals(DefaultCulture.TwoLetterISOLanguageName, xmlReader.GetAttribute(ATTRIB_CULTURE), StringComparison.InvariantCultureIgnoreCase))
								{
									if (parameters != null && parameters.Any())
									{
										value = String.Format(xmlReader.GetAttribute(ATTRIB_VALUE), parameters.ToArray());
									}
									else
									{
										value = xmlReader.GetAttribute(ATTRIB_VALUE);
									}
								}
							}
						}

						if(cultureIsNotDefault && !cultureIsNotDefault_ValueFound && !fallbackToDefaultCulture)
						{
							value = String.Format(ERROR_RESOURCE_NOT_FOUND_CULTURE, resourceName, culture.Name);

							if(throwOnCultureNotFound)
							{
								throw new Exception(value);
							}
						}
					}
					finally
					{
						if (xmlReader != null)
						{
							xmlReader.Close();
							xmlReader.Dispose();
							xmlReader = null;
						}
					}
				}

				return value;
			}
		}

		/// <summary>
		/// Reads the specified file from the resource files directory.
		/// </summary>
		/// <param name="resourceFile">Resource file name to load.</param>
		/// <param name="useDefaultResourceDirectory">If <see langword="true"/>, will use the default resource files directory. Otherwise, the full path to the resource file will need to be supplied in <paramref name="resourceFile"/>.</param>
		/// <returns>Text contents read from <paramref name="resourceFile"/>.</returns>
		/// <exception cref="ArgumentException" />
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="PathTooLongException"></exception>
		/// <exception cref="DirectoryNotFoundException"></exception>
		/// <exception cref="IOException"></exception>
		/// <exception cref="UnauthorizedAccessException"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="SecurityException"></exception>
		public static string ReadResourceFile(string resourceFile, bool useDefaultResourceDirectory = true)
		{
			if(String.IsNullOrWhiteSpace(resourceFile))
			{
				throw new ArgumentNullException(nameof(resourceFile));
			}
			else
			{
				if (useDefaultResourceDirectory)
				{
					resourceFile = Path.Combine(Path.GetDirectoryName(typeof(LocalizedStringResourceLoader).Assembly.Location), DIRECTORY, resourceFile);
				}

				return File.ReadAllText(resourceFile);
			}
		}
	}
}
