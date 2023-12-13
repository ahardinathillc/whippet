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
    /// <see cref="WhippetUser"/> role assignment to a respective <see cref="WhippetRole"/>.
    /// </summary>
    public class WhippetRoleUserAssignment : WhippetAuditableEntity, IWhippetEntity, IWhippetSoftDeleteEntity, IWhippetAuditableEntity, IWhippetActiveEntity, IWhippetRoleUserAssignment
    {
        private WhippetUser _user;
        private WhippetRole _role;

        /// <summary>
        /// <see cref="WhippetUser"/> who is assigned to the <see cref="WhippetRole"/>. This property is read-only.
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
        /// <see cref="WhippetRole"/> that is assigned to the <see cref="WhippetUser"/>. This property is read-only.
        /// </summary>
        public virtual WhippetRole Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new WhippetRole();
                }

                return _role;
            }
            protected set
            {
                _role = value;
            }
        }

        /// <summary>
        /// Gets the ID of the <see cref="WhippetUser"/> who is assigned to the <see cref="WhippetRole"/>. This property is read-only.
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
        /// Gets the ID of the <see cref="WhippetRole"/> that the <see cref="WhippetUser"/> is assigned to. This property is read-only.
        /// </summary>
        public virtual Guid RoleID
        {
            get
            {
                return Role.ID;
            }
            protected set
            {
                Role.ID = value;
            }
        }

        /// <summary>
        /// Indicates whether the role assignment has been deleted.
        /// </summary>
        public virtual bool Deleted
        { get; set; }

        /// <summary>
        /// Indicates whether the role assignment is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// <see cref="IWhippetUser"/> who is assigned to the <see cref="IWhippetRole"/>. This property is read-only.
        /// </summary>
        IWhippetUser IWhippetRoleUserAssignment.User
        {
            get
            {
                return User;
            }
        }

        /// <summary>
        /// <see cref="IWhippetRole"/> that is assigned to the <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        IWhippetRole IWhippetRoleUserAssignment.Role
        {
            get
            {
                return Role;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignment"/> class with no arguments.
        /// </summary>
        public WhippetRoleUserAssignment()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignment"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRoleUserAssignment"/> instance.</param>
        public WhippetRoleUserAssignment(Guid id)
            : base(id, Instant.FromDateTimeUtc(DateTime.UtcNow), id, Instant.FromDateTimeUtc(DateTime.UtcNow), id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRoleUserAssignment"/> instance.</param>
        /// <param name="user"><see cref="IWhippetUser"/> to assign to the role.</param>
        /// <param name="role"><see cref="IWhippetRole"/> to assign to the user.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetRoleUserAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetRoleUserAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetRoleUserAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetRoleUserAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetRoleUserAssignment"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetRoleUserAssignment"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        [Obsolete("This constructor is deprecated and will be removed in a future version.", false)]
        public WhippetRoleUserAssignment(Guid id, IWhippetUser user, IWhippetRole role, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : this(id, user.ToWhippetUser(), role.ToWhippetRole(), createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy, active, deleted)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignment"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the <see cref="WhippetRoleUserAssignment"/> instance.</param>
        /// <param name="user"><see cref="WhippetUser"/> to assign to the role.</param>
        /// <param name="role"><see cref="WhippetRole"/> to assign to the user.</param>
        /// <param name="createdDTTM">Date and time the user account was created or <see langword="null"/> to use the instant the <see cref="WhippetRoleUserAssignment"/> object was created.</param>
        /// <param name="createdBy">ID of the user who created the <see cref="WhippetRoleUserAssignment"/> account.</param>
        /// <param name="lastUpdatedDTTM">Date and time the user account was last updated or <see cref="null"/> to use the instant the <see cref="WhippetRoleUserAssignment"/> object was created.</param>
        /// <param name="lastUpdatedBy">ID of the user who last updated the <see cref="WhippetRoleUserAssignment"/> account.</param>
        /// <param name="active">Specifies whether the <see cref="WhippetRoleUserAssignment"/> account is currently active.</param>
        /// <param name="deleted">Specifies whether the <see cref="WhippetRoleUserAssignment"/> account is currently deleted.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public WhippetRoleUserAssignment(Guid id, WhippetUser user, WhippetRole role, Instant? createdDTTM, Guid? createdBy, Instant? lastUpdatedDTTM, Guid? lastUpdatedBy, bool active, bool deleted)
            : base(id, createdDTTM, createdBy, lastUpdatedDTTM, lastUpdatedBy)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                User = user;
                Role = role;
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
            return Equals(obj as IWhippetRoleUserAssignment);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetRoleUserAssignment obj)
        {
            bool equals = false;

            if (obj != null)
            {
                equals = User.Equals(obj.User)
                        && Role.Equals(obj.Role)
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
        /// <param name="a">The first object of type <see cref="WhippetRoleUserAssignment"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="WhippetRoleUserAssignment"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetRoleUserAssignment a, IWhippetRoleUserAssignment b)
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
        public virtual int GetHashCode(IWhippetRoleUserAssignment obj)
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
        /// Gets the name of the username or e-mail of the <see cref="WhippetRoleUserAssignment"/> object.
        /// </summary>
        /// <returns>String description of the <see cref="WhippetRoleUserAssignment"/> object.</returns>
        public override string ToString()
        {
            return User.ToString() + " (" + Role.ToString() + ")";
        }
    }
}
