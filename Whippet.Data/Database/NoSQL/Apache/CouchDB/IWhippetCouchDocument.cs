using System;
using System.Collections.Generic;
using CouchDB.Driver.Types;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a <see cref="CouchDocument"/> that is used within Whippet.
    /// </summary>
    public interface IWhippetCouchDocument : IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        new string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the revision identifier.
        /// </summary>
        string Rev
        { get; set; }

        /// <summary>
        /// Indicates whether the document has been deleted. This property is read-only.
        /// </summary>
        bool Deleted
        { get; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document. This property is read-only.
        /// </summary>
        IReadOnlyCollection<string> Conflicts
        { get; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document that have been deleted. This property is read-only.
        /// </summary>
        IReadOnlyCollection<string> DeletedConflicts
        { get; }

        /// <summary>
        /// Gets the local sequence number of the document. This property is read-only.
        /// </summary>
        int LocalSequence
        { get; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all revisions that have been applied to the document. This property is read-only.
        /// </summary>
        IReadOnlyCollection<RevisionInfo> RevisionsInfo
        { get; }

        /// <summary>
        /// Gets all the IDs of all the revisions that have been applied to the document. This property is read-only.
        /// </summary>
        Revisions Revisions
        { get; }

        /// <summary>
        /// Gets all attachments associated with the document. This property is read-only.
        /// </summary>
        CouchAttachmentsCollection Attachments
        { get; }
    }
}
