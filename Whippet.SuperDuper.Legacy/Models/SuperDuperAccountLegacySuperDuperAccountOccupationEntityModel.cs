using System;
using Athi.Whippet.SuperDuper.Json;

namespace Athi.Whippet.SuperDuper.Legacy.Models
{
    /// <summary>
    /// Lightweight data model that allows for JSON serialization of a <see cref="LegacySuperDuperAccountOccupation"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class SuperDuperAccountLegacySuperDuperAccountOccupationEntityModel : SuperDuperLegacyJsonEntityModel<LegacySuperDuperAccountOccupation>, ILegacySuperDuperAccountOccupation
    {
        /// <summary>
        /// Gets or sets the occupation title.
        /// </summary>
        public string Title
        {
            get
            {
                return Entity.Title;
            }
            set
            {
                Entity.Title = value;
            }
        }

        /// <summary>
        /// Specifies whether the occupation is to be displayed.
        /// </summary>
        public bool Display
        {
            get
            {
                return Entity.Display;
            }
            set
            {
                Entity.Display = value;
            }
        }

        /// <summary>
        /// Gets or sets the display order of the occupation.
        /// </summary>
        public int DisplayOrder
        {
            get
            {
                return Entity.DisplayOrder;
            }
            set
            {
                Entity.DisplayOrder = value;
            }
        }

        /// <summary>
        /// Gets or sets the occupation categorization type.
        /// </summary>
        public string Categorization
        {
            get
            {
                return Entity.Categorization;
            }
            set
            {
                Entity.Categorization = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccountLegacySuperDuperAccountOccupationEntityModel"/> class with the specified <see name="SuperDuperAccountOccupation"/> object.
        /// </summary>
        /// <param name="baseModel"><see name="SuperDuperAccountOccupation"/> object that serves as the base model.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SuperDuperAccountLegacySuperDuperAccountOccupationEntityModel(LegacySuperDuperAccountOccupation baseModel)
            : base(baseModel)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ILegacySuperDuperAccountOccupation obj)
        {
            return Entity.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ILegacySuperDuperAccountOccupation x, ILegacySuperDuperAccountOccupation y)
        {
            return Entity.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ILegacySuperDuperAccountOccupation obj)
        {
            return Entity.GetHashCode(obj);
        }
    }
}
