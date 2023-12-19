using System;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Json
{
    /// <summary>
    /// Provides a JSON data model for an <see cref="ISuperDuperLegacyEntity"/> object. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="ISuperDuperLegacyEntity"/> object type the model represents.</typeparam>
    public abstract class SuperDuperLegacyJsonEntityModel<TEntity> : JsonEntityModel<TEntity>, ISuperDuperLegacyEntity
        where TEntity : ISuperDuperLegacyEntity, IWhippetEntity
    {
        /// <summary>
        /// Gets or sets the ID of the <typeparamref name="TEntity"/>.
        /// </summary>
        public virtual new int ID
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
        /// Gets or sets the date and time the entity was created. This property may or may not be used by the backing entity.
        /// </summary>
        public virtual Instant CreatedDTTM
        {
            get
            {
                return Entity.CreatedDTTM;
            }
            set
            {
                Entity.CreatedDTTM = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperLegacyJsonEntityModel{TEntity}"/> class with the specified <typeparamref name="TEntity"/> object.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object that serves as the base model.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected SuperDuperLegacyJsonEntityModel(TEntity entity)
            : base(entity)
        { }
    }
}
