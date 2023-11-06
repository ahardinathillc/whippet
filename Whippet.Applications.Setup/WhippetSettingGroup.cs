using System;
using Athi.Whippet.Data;
using Athi.Whippet.Applications.Setup.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents a logical grouping for <see cref="WhippetSetting"/> objects.
    /// </summary>
    public class WhippetSettingGroup : WhippetEntity, IWhippetSettingGroup, ICloneable, IWhippetCloneable, IWhippetEntity, IEqualityComparer<IWhippetSettingGroup>
    {
        private string _name;

        private WhippetApplication _application;

        /// <summary>
        /// Gets or sets the <see cref="WhippetApplication"/> that the <see cref="WhippetSettingGroup"/> is for.
        /// </summary>
        public virtual WhippetApplication Application
        {
            get
            {
                if (_application == null)
                {
                    _application = new WhippetApplication();
                }

                return _application;
            }
            set
            {
                _application = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetApplication"/> that the <see cref="IWhippetSettingGroup"/> is for.
        /// </summary>
        IWhippetApplication IWhippetSettingGroup.Application
        {
            get
            {
                return Application;
            }
            set
            {
                Application = value.ToWhippetApplication();
            }
        }

        /// <summary>
        /// Gets or sets the setting group ID.
        /// </summary>
        public virtual Guid SettingGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the group name (non-localized; English only).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the setting group description (non-localized; English only).
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroup"/> class with no arguments.
        /// </summary>
        public WhippetSettingGroup()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroup"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetSettingGroup"/>.</param>
        public WhippetSettingGroup(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroup"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetSettingGroup"/>.</param>
        /// <param name="application"><see cref="WhippetApplication"/> that the setting group is for.</param>
        /// <param name="groupId">Setting group ID.</param>
        /// <param name="name">Name of the setting group.</param>
        /// <param name="description">Description of the setting group.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSettingGroup(Guid id, WhippetApplication application, Guid groupId, string name, string description)
            : this(id)
        {
            Application = application;
            SettingGroupID = groupId;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroup"/> class with the specified <see cref="WhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="WhippetSettingGroup"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSettingGroup(WhippetSettingGroup group)
            : this()
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                Application = group.Application;
                SettingGroupID = group.SettingGroupID;
                Name = group.Name;
                Description = group.Description;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetSettingGroup);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSettingGroup obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetSettingGroup"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetSettingGroup"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSettingGroup a, IWhippetSettingGroup b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = ((a.Application == null && b.Application == null) || ((a.Application != null) && (a.Application.Equals(b.Application))))
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                    && a.SettingGroupID.Equals(b.SettingGroupID);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IWhippetSettingGroup obj)
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
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return new WhippetSettingGroup(ID, Application, SettingGroupID, Name, Description);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(((ICloneable)(this)).Clone());
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
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

