using System;
using System.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Applications.Setup
{
    /// <summary>
    /// Represents an application that is powered by the Whippet engine.
    /// </summary>
    public class WhippetApplication : WhippetEntity, IWhippetEntity, IWhippetApplication, ICloneable, IWhippetCloneable, IEqualityComparer<IWhippetApplication>
    {
        private WhippetTenant _tenant;

        private string _name;

        /// <summary>
        /// Gets or sets the <see cref="WhippetTenant"/> that the application applies to.
        /// </summary>
        public virtual WhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new WhippetTenant();
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the application applies to.
        /// </summary>
        IWhippetTenant IWhippetApplication.Tenant
        {
            get
            {
                return Tenant;
            }
            set
            {
                Tenant = value.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Gets the application name. This property is read-only.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            protected set
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
        /// Gets the application ID. This property is read-only.
        /// </summary>
        public virtual Guid ApplicationID
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplication"/> class with no arguments.
        /// </summary>
        public WhippetApplication()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplication"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetApplication"/>.</param>
        public WhippetApplication(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplication"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetApplication"/>.</param>
        /// <param name="applicationId">Application identifier.</param>
        /// <param name="name">Name of the application.</param>
        /// <param name="tenant"><see cref="WhippetTenant"/> that hosts the application.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetApplication(Guid id, Guid applicationId, string name, WhippetTenant tenant)
            : this(id)
        {
            Name = name;
            Tenant = tenant;
            ApplicationID = applicationId;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetApplication);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetApplication obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetApplication"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetApplication"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetApplication a, IWhippetApplication b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = ((a.Tenant == null && b.Tenant == null) || ((a.Tenant != null) && (a.Tenant.Equals(b.Tenant))))
                    && String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && a.ApplicationID.Equals(b.ApplicationID);
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
        public virtual int GetHashCode(IWhippetApplication obj)
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
            return new WhippetApplication(ID, ApplicationID, Name, Tenant.Clone<WhippetTenant>());
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

    }
}
