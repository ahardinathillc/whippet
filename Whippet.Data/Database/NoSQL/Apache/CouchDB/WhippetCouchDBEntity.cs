using System;
using CouchDB.Driver.Types;
using Athi.Whippet.Json;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a domain object in Whippet for CouchDB. This class must be inherited.
    /// </summary>
    public abstract class WhippetCouchDBEntity : CouchDocument, IWhippetEntity, IWhippetNoSQLEntity, IWhippetCouchDocument, IJsonObject
    {
        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        string IWhippetCouchDocument.ID
        {
            get
            {
                return ((IWhippetEntity)(this)).ID.ToString();
            }
            set
            {
                ((IWhippetEntity)(this)).ID = String.IsNullOrWhiteSpace(value) ? Guid.Empty : Guid.Parse(value);
            }
        }

        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return String.IsNullOrWhiteSpace(base.Id) ? Guid.Empty : new Guid(base.Id);
            }
            set
            {
                base.Id = value.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBEntity"/> class with no arguments.
        /// </summary>
        protected WhippetCouchDBEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        protected WhippetCouchDBEntity(Guid id)
            : this()
        {
            ((IWhippetEntity)(this)).ID = id;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ((IWhippetEntity)(this)).GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(WhippetCouchDBEntity obj)
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
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public abstract string ToJson<T>() where T : IJsonSerializableObject;
    }
}
