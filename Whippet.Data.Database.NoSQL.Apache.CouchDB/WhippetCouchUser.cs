using System;
using CouchDB.Driver.Types;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a default <see cref="CouchUser"/> entity in a CouchDB database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetCouchUser : WhippetCouchDBEntity, IWhippetEntity, IWhippetCouchDocument, IWhippetCouchUser, IEqualityComparer<IWhippetCouchUser>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="CouchUser"/> object.
        /// </summary>
        private CouchUser InternalObject
        { get; set; }

        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        string IWhippetCouchDocument.ID
        {
            get
            {
                return ((IWhippetEntity)(InternalObject)).ID.ToString();
            }
            set
            {
                ((IWhippetEntity)(InternalObject)).ID = String.IsNullOrWhiteSpace(value) ? Guid.Empty : Guid.Parse(value);
            }
        }

        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return String.IsNullOrWhiteSpace(InternalObject.Id) ? Guid.Empty : new Guid(InternalObject.Id);
            }
            set
            {
                InternalObject.Id = value.ToString();
            }
        }
        /// <summary>
        /// Gets or sets the revision identifier.
        /// </summary>
        public new string Rev
        {
            get
            {
                return InternalObject.Rev;
            }
            set
            {
                InternalObject.Rev = value;
            }
        }

        /// <summary>
        /// Indicates whether the document has been deleted. This property is read-only.
        /// </summary>
        public new bool Deleted
        {
            get
            {
                return InternalObject.Deleted;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document. This property is read-only.
        /// </summary>
        public new IReadOnlyCollection<string> Conflicts
        {
            get
            {
                return InternalObject.Conflicts;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all conflicts in the document that have been deleted. This property is read-only.
        /// </summary>
        public new IReadOnlyCollection<string> DeletedConflicts
        {
            get
            {
                return InternalObject.DeletedConflicts;
            }
        }

        /// <summary>
        /// Gets the local sequence number of the document. This property is read-only.
        /// </summary>
        public new int LocalSequence
        {
            get
            {
                return InternalObject.LocalSequence;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyCollection{T}"/> of all revisions that have been applied to the document. This property is read-only.
        /// </summary>
        public new IReadOnlyCollection<RevisionInfo> RevisionsInfo
        {
            get
            {
                return InternalObject.RevisionsInfo;
            }
        }

        /// <summary>
        /// Gets all the IDs of all the revisions that have been applied to the document. This property is read-only.
        /// </summary>
        public new Revisions Revisions
        {
            get
            {
                return InternalObject.Revisions;
            }
        }

        /// <summary>
        /// Gets all attachments associated with the document. This property is read-only.
        /// </summary>
        public new CouchAttachmentsCollection Attachments
        {
            get
            {
                return InternalObject.Attachments;
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Name
        {
            get
            {
                return InternalObject.Name;
            }
            set
            {
                InternalObject.Name = value;
            }
        }

        /// <summary>
        /// Gets or sets all roles that are applied to the user.
        /// </summary>
        public IList<string> Roles
        {
            get
            {
                return InternalObject.Roles;
            }
            set
            {
                InternalObject.Roles = (value == null) ? null : new List<string>(value);
            }
        }

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        public string Type
        {
            get
            {
                return InternalObject.Type;
            }
            set
            {
                InternalObject.Type = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchUser"/> class with no arguments.
        /// </summary>
        public WhippetCouchUser()
            : this(new CouchUser("user", "password"))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchUser"/> class with the specified <see cref="CouchUser"/> object.
        /// </summary>
        /// <param name="user"><see cref="CouchUser"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetCouchUser(CouchUser user)
            : base()
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                InternalObject = user;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchUser"/> class.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="password">User password.</param>
        /// <param name="roles">Roles assigned to the user.</param>
        /// <param name="type">Type of user to initialize.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetCouchUser(string name, string password, IEnumerable<string> roles = null, string type = "user")
            : this(new CouchUser(name, password, roles?.ToList(), type))
        { }

        /// <summary>
        /// Determines whether the current instance equals the specified object.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            bool equals = false;
            IWhippetCouchUser user = null;

            if (obj == null || (!(obj is IWhippetCouchUser) && !(obj is CouchUser)))
            {
                equals = false;
            }
            else
            {
                if (!(obj is IWhippetCouchUser) && (obj is CouchUser))
                {
                    user = new WhippetCouchUser((CouchUser)(obj));
                }
                else
                {
                    user = ((IWhippetCouchUser)(obj));
                }

                equals = Equals(user);
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the current instance equals the specified object.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IWhippetCouchUser obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Determines if the two objects are equal.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(IWhippetCouchUser x, IWhippetCouchUser y)
        {
            bool equals = (x == null) && (y == null);
            bool collectionsEqual = false;

            int x_collectionCount = 0;
            int y_collectionCount = 0;

            if (!equals && ((x != null) && (y != null)))
            {
                equals = (x.Deleted == y.Deleted)
                    && (x.LocalSequence == y.LocalSequence)
                    && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Rev?.Trim(), y.Rev?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && CouchRevisionsEqualityComparer.Instance.Equals(x.Revisions, y.Revisions)
                    && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase);

                if (equals && (x.Attachments != null) && (y.Attachments != null))
                {
                    if (!x.Attachments.TryGetNonEnumeratedCount(out x_collectionCount))
                    {
                        x_collectionCount = x.Attachments.Count();
                    }

                    if (!y.Attachments.TryGetNonEnumeratedCount(out y_collectionCount))
                    {
                        y_collectionCount = y.Attachments.Count();
                    }

                    if (x_collectionCount == y_collectionCount)
                    {
                        foreach (CouchAttachment attachment in y.Attachments)
                        {
                            if (!y.Attachments.Contains(attachment, CouchAttachmentEqualityComparer.Instance))
                            {
                                collectionsEqual = false;
                                break;
                            }
                            else
                            {
                                collectionsEqual = true;
                            }
                        }
                    }

                    if (collectionsEqual)
                    {
                        collectionsEqual = false;   // reset value

                        if (!x.Conflicts.TryGetNonEnumeratedCount(out x_collectionCount))
                        {
                            x_collectionCount = x.Conflicts.Count();
                        }

                        if (!y.Conflicts.TryGetNonEnumeratedCount(out y_collectionCount))
                        {
                            y_collectionCount = y.Conflicts.Count();
                        }

                        if (x_collectionCount == y_collectionCount)
                        {
                            foreach (string conflict in x.Conflicts)
                            {
                                if (!y.Conflicts.Contains(conflict, StringComparer.InvariantCultureIgnoreCase))
                                {
                                    collectionsEqual = false;
                                    break;
                                }
                                else
                                {
                                    collectionsEqual = true;
                                }
                            }
                        }

                        if (collectionsEqual)
                        {
                            collectionsEqual = false;   // reset value

                            if (!x.DeletedConflicts.TryGetNonEnumeratedCount(out x_collectionCount))
                            {
                                x_collectionCount = x.DeletedConflicts.Count();
                            }

                            if (!y.DeletedConflicts.TryGetNonEnumeratedCount(out y_collectionCount))
                            {
                                y_collectionCount = y.DeletedConflicts.Count();
                            }

                            if (x_collectionCount == y_collectionCount)
                            {
                                foreach (string conflict in x.DeletedConflicts)
                                {
                                    if (!y.DeletedConflicts.Contains(conflict, StringComparer.InvariantCultureIgnoreCase))
                                    {
                                        collectionsEqual = false;
                                        break;
                                    }
                                    else
                                    {
                                        collectionsEqual = true;
                                    }
                                }
                            }

                            if (collectionsEqual)
                            {
                                collectionsEqual = false;   // reset value

                                if (!x.RevisionsInfo.TryGetNonEnumeratedCount(out x_collectionCount))
                                {
                                    x_collectionCount = x.RevisionsInfo.Count();
                                }

                                if (!y.RevisionsInfo.TryGetNonEnumeratedCount(out y_collectionCount))
                                {
                                    y_collectionCount = y.RevisionsInfo.Count();
                                }

                                if (x_collectionCount == y_collectionCount)
                                {
                                    foreach (RevisionInfo info in x.RevisionsInfo)
                                    {
                                        if (!y.RevisionsInfo.Contains(info, CouchRevisionInfoEqualityComparer.Instance))
                                        {
                                            collectionsEqual = false;
                                            break;
                                        }
                                        else
                                        {
                                            collectionsEqual = true;
                                        }
                                    }
                                }

                                if (collectionsEqual)
                                {
                                    collectionsEqual = false;   // reset value

                                    if (!x.Roles.TryGetNonEnumeratedCount(out x_collectionCount))
                                    {
                                        x_collectionCount = x.Roles.Count();
                                    }

                                    if (!y.Roles.TryGetNonEnumeratedCount(out y_collectionCount))
                                    {
                                        y_collectionCount = y.Roles.Count();
                                    }

                                    if (x_collectionCount == y_collectionCount)
                                    {
                                        foreach (string role in x.Roles)
                                        {
                                            if (!y.Roles.Contains(role, StringComparer.InvariantCultureIgnoreCase))
                                            {
                                                collectionsEqual = false;
                                                break;
                                            }
                                            else
                                            {
                                                collectionsEqual = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    equals = collectionsEqual;
                }
            }

            return equals;
        }

        /// <summary>
        /// Returns the current instance as a <see cref="CouchUser"/> object.
        /// </summary>
        /// <returns><see cref="CouchUser"/> object.</returns>
        public CouchUser ToCouchUser()
        {
            return InternalObject;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IWhippetCouchUser obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }

        public static implicit operator CouchUser(WhippetCouchUser user)
        {
            return (user == null) ? null : user.ToCouchUser();
        }
    }
}

