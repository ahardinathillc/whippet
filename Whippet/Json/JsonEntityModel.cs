using System;
using System.Collections.Generic;
using System.Text.Json;
using Athi.Whippet.Data;

namespace Athi.Whippet.Json
{
    /// <summary>
    /// Provides a JSON data model for an <see cref="IWhippetEntity"/> object. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> object type the model represents.</typeparam>
    public abstract class JsonEntityModel<TEntity> : IEqualityComparer<TEntity>, IEqualityComparer<JsonEntityModel<TEntity>>
        where TEntity : IWhippetEntity
    {
        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> object. that is being modeled. This property is read-only.
        /// </summary>
        protected TEntity Entity
        { get; private set; }
        
        /// <summary>
        /// Gets or sets the ID of the <typeparamref name="TEntity"/>.
        /// </summary>
        public virtual Guid ID
        {
            get
            {
                return Entity.ID;
            }
            set
            {
                Entity.ID = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEntityModel{TEntity}"/> class with no arguments.
        /// </summary>
        private JsonEntityModel()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonEntityModel{TEntity}"/> class with the specified <typeparamref name="TEntity"/> object.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object that serves as the base model.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JsonEntityModel(TEntity entity)
            : this()
        {
            ArgumentNullException.ThrowIfNull(entity);
            Entity = entity;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(object obj)
        {
            return Entity.Equals(obj);
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(JsonEntityModel<TEntity> obj)
        {
            return Entity.Equals(obj.Entity);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(TEntity x, TEntity y)
        {
            return ((x == null) && (y == null)) || ((x != null) && (y != null) && (x.Equals(y)));
        }
        
        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(JsonEntityModel<TEntity> x, JsonEntityModel<TEntity> y)
        {
            return Equals(x.Entity, y.Entity);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public virtual int GetHashCode()
        {
            return Entity.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(TEntity obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(JsonEntityModel<TEntity> obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return GetHashCode(obj.Entity);
        }

        /// <summary>
        /// Serializes the current instance and returns the result as a JSON string.
        /// </summary>
        /// <param name="options"><see cref="JsonSerializerOptions"/> to apply to the serialization behavior.</param>
        /// <returns>JSON string of the current instance.</returns>
        public virtual string Serialize(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Converts the specified <see cref="JsonEntityModel{TEntity}"/> object to a <typeparamref name="TEntity"/> object.
        /// </summary>
        /// <param name="entity"><see cref="JsonEntityModel{TEntity}"/> object to convert.</param>
        /// <returns><typeparamref name="TEntity"/> object.</returns>
        public static implicit operator TEntity(JsonEntityModel<TEntity> entity)
        {
            return (entity == null) ? default(TEntity) : entity.Entity;
        }
    }
}
