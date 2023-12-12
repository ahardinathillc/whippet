using System;
using System.Globalization;
using System.Text;
using Athi.Whippet.Data;
using Newtonsoft.Json;

namespace Athi.Whippet.SuperDuper.Data
{
    /// <summary>
    /// Base class for all domain objects in Super Duper. This class must be inherited.
    /// </summary>
    public abstract class SuperDuperLegacyEntity : WhippetEntity, IWhippetEntity, ISuperDuperLegacyEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        [JsonRequired]
        public new virtual int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        Guid IWhippetEntity.ID
        {
            get
            {
                return IntegerIdToGuid(ID);
            }
            set
            {
                ID = GuidIdToInteger(value);
                base.ID = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperLegacyEntity"/> class with no arguments.
        /// </summary>
        protected SuperDuperLegacyEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperLegacyEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        protected SuperDuperLegacyEntity(int id)
            : base()
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                ID = id;
                base.ID = IntegerIdToGuid(id);
            }
        }
    }
}
