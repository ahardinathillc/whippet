using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.IO;
using System.Runtime.Serialization;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.Claims
{
    /// <summary>
    /// Represents an identity that is described by a collection of claims. A claim is a statement about an entity made by an issuer that describes a property, right, or some other quality of that entity.
    /// </summary>
    public class WhippetClaimsIdentity : ClaimsIdentity, IIdentity
    {
        private string _roleClaimType;
        private string _groupClaimType;

        /// <summary>
        /// Gets the claim type that will be interpreted as a .NET role among the claims in this claims identity. This property is read-only.
        /// </summary>
        public new string RoleClaimType
        {
            get
            {
                return String.IsNullOrWhiteSpace(_roleClaimType) ? base.RoleClaimType : _roleClaimType;
            }
            private set
            {
                _roleClaimType = value;
            }
        }

        /// <summary>
        /// Gets the claim type that will be interpreted as a Whippet group among the claims in this claims identity. This property is read-only.
        /// </summary>
        public string GroupClaimType
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_groupClaimType))
                {
                    _groupClaimType = typeof(WhippetGroup).AssemblyQualifiedName;
                }

                return _groupClaimType;
            }
            private set
            {
                _groupClaimType = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class with no arguments.
        /// </summary>
        public WhippetClaimsIdentity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from the specified <see cref="IIdentity"/> using the specified claims, authentication type, name claim type, and role claim type.
        /// </summary>
        /// <param name="identity">The identity from which to base the new claims identity.</param>
        /// <param name="claims">The claims with which to populate the new claims identity.</param>
        /// <param name="authenticationType">The type of authentication used.</param>
        /// <param name="nameType">The claim type to use for name claims.</param>
        /// <param name="roleType">The claim type to use for role claims.</param>
        /// <param name="groupType">The claim type to use for group claims.</param>
        /// <exception cref="InvalidOperationException" />
        public WhippetClaimsIdentity(IIdentity identity, IEnumerable<Claim> claims, string authenticationType, string nameType, string roleType, string groupType)
            : base(identity, claims, authenticationType, nameType, String.IsNullOrWhiteSpace(roleType) ? typeof(WhippetRole).AssemblyQualifiedName : roleType)
        {
            GroupClaimType = groupType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from the specified claims, authentication type, name claim type, and role claim type.
        /// </summary>
        /// <param name="claims">The claims with which to populate the new claims identity.</param>
        /// <param name="authenticationType">The type of authentication used.</param>
        /// <param name="nameType">The claim type to use for name claims.</param>
        /// <param name="roleType">The claim type to use for role claims.</param>
        /// <param name="groupType">The claim type to use for group claims.</param>
        public WhippetClaimsIdentity(IEnumerable<Claim> claims, string authenticationType, string nameType, string roleType, string groupType)
            : base(claims, authenticationType, nameType, String.IsNullOrWhiteSpace(roleType) ? typeof(WhippetRole).AssemblyQualifiedName : roleType)
        {
            GroupClaimType = groupType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from the specified authentication type, name claim type, and role claim type.
        /// </summary>
        /// <param name="authenticationType">The type of authentication used.</param>
        /// <param name="nameType">The claim type to use for name claims.</param>
        /// <param name="roleType">The claim type to use for role claims.</param>
        /// <param name="groupType">The claim type to use for group claims.</param>
        public WhippetClaimsIdentity(string authenticationType, string nameType, string roleType, string groupType)
            : base(authenticationType, nameType, String.IsNullOrWhiteSpace(roleType) ? typeof(WhippetRole).AssemblyQualifiedName : roleType)
        {
            GroupClaimType = groupType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from a serialized stream created by using <see cref="ISerializable"/>.
        /// </summary>
        /// <param name="info">The serialized data.</param>
        /// <param name="context">The context for serialization.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaimsIdentity(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from the specified claims and authentication type.
        /// </summary>
        /// <param name="claims">The claims with which to populate the new claims identity.</param>
        /// <param name="authenticationType">The type of authentication used.</param>
        public WhippetClaimsIdentity(IEnumerable<Claim> claims, string authenticationType)
            : base(claims, authenticationType)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class using the specified claims and the specified <see cref="IIdentity"/>.
        /// </summary>
        /// <param name="identity">The identity from which to base the new claims identity.</param>
        /// <param name="claims">The claims with which to populate the claims identity.</param>
        public WhippetClaimsIdentity(IIdentity identity, IEnumerable<Claim> claims)
            : base(identity, claims)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class using the specified <see cref="IIdentity"/>.
        /// </summary>
        /// <param name="identity">The identity from which to base the new claims identity.</param>
        public WhippetClaimsIdentity(IIdentity identity)
            : base(identity)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from an existing <see cref="ClaimsIdentity"/>.
        /// </summary>
        /// <param name="other">The <see cref="ClaimsIdentity"/> to copy.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetClaimsIdentity(ClaimsIdentity other)
            : base(other)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetClaimsIdentity"/> class from a serialized stream created by using <see cref="ISerializable"/>.
        /// </summary>
        /// <param name="info">The serialized data.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetClaimsIdentity(SerializationInfo info)
            : base(info)
        { }
    }
}

