using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models
{
    /// <summary>
    /// Represents a lightweight view model for CouchDB document values, such as revision numbers. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetCouchDocumentEntryValueModel
    {
        /// <summary>
        /// Gets or sets the document revision.
        /// </summary>
        [JsonProperty("rev")]
        public string Revision
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentEntryValueModel"/> class with no arguments.
        /// </summary>
        public WhippetCouchDocumentEntryValueModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentEntryValueModel"/> class with the specified revision.
        /// </summary>
        /// <param name="revision">Revision to initialize with.</param>
        public WhippetCouchDocumentEntryValueModel(string revision)
            : this()
        {
            Revision = revision;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace((Revision)) ? base.ToString() : Revision;
        }
    }
}
