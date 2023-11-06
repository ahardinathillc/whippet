using System;
using System.Text;
using Newtonsoft.Json;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models
{
    /// <summary>
    /// Lightweight view model that contains a CouchDB document's ID, document key, and revision. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetCouchDocumentEntryModel
    {
        /// <summary>
        /// Gets or sets the ID of the document. Typically a <see cref="Guid"/>.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }
        
        /// <summary>
        /// Unique key of the document. Typically a <see cref="Guid"/>.
        /// </summary>
        [JsonProperty("key")]
        public string Key
        { get; set; }

        /// <summary>
        /// Gets or sets the document value.
        /// </summary>
        [JsonProperty("value")]
        public WhippetCouchDocumentEntryValueModel Value
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentEntryModel"/> class with no arguments.
        /// </summary>
        public WhippetCouchDocumentEntryModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentEntryModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the document.</param>
        /// <param name="key">Unique key of the document.</param>
        /// <param name="value">Document value.</param>
        public WhippetCouchDocumentEntryModel(string id, string key, WhippetCouchDocumentEntryValueModel value)
            : this()
        {
            ID = id;
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("{ ID: ");
            builder.Append(ID);
            builder.Append(" | Key: ");
            builder.Append(Key);
            builder.Append(" | Value: ");
            builder.Append(Value?.ToString());
            
            return builder.ToString();
        }
    }
}
