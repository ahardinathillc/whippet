using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Athi.Whippet.Extensions.IO
{
    /// <summary>
    /// Provides extension methods to <see cref="FileInfo"/> objects. This class cannot be inherited.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Reads a comma-delimited file and returns its contents in a <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <param name="fileInfo"><see cref="FileInfo"/> object that contains the CSV file to read.</param>
        /// <param name="options">Options to apply to the split operation.</param>
        /// <param name="defaultDelimiter">Default delimiter to separate the entries.</param>
        /// <param name="sanitizeFunction">Optional <see cref="Func{T, TResult}"/> that sanitizes each line of the output.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the file contents.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static IReadOnlyList<string[]> ReadCsvFile(this FileInfo fileInfo, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries, string defaultDelimiter = ",", Func<string, string> sanitizeFunction = null)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }
            else
            {
                return ReadCsvFile(fileInfo, fileInfo.FullName, options, defaultDelimiter, sanitizeFunction);
            }
        }

        /// <summary>
        /// Reads a comma-delimited file and returns its contents in a <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <param name="fileInfo"><see cref="FileInfo"/> object.</param>
        /// <param name="fileName">Fully qualified file name.</param>
        /// <param name="options">Options to apply to the split operation.</param>
        /// <param name="defaultDelimiter">Default delimiter to separate the entries.</param>
        /// <param name="sanitizeFunction">Optional <see cref="Func{T, TResult}"/> that sanitizes each line of the output.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of the file contents.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static IReadOnlyList<string[]> ReadCsvFile(this FileInfo fileInfo, string fileName, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries, string defaultDelimiter = ",", Func<string, string> sanitizeFunction = null)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            else if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(null, fileName);
            }
            else
            {
                List<string[]> contents = null;
                string[] rawContents = File.ReadAllLines(fileName);

                if (rawContents != null && rawContents.Any())
                {
                    contents = new List<string[]>(rawContents.Length);

                    for (int i = 0; i < rawContents.Length; i++)
                    {
                        if (sanitizeFunction != null)
                        {
                            rawContents[i] = sanitizeFunction(rawContents[i]);
                        }

                        contents.Add(rawContents[i].Split(defaultDelimiter, options));
                    }
                }

                return contents;
            }
        }
    }
}

