using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models
{
    /// <summary>
    /// Lightweight view model that captures the response of the <code>_all_docs</code> view of CouchDB. This class cannot be inherited. 
    /// </summary>
    public sealed class WhippetCouchAllDocsResponseModel
    {
        private List<WhippetCouchDocumentEntryModel> _rows;
        
        /// <summary>
        /// Gets or sets the total rows returned from the data store.
        /// </summary>
        [JsonProperty("total_rows")]
        public int TotalEntries
        { get; set; }
        
        /// <summary>
        /// Gets or sets the offset of the row result.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset
        { get; set; }

        /// <summary>
        /// Gets or sets the entries contained within the response.
        /// </summary>
        [JsonProperty("rows")]
        public List<WhippetCouchDocumentEntryModel> Entries
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new List<WhippetCouchDocumentEntryModel>();
                }

                return _rows;
            }
            set
            {
                _rows = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchAllDocsResponseModel"/> class with no arguments.
        /// </summary>
        public WhippetCouchAllDocsResponseModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchAllDocsResponseModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="totalEntries">Total number of entries returned by the response.</param>
        /// <param name="offset">Offset of the rows returned from the document store.</param>
        /// <param name="entries">Entries returned by the response.</param>
        public WhippetCouchAllDocsResponseModel(int totalEntries, int offset, IEnumerable<WhippetCouchDocumentEntryModel> entries)
            : this()
        {
            TotalEntries = totalEntries;
            Offset = offset;

            if (entries != null && entries.Any())
            {
                Entries = new List<WhippetCouchDocumentEntryModel>(entries);
            }
        }
    }
}
