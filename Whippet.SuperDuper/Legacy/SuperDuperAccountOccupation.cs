using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy
{
    /// <summary>
    /// Represents an occupation of a <see cref="SuperDuperAccount"/> in Super Duper legacy applications.
    /// </summary>
    public class SuperDuperAccountOccupation : SuperDuperLegacyEntity, IWhippetEntity, ISuperDuperLegacyEntity, IOccupation, IEqualityComparer<IOccupation>
    {
        /// <summary>
        /// Gets or sets the occupation title.
        /// </summary>
        public virtual string Title
        { get; set; }
        
        /// <summary>
        /// Specifies whether the occupation is to be displayed.
        /// </summary>
        public virtual bool Display
        { get; set; }
        
        /// <summary>
        /// Gets or sets the display order of the occupation.
        /// </summary>
        public virtual int DisplayOrder
        { get; set; }
        
        /// <summary>
        /// Gets or sets the occupation categorization type.
        /// </summary>
        public virtual string Categorization
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccountOccupation"/> class with no arguments.
        /// </summary>
        public SuperDuperAccountOccupation()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperDuperAccountOccupation"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID </param>
        public SuperDuperAccountOccupation(int id)
            : base(id)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(object obj)
        {
            return (obj == null) || !(obj is IOccupation) ? false : Equals((IOccupation)(obj));
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IOccupation obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IOccupation x, IOccupation y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = (x.Display == y.Display)
                         && (x.DisplayOrder == y.DisplayOrder)
                         && String.Equals(x.Categorization?.Trim(), y.Categorization?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, DisplayOrder, Display, Categorization, Title);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public virtual int GetHashCode(IOccupation obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the object.
        /// </summary>
        /// <returns>String representation of the object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Title) ? base.ToString() : Title;
        }
    }
}
