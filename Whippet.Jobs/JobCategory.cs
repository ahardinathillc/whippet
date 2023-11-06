using System;
using Athi.Whippet.Data;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a logical categorization for classes that derive from <see cref="JobBase"/>.
    /// </summary>
    public class JobCategory : WhippetEntity, IWhippetEntity, IJobCategory, IEqualityComparer<IJobCategory>
    {
        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets the parent <see cref="JobCategory"/> (if any). This property is read-only.
        /// </summary>
        public virtual JobCategory Parent
        { get; protected internal set; }

        /// <summary>
        /// Gets the parent <see cref="IJobCategory"/> (if any). This property is read-only.
        /// </summary>
        IJobCategory IJobCategory.Parent
        {
            get
            {
                return Parent;
            }
        }

        /// <summary>
        /// Gets the unique ID of the <see cref="Parent"/> category. This property is read-only.
        /// </summary>
        protected internal virtual Guid? ParentID
        {
            get
            {
                return (Parent == null) ? null : Parent.ID;
            }
            set
            {
                if (value == null)
                {
                    Parent = null;
                }
                else
                {
                    Parent = new JobCategory(value.GetValueOrDefault());
                }
            }
        }

        /// <summary>
        /// Indicates if the current <see cref="JobCategory"/> is a root category. This property is read-only.
        /// </summary>
        public virtual bool IsRoot
        {
            get
            {
                return Parent == null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategory"/> class with no arguments.
        /// </summary>
        public JobCategory()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategory"/> class with the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public JobCategory(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategory"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the category.</param>
        /// <param name="description">Description of the category.</param>
        public JobCategory(Guid id, string name, string description)
            : this(id, name, description, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategory"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="name">Name of the category.</param>
        /// <param name="description">Description of the category.</param>
        /// <param name="parent">Parent <see cref="JobCategory"/> (if any).</param>
        public JobCategory(Guid id, string name, string description, JobCategory parent)
            : this(id)
        {
            Name = name;
            Description = description;
            Parent = parent;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is IJob)) ? false : Equals((IJob)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobCategory obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobCategory x, IJobCategory y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                    && (x.IsRoot == y.IsRoot)
                    && ((x.Parent == null && y.Parent == null) || (x.Parent != null && x.Parent.Equals(y.Parent)));
            }

            return equals;
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
        /// <param name="obj"><see cref="IJobCategory"/> object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IJobCategory obj)
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
            if (String.IsNullOrWhiteSpace(Name))
            {
                return base.ToString();
            }
            else
            {
                return Name + " (" + (String.IsNullOrWhiteSpace(Description) ? "No Description" : Description) + ") [" + (IsRoot ? "Root" : "Leaf") + "]";
            }
        }

        /// <summary>
        /// Returns a JSON string representing the current object.\
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
