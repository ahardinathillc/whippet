using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Applications.Setup.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents an individual application setting for a <see cref="WhippetApplication"/> instance.
    /// </summary>
    public class WhippetSetting : WhippetEntity, IWhippetSetting, ICloneable, IWhippetCloneable, IWhippetEntity, IEqualityComparer<IWhippetSetting>
    {
        private string _name;

        private WhippetSettingGroup _group;

        /// <summary>
        /// Gets or sets the parent <see cref="WhippetSettingGroup"/> that the setting belongs to.
        /// </summary>
        public virtual WhippetSettingGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new WhippetSettingGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IWhippetSettingGroup"/> that the setting belongs to.
        /// </summary>
        IWhippetSettingGroup IWhippetSetting.Group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value.ToWhippetSettingGroup();
            }
        }

        /// <summary>
        /// Gets or sets the setting ID.
        /// </summary>
        public virtual Guid SettingID
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
        /// Gets or sets the setting description (non-localized; English only).
        /// </summary>
        public virtual string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a byte array.
        /// </summary>
        public virtual byte[] ByteValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as an <see cref="Instant"/> value.
        /// </summary>
        public virtual Instant? InstantValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as an <see cref="Int32"/> value.
        /// </summary>
        public virtual int? IntegerValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Decimal"/> value.
        /// </summary>
        public virtual decimal? DecimalValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Double"/> value.
        /// </summary>
        public virtual double? DoubleValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Boolean"/> value.
        /// </summary>
        public virtual bool? BoolValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="String"/>  value.
        /// </summary>
        public virtual string StringValue
        { get; set; }

        /// <summary>
        /// Gets or sets the value stored as a <see cref="Guid"/> value.
        /// </summary>
        public virtual Guid? GuidValue
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSetting"/> class with no arguments.
        /// </summary>
        public WhippetSetting()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSetting"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetSetting"/>.</param>
        public WhippetSetting(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSetting"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetSetting"/> object.</param>
        /// <param name="group">Parent <see cref="WhippetSettingGroup"/> that the setting belongs to.</param>
        /// <param name="settingId">Setting ID.</param>
        /// <param name="name">Name of the setting.</param>
        /// <param name="description">Setting description.</param>
        /// <param name="byteValue">Byte value of the setting.</param>
        /// <param name="instantValue"><see cref="Instant"/> value of the setting.</param>
        /// <param name="intValue">Integer value of the setting.</param>
        /// <param name="decimalValue">Decimal value of the setting.</param>
        /// <param name="doubleValue">Double-precision decimal value of the setting.</param>
        /// <param name="boolValue">Boolean value of the setting.</param>
        /// <param name="stringValue">String value of the setting.</param>
        /// <param name="guidValue">GUID value of the setting.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSetting(Guid id, WhippetSettingGroup group, Guid settingId, string name, string description, byte[] byteValue = null, Instant? instantValue = null, int? intValue = null, decimal? decimalValue = null, double? doubleValue = null, bool? boolValue = null, string stringValue = null, Guid? guidValue = null)
            : this(id)
        {
            Group = group;
            SettingID = settingId;
            Name = name;
            Description = description;
            ByteValue = byteValue;
            InstantValue = instantValue;
            IntegerValue = intValue;
            DecimalValue = decimalValue;
            DoubleValue = doubleValue;
            BoolValue = boolValue;
            StringValue = stringValue;
            GuidValue = guidValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSetting"/> class with the specified <see cref="WhippetSetting"/> object.
        /// </summary>
        /// <param name="setting"><see cref="WhippetSetting"/> object to initialize wtih.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetSetting(WhippetSetting setting)
            : this()
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
            else
            {
                Group = setting.Group;
                SettingID = setting.SettingID;
                Name = setting.Name;
                Description = setting.Description;
                ByteValue = setting.ByteValue;
                InstantValue = setting.InstantValue;
                IntegerValue = setting.IntegerValue;
                DecimalValue = setting.DecimalValue;
                DoubleValue = setting.DoubleValue;
                BoolValue = setting.BoolValue;
                StringValue = setting.StringValue;
                GuidValue = setting.GuidValue;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetSetting);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSetting obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetSetting"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetSetting"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetSetting a, IWhippetSetting b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = ((a.Group == null && b.Group == null) || ((a.Group != null) && (a.Group.Equals(b.Group))))
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Description, b.Description, StringComparison.InvariantCultureIgnoreCase)
                    && a.SettingID.Equals(b.SettingID)
                    && ((a.ByteValue == null && b.ByteValue == null) || ((a.ByteValue != null) && a.ByteValue.SequenceEqual(b.ByteValue)))
                    && a.InstantValue.GetValueOrDefault().Equals(b.InstantValue.GetValueOrDefault())
                    && a.IntegerValue.GetValueOrDefault().Equals(b.IntegerValue.GetValueOrDefault())
                    && a.DecimalValue.GetValueOrDefault().Equals(b.DecimalValue.GetValueOrDefault())
                    && a.DoubleValue.GetValueOrDefault().Equals(b.DoubleValue.GetValueOrDefault())
                    && a.BoolValue.GetValueOrDefault().Equals(b.BoolValue.GetValueOrDefault())
                    && String.Equals(a.StringValue, b.StringValue)     // settings are case-sensitive
                    && a.GuidValue.GetValueOrDefault().Equals(b.GuidValue.GetValueOrDefault());
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
        public virtual int GetHashCode(IWhippetSetting obj)
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
            return new WhippetSetting(ID, Group.Clone<WhippetSettingGroup>(), SettingID, Name, Description, ByteValue, InstantValue, IntegerValue, DecimalValue, DoubleValue, BoolValue, StringValue, GuidValue);
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

