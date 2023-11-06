using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.AccessControl.Extensions;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// <see cref="WhippetUser"/> group assignment to a respective <see cref="WhippetGroup"/>.
    /// </summary>
    public class WhippetGroupUserAssignment : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetGroupUserAssignment
    {
        private WhippetUser _user;
        private WhippetGroup _group;

        /// <summary>
        /// <see cref="WhippetUser"/> who is assigned to the <see cref="WhippetGroup"/>. This property is read-only.
        /// </summary>
        public virtual WhippetUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new WhippetUser();
                }

                return _user;
            }
            protected set
            {
                _user = value;
            }
        }

        /// <summary>
        /// <see cref="WhippetGroup"/> that is assigned to the <see cref="WhippetUser"/>. This property is read-only.
        /// </summary>
        public virtual WhippetGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new WhippetGroup();
                }

                return _group;
            }
            protected set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets the ID of the <see cref="WhippetUser"/> who is assigned to the <see cref="WhippetGroup"/>. This property is read-only.
        /// </summary>
        public virtual Guid UserID
        {
            get
            {
                return User.ID;
            }
            protected set
            {
                User.ID = value;
            }
        }

        /// <summary>
        /// Gets the ID of the <see cref="WhippetGroup"/> that the <see cref="WhippetUser"/> is assigned to. This property is read-only.
        /// </summary>
        public virtual Guid GroupID
        {
            get
            {
                return Group.ID;
            }
            protected set
            {
                Group.ID = value;
            }
        }

        /// <summary>
        /// Indicates whether the group assignment has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Indicates whether the group assignment is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// <see cref="IWhippetUser"/> who is assigned to the <see cref="IWhippetGroup"/>. This property is read-only.
        /// </summary>
        IWhippetUser IWhippetGroupUserAssignment.User
        {
            get
            {
                return User;
            }
        }

        /// <summary>
        /// <see cref="IWhippetGroup"/> that is assigned to the <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        IWhippetGroup IWhippetGroupUserAssignment.Group
        {
            get
            {
                return Group;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignment"/> class with no arguments.
        /// </summary>
        public WhippetGroupUserAssignment()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignment"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetGroupUserAssignment"/> instance.</param>
        public WhippetGroupUserAssignment(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetGroupUserAssignment"/> instance.</param>
        /// <param name="user"><see cref="IWhippetUser"/> to assign to the group.</param>
        /// <param name="group"><see cref="IWhippetGroup"/> to assign to the user.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetGroupUserAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetGroupUserAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetGroupUserAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetGroupUserAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetGroupUserAssignment"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetGroupUserAssignment"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        [Obsolete("This constructor is obsolete and will be removed in a future version.", false)]
        public WhippetGroupUserAssignment(Guid id, IWhippetUser user, IWhippetGroup group, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : this(id, user?.ToWhippetUser(), group?.ToWhippetGroup(), createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy, active, deleted)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetGroupUserAssignment"/> instance.</param>
        /// <param name="user"><see cref="IWhippetUser"/> to assign to the group.</param>
        /// <param name="group"><see cref="IWhippetGroup"/> to assign to the user.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetGroupUserAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetGroupUserAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetGroupUserAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetGroupUserAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetGroupUserAssignment"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetGroupUserAssignment"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetGroupUserAssignment(Guid id, WhippetUser user, WhippetGroup group, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                User = user;
                Group = group;
                Active = active;
                Deleted = deleted;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IWhippetGroupUserAssignment);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetGroupUserAssignment obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = User.Equals(obj.User)
                        && Group.Equals(obj.Group)
                        && CreatedDateTime.Equals(obj.CreatedDateTime)
                        && LastModifiedDateTime.Equals(obj.LastModifiedDateTime)
                        && CreatedBy.Equals(obj.CreatedBy)
                        && LastModifiedBy.Equals(obj.LastModifiedBy)
                        && Active == obj.Active
                        && Deleted == obj.Deleted;
            }

            return equals;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IWhippetGroupUserAssignment"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IWhippetGroupUserAssignment"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetGroupUserAssignment a, IWhippetGroupUserAssignment b)
        {
            return ((a != null) && (b != null) && (a.Equals(b))) || (a == null && b == null);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IWhippetGroupUserAssignment obj)
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
        /// Gets the name of the username or e-mail of the <see cref="WhippetGroupUserAssignment"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetGroupUserAssignment"/> object.</returns>
        public override string ToString()
        {
            return User.ToString() + " (" + Group.ToString() + ")";
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
