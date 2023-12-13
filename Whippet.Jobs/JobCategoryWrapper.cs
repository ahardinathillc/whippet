using System;
using Athi.Whippet.Data;
using Athi.Whippet.Jobs.Extensions;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Provides a wrapper class to <see cref="JobCategory"/> objects to provide the <see cref="JobCategory.Name"/> and <see cref="JobCategory.Description"/> as the only mutable properties. This class must be inherited.
    /// </summary>
    public abstract class JobCategoryWrapper : IJobCategory
    {
        private IJobCategory _category;
        private IJobCategory _parent;

        /// <summary>
        /// Gets or sets the internal <see cref="IJobCategory"/> object.
        /// </summary>
        private IJobCategory InternalObject
        {
            get
            {
                if (_category == null)
                {
                    _category = new JobCategory(InternalCategoryId, InternalEnglishName, InternalEnglishDescription, InternalParent.ToJobCategory());
                }

                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IJobCategory"/>.
        /// </summary>
        private IJobCategory InternalParent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;

                // reset the internal object
                InternalObject = new JobCategory(InternalObject.ID, InternalObject.Name, InternalObject.Description, _parent.ToJobCategory());
            }
        }

        /// <summary>
        /// Gets or sets the internal category ID.
        /// </summary>
        private Guid InternalCategoryId
        { get; set; }

        /// <summary>
        /// Gets or sets the internal English name.
        /// </summary>
        private string InternalEnglishName
        { get; set; }

        /// <summary>
        /// Gets or sets the internal English description.
        /// </summary>
        private string InternalEnglishDescription
        { get; set; }

        /// <summary>
        /// Gets the unique ID of the <see cref="IJobCategory"/>. This property is read-only.
        /// </summary>
        public Guid ID
        {
            get
            {
                return InternalCategoryId;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="IJobCategory"/>.
        /// </summary>
        /// <exception cref="EntityIsReadOnlyException" />
        Guid IWhippetEntity.ID
        {
            get
            {
                return ID;
            }
            set
            {
                throw new EntityIsReadOnlyException();
            }
        }

        /// <summary>
        /// Gets or sets the category name. Set to <see cref="String.Empty"/> or <see langword="null"/> to default to the English name.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return InternalObject.Name;
            }
            set
            {
                InternalObject.Name = String.IsNullOrWhiteSpace(value) ? InternalEnglishName : value;
            }
        }

        /// <summary>
        /// Gets or sets the category description. Set to <see cref="String.Empty"/> or <see langword="null"/> to default to the English description.
        /// </summary>
        public virtual string Description
        {
            get
            {
                return InternalObject.Description;
            }
            set
            {
                InternalObject.Description = String.IsNullOrWhiteSpace(value) ? InternalEnglishDescription : value;
            }
        }

        /// <summary>
        /// Gets the current <see cref="IJobCategory"/> object's parent <see cref="IJobCategory"/>. This property is read-only.
        /// </summary>
        IJobCategory IJobCategory.Parent
        {
            get
            {
                return InternalParent;
            }
        }

        /// <summary>
        /// Indicates if the current <see cref="IJobCategory"/> is a root category. This property is read-only.
        /// </summary>
        public bool IsRoot
        {
            get
            {
                return InternalObject.IsRoot;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryWrapper"/> class with no arguments.
        /// </summary>
        private JobCategoryWrapper()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryWrapper"/> class with the specified category ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IJobCategory"/>.</param>
        protected JobCategoryWrapper(Guid id)
            : this(id, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryWrapper"/> class with the specified category ID and parent <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IJobCategory"/>.</param>
        /// <param name="parent"><see cref="IJobCategory"/> that serves as the parent to the current instance.</param>
        protected JobCategoryWrapper(Guid id, IJobCategory parent)
            : this(id, null, null, parent)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryWrapper"/> class with the specified localized name and localized description.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IJobCategory"/>.</param>
        /// <param name="localizedName">Localized name or <see cref="String.Empty"/> or <see langword="null"/> to use the default English name.</param>
        /// <param name="localizedDescription">Localized description or <see cref="String.Empty"/> or <see langword="null"/> to use the default English description.</param>
        /// <param name="parent"><see cref="IJobCategory"/> that serves as the parent to the current instance.</param>
        protected JobCategoryWrapper(Guid id, string localizedName, string localizedDescription, IJobCategory parent = null)
            : this()
        {
            InternalCategoryId = id;
            Name = localizedName;
            Description = localizedDescription;
            InternalParent = parent;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobCategory obj)
        {
            return InternalObject.Equals(obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IJobCategory x, IJobCategory y)
        {
            return InternalObject.Equals(x, y);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return InternalObject.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IJobCategory"/> object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IJobCategory obj)
        {
            return InternalObject.GetHashCode(obj);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return InternalObject.ToString();
        }

        public static implicit operator JobCategory(JobCategoryWrapper obj)
        {
            return (obj == null) ? null : obj.InternalObject.ToJobCategory();
        }
    }
}
