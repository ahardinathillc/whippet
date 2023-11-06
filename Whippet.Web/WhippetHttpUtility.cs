using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Athi.Whippet.Web
{
    /// <summary>
    /// Provides HTTP utility methods for use in web applications. This class cannot be inherited.
    /// </summary>
    public static class WhippetHttpUtility
    {
		/// <summary>
        /// Creates a query string based on the given name and value.
        /// </summary>
        /// <param name="name">Name of the query string parameter.</param>
        /// <param name="value">Value to assign to the query string parameter.</param>
        /// <returns>Query string value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
		public static string CreateQueryString(string name, string value)
        {
			if (String.IsNullOrWhiteSpace(name))
            {
				throw new ArgumentNullException(nameof(name));
            }
			else
            {
				return CreateQueryString(new[] { new KeyValuePair<string, string>(name, value) });
            }
        }

		/// <summary>
		/// Creates a query string based on the given name and values.
		/// </summary>
		/// <param name="keyValuePairs"><see cref="IEnumerable{T}"/> collection of <see cref="KeyValuePair{TKey, TValue}"/> objects representing each query string parameter name and their respective values.</param>
		/// <returns>Query string value.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
			if (keyValuePairs == null)
            {
				throw new ArgumentNullException(nameof(keyValuePairs));
            }
			else
            {
				StringBuilder builder = new StringBuilder();

				builder.Append('?');

				if (keyValuePairs.Any())
                {
					foreach(KeyValuePair<string, string> pair in keyValuePairs)
                    {
						builder.Append(pair.Key);
						builder.Append('=');
						builder.Append(pair.Value);
						builder.Append('&');
                    }

					while (builder.ToString().EndsWith('&'))
                    {
						builder.Remove(builder.Length - 1, 1);
                    }
                }
				else
                {
					builder.Clear();
                }

				return builder.ToString();
            }
        }

        #region HttpUtility Methods

        /// <summary>Minimally converts a string to an HTML-encoded string.</summary>
        /// <param name="s">The string to encode.</param>
        /// <returns>An encoded string.</returns>
        public static string HtmlAttributeEncode(string s)
		{
			return HttpUtility.HtmlAttributeEncode(s);
		}

		/// <summary>Minimally converts a string into an HTML-encoded string and sends the encoded string to a <see cref="T:System.IO.TextWriter" /> output stream.</summary>
		/// <param name="s">The string to encode.</param>
		/// <param name="output">A <see cref="T:System.IO.TextWriter" /> output stream.</param>
		public static void HtmlAttributeEncode(string s, TextWriter output)
		{
			HttpUtility.HtmlAttributeEncode(s, output);
		}

		/// <summary>Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.</summary>
		/// <param name="s">The string to decode.</param>
		/// <returns>A decoded string.</returns>
		public static string HtmlDecode(string s)
		{
			return HttpUtility.HtmlDecode(s);
		}

		/// <summary>Converts a string that has been HTML-encoded into a decoded string, and sends the decoded string to a <see cref="T:System.IO.TextWriter" /> output stream.</summary>
		/// <param name="s">The string to decode.</param>
		/// <param name="output">A <see cref="T:System.IO.TextWriter" /> stream of output.</param>
		public static void HtmlDecode(string s, TextWriter output)
		{
			HttpUtility.HtmlDecode(s, output);
		}

		/// <summary>Converts an object's string representation into an HTML-encoded string, and returns the encoded string.</summary>
		/// <param name="value">An object.</param>
		/// <returns>An encoded string.</returns>
		public static string HtmlEncode(object value)
		{
			return HttpUtility.HtmlEncode(value);
		}

		/// <summary>Converts a string to an HTML-encoded string.</summary>
		/// <param name="s">The string to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string HtmlEncode(string s)
		{
			return HttpUtility.HtmlEncode(s);
		}

		/// <summary>Converts a string into an HTML-encoded string, and returns the output as a <see cref="T:System.IO.TextWriter" /> stream of output.</summary>
		/// <param name="s">The string to encode.</param>
		/// <param name="output">A <see cref="T:System.IO.TextWriter" /> output stream.</param>
		public static void HtmlEncode(string s, TextWriter output)
		{
			HttpUtility.HtmlEncode(s, output);
		}

		/// <summary>Encodes a string.</summary>
		/// <param name="value">A string to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string JavaScriptStringEncode(string value)
		{
			return HttpUtility.JavaScriptStringEncode(value);
		}

		/// <summary>Encodes a string.</summary>
		/// <param name="value">A string to encode.</param>
		/// <param name="addDoubleQuotes">A value that indicates whether double quotation marks will be included around the encoded string.</param>
		/// <returns>An encoded string.</returns>
		public static string JavaScriptStringEncode(string value, bool addDoubleQuotes)
		{
			return HttpUtility.JavaScriptStringEncode(value, addDoubleQuotes);
		}

		/// <summary>Parses a query string into a <see cref="T:System.Collections.Specialized.NameValueCollection" /> using <see cref="P:System.Text.Encoding.UTF8" /> encoding.</summary>
		/// <param name="query">The query string to parse.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="query" /> is <see langword="null" />.</exception>
		/// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection" /> of query parameters and values.</returns>
		public static NameValueCollection ParseQueryString(string query)
		{
			return HttpUtility.ParseQueryString(query);
		}

		/// <summary>Parses a query string into a <see cref="T:System.Collections.Specialized.NameValueCollection" /> using the specified <see cref="T:System.Text.Encoding" />.</summary>
		/// <param name="query">The query string to parse.</param>
		/// <param name="encoding">The <see cref="T:System.Text.Encoding" /> to use.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="query" /> is <see langword="null" />.
		///
		/// -or-
		///
		///  <paramref name="encoding" /> is <see langword="null" />.</exception>
		/// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection" /> of query parameters and values.</returns>
		public static NameValueCollection ParseQueryString(string query, Encoding encoding)
		{
			return HttpUtility.ParseQueryString(query, encoding);
		}

		/// <summary>Converts a URL-encoded byte array into a decoded string using the specified encoding object, starting at the specified position in the array, and continuing for the specified number of bytes.</summary>
		/// <param name="bytes">The array of bytes to decode.</param>
		/// <param name="offset">The position in the byte to begin decoding.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> object that specifies the decoding scheme.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />, but <paramref name="count" /> does not equal <see langword="0" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is less than <see langword="0" /> or greater than the length of the <paramref name="bytes" /> array.
		///
		/// -or-
		///
		///  <paramref name="count" /> is less than <see langword="0" />, or <paramref name="count" /> + <paramref name="offset" /> is greater than the length of the <paramref name="bytes" /> array.</exception>
		/// <returns>A decoded string.</returns>
		public static string UrlDecode(byte[] bytes, int offset, int count, Encoding e)
		{
			return HttpUtility.UrlDecode(bytes, offset, count, e);
		}

		/// <summary>Converts a URL-encoded byte array into a decoded string using the specified decoding object.</summary>
		/// <param name="bytes">The array of bytes to decode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> that specifies the decoding scheme.</param>
		/// <returns>A decoded string.</returns>
		public static string UrlDecode(byte[] bytes, Encoding e)
		{
			return HttpUtility.UrlDecode(bytes, e);
		}

		/// <summary>Converts a string that has been encoded for transmission in a URL into a decoded string.</summary>
		/// <param name="str">The string to decode.</param>
		/// <returns>A decoded string.</returns>
		public static string UrlDecode(string str)
		{
			return HttpUtility.UrlDecode(str);
		}

		/// <summary>Converts a URL-encoded string into a decoded string, using the specified encoding object.</summary>
		/// <param name="str">The string to decode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> that specifies the decoding scheme.</param>
		/// <returns>A decoded string.</returns>
		public static string UrlDecode(string str, Encoding e)
		{
			return HttpUtility.UrlDecode(str, e);
		}

		/// <summary>Converts a URL-encoded array of bytes into a decoded array of bytes.</summary>
		/// <param name="bytes">The array of bytes to decode.</param>
		/// <returns>A decoded array of bytes.</returns>
		public static byte[] UrlDecodeToBytes(byte[] bytes)
		{
			return HttpUtility.UrlDecodeToBytes(bytes);
		}

		/// <summary>Converts a URL-encoded array of bytes into a decoded array of bytes, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
		/// <param name="bytes">The array of bytes to decode.</param>
		/// <param name="offset">The position in the byte array at which to begin decoding.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />, but <paramref name="count" /> does not equal <see langword="0" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is less than <see langword="0" /> or greater than the length of the <paramref name="bytes" /> array.
		///
		/// -or-
		///
		///  <paramref name="count" /> is less than <see langword="0" />, or <paramref name="count" /> + <paramref name="offset" /> is greater than the length of the <paramref name="bytes" /> array.</exception>
		/// <returns>A decoded array of bytes.</returns>
		public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			return HttpUtility.UrlDecodeToBytes(bytes, offset, count);
		}

		/// <summary>Converts a URL-encoded string into a decoded array of bytes.</summary>
		/// <param name="str">The string to decode.</param>
		/// <returns>A decoded array of bytes.</returns>
		public static byte[] UrlDecodeToBytes(string str)
		{
			return HttpUtility.UrlDecodeToBytes(str);
		}

		/// <summary>Converts a URL-encoded string into a decoded array of bytes using the specified decoding object.</summary>
		/// <param name="str">The string to decode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> object that specifies the decoding scheme.</param>
		/// <returns>A decoded array of bytes.</returns>
		public static byte[] UrlDecodeToBytes(string str, Encoding e)
		{
			return HttpUtility.UrlDecodeToBytes(str, e);
		}

		/// <summary>Converts a byte array into an encoded URL string.</summary>
		/// <param name="bytes">The array of bytes to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string UrlEncode(byte[] bytes)
		{
			return HttpUtility.UrlEncode(bytes);
		}

		/// <summary>Converts a byte array into a URL-encoded string, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
		/// <param name="bytes">The array of bytes to encode.</param>
		/// <param name="offset">The position in the byte array at which to begin encoding.</param>
		/// <param name="count">The number of bytes to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string UrlEncode(byte[] bytes, int offset, int count)
		{
			return HttpUtility.UrlEncode(bytes, offset, count);
		}

		/// <summary>Encodes a URL string.</summary>
		/// <param name="str">The text to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string UrlEncode(string str)
		{
			return HttpUtility.UrlEncode(str);
		}

		/// <summary>Encodes a URL string using the specified encoding object.</summary>
		/// <param name="str">The text to encode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> object that specifies the encoding scheme.</param>
		/// <returns>An encoded string.</returns>
		public static string UrlEncode(string str, Encoding e)
		{
			return HttpUtility.UrlEncode(str, e);
		}

		/// <summary>Converts an array of bytes into a URL-encoded array of bytes.</summary>
		/// <param name="bytes">The array of bytes to encode.</param>
		/// <returns>An encoded array of bytes.</returns>
		public static byte[] UrlEncodeToBytes(byte[] bytes)
		{
			return HttpUtility.UrlEncodeToBytes(bytes);
		}

		/// <summary>Converts an array of bytes into a URL-encoded array of bytes, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
		/// <param name="bytes">The array of bytes to encode.</param>
		/// <param name="offset">The position in the byte array at which to begin encoding.</param>
		/// <param name="count">The number of bytes to encode.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />, but <paramref name="count" /> does not equal <see langword="0" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is less than <see langword="0" /> or greater than the length of the <paramref name="bytes" /> array.
		///
		/// -or-
		///
		///  <paramref name="count" /> is less than <see langword="0" />, or <paramref name="count" /> + <paramref name="offset" /> is greater than the length of the <paramref name="bytes" /> array.</exception>
		/// <returns>An encoded array of bytes.</returns>
		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			return HttpUtility.UrlEncodeToBytes(bytes, offset, count);
		}

		/// <summary>Converts a string into a URL-encoded array of bytes.</summary>
		/// <param name="str">The string to encode.</param>
		/// <returns>An encoded array of bytes.</returns>
		public static byte[] UrlEncodeToBytes(string str)
		{
			return HttpUtility.UrlEncodeToBytes(str);
		}

		/// <summary>Converts a string into a URL-encoded array of bytes using the specified encoding object.</summary>
		/// <param name="str">The string to encode.</param>
		/// <param name="e">The <see cref="T:System.Text.Encoding" /> that specifies the encoding scheme.</param>
		/// <returns>An encoded array of bytes.</returns>
		public static byte[] UrlEncodeToBytes(string str, Encoding e)
		{
			return HttpUtility.UrlEncodeToBytes(str, e);
		}

		/// <summary>Converts a string into a Unicode string.</summary>
		/// <param name="str">The string to convert.</param>
		/// <returns>A Unicode string in %<paramref name="UnicodeValue" /> notation.</returns>
		public static string UrlEncodeUnicode(string str)
		{
			return HttpUtility.UrlEncodeUnicode(str);
		}

		/// <summary>Converts a Unicode string into an array of bytes.</summary>
		/// <param name="str">The string to convert.</param>
		/// <returns>A byte array.</returns>
		public static byte[] UrlEncodeUnicodeToBytes(string str)
		{
			return HttpUtility.UrlEncodeUnicodeToBytes(str);
		}

		/// <summary>Do not use; intended only for browser compatibility. Use <see cref="M:System.Web.HttpUtility.UrlEncode(System.String)" />.</summary>
		/// <param name="str">The text to encode.</param>
		/// <returns>The encoded text.</returns>
		public static string UrlPathEncode(string str)
		{
			return HttpUtility.UrlPathEncode(str);
		}

        #endregion HttpUtility Methods
    }
}

