using System;
using System.Data;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Allows for <see cref="IWhippetEntity"/> objects to be constructed using external data from a non-mapped datasource, such as an external server, file, or stream, using a <see langword="dynamic"/> object.
    /// </summary>
    public interface IWhippetEntityDynamicImportMapper
    {
        /// <summary>
        /// Imports the specified <see langword="dynamic"/> object containing information needed to populate the <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="dynObj"><see langword="dynamic"/> object containing the data to import.</param>
        /// <exception cref="ArgumentNullException" />
        void ImportObject(dynamic dynObj);
    }
}