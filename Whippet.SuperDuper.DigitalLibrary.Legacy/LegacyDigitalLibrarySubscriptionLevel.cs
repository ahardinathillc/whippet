using System;
using Athi.Whippet.SuperDuper.Data;
using Athi.Whippet.Data;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy
{
    /// <summary>
    /// Represents a Super Duper Digital Library (SDDL) subscription access level.
    /// </summary>
    public class LegacyDigitalLibrarySubscriptionLevel : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, ILegacyDigitalLibrarySubscriptionLevel, IEqualityComparer<ILegacyDigitalLibrarySubscriptionLevel>
    {
        /// <summary>
        /// Gets or sets the subscription level name.
        /// </summary>
        public virtual string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscriptionLevel"/> class with no arguments.
        /// </summary>
        public LegacyDigitalLibrarySubscriptionLevel()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscriptionLevel"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public LegacyDigitalLibrarySubscriptionLevel(int id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibrarySubscriptionLevel"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the period.</param>
        public LegacyDigitalLibrarySubscriptionLevel(int id, string name)
            : this(id)
        {
            Name = name;
        }
        
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ILegacyDigitalLibrarySubscriptionLevel);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacyDigitalLibrarySubscriptionLevel obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ILegacyDigitalLibrarySubscriptionLevel a, ILegacyDigitalLibrarySubscriptionLevel b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name?.Trim(), b.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Name);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(ILegacyDigitalLibrarySubscriptionLevel obj)
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
        /// Gets the name of the of the <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="ILegacyDigitalLibrarySubscriptionLevel"/> object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }                    
    }
}
