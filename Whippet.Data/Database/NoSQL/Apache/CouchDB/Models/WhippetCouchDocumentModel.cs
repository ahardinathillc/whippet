using System;
using System.Collections.Generic;
using CouchDB.Driver.Types;
using Newtonsoft.Json;
using Athi.Whippet.Json;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models
{
    /// <summary>
    /// Base class for all <see cref="IWhippetCouchDocument"/> models and view models. This class must be inherited.
    /// </summary>
    public abstract class WhippetCouchDocumentModel<T> : IWhippetCouchDocument, IWhippetEntity, IJsonObject, IJsonSerializableObject
        where T : CouchDocument
    {
        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        [JsonProperty("id")]
        public virtual string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return String.IsNullOrWhiteSpace(ID) ? Guid.Empty : Guid.Parse(ID);
            }
            set
            {
                ID = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the revision identifier.
        /// </summary>
        [JsonProperty("rev")]
        public virtual string Rev
        { get; set; }

        /// <summary>
        /// Indicates whether the document has been deleted. This property is read-only.
        /// </summary>
        [JsonProperty("deleted")]
        public virtual bool Deleted
        { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document. This property is read-only.
        /// </summary>
        [JsonProperty("conflicts")]
        public virtual IReadOnlyCollection<string> Conflicts
        { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document that have been deleted. This property is read-only.
        /// </summary>
        [JsonProperty("deletedConflicts")]
        public virtual IReadOnlyCollection<string> DeletedConflicts
        { get; protected set; }

        /// <summary>
        /// Gets the local sequence number of the document. This property is read-only.
        /// </summary>
        [JsonProperty("localSequence")]
        public virtual int LocalSequence
        { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all revisions that have been applied to the document. This property is read-only.
        /// </summary>
        [JsonProperty("revisionsInfo")]
        public virtual IReadOnlyCollection<RevisionInfo> RevisionsInfo
        { get; protected set; }

        /// <summary>
        /// Gets all the IDs of all the revisions that have been applied to the document. This property is read-only.
        /// </summary>
        [JsonProperty("revisions")]
        public virtual Revisions Revisions
        { get; protected set; }

        /// <summary>
        /// Gets all attachments associated with the document. This property is read-only.
        /// </summary>
        [JsonProperty("attachments")]
        public virtual CouchAttachmentsCollection Attachments
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentModel{T}"/> class with no arguments.
        /// </summary>
        private WhippetCouchDocumentModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDocumentModel{T}"/> class with the specified <typeparamref name="T"/> <see cref="CouchDocument"/>.
        /// </summary>
        /// <param name="couchDocument"><typeparamref name="T"/> <see cref="CouchDocument"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetCouchDocumentModel(T couchDocument)
            : this()
        {
            if (couchDocument == null)
            {
                throw new ArgumentNullException(nameof(couchDocument));
            }
            else
            {
                ID = couchDocument.Id;
                Rev = couchDocument.Rev;
                Deleted = couchDocument.Deleted;
                Conflicts = couchDocument.Conflicts;
                DeletedConflicts = couchDocument.DeletedConflicts;
                LocalSequence = couchDocument.LocalSequence;
                RevisionsInfo = couchDocument.RevisionsInfo;
                Revisions = couchDocument.Revisions;
                Attachments = couchDocument.Attachments;

                AssignValues(couchDocument);
            }
        }

        /// <summary>
        /// Assigns extra values to the view model based on the <typeparamref name="T"/> <see cref="CouchDocument"/>. This method must be overridden.
        /// </summary>
        /// <param name="couchDocument"><typeparamref name="T"/> <see cref="CouchDocument"/> to retrieve values from.</param>
        /// <exception cref="ArgumentNullException" />
        protected abstract void AssignValues(T couchDocument);

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="TObject"><see cref="IJsonSerializableObject"/> object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public abstract string ToJson<TObject>() where TObject : IJsonSerializableObject;
    }
}
