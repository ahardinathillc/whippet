using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Security.Claims;
using Athi.Whippet.Security.IdentityModel.Tokens;
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Principal
{
    /// <summary>
    /// Represents a <see cref="WhippetUser"/> that contains the associated <see cref="WhippetRole"/> and <see cref="WhippetGroup"/> assignments.
    /// </summary>
    public class WhippetIdentity : GenericIdentity, IIdentity
    {
        private readonly IWhippetTenant _Tenant;

        /// <summary>
        /// Indicates whether the identity has been authenticated based on the <see cref="IWhippetToken"/> that was provided when the object was created. This property is read-only.
        /// </summary>
        public override bool IsAuthenticated
        {
            get
            {
                return (Token != null) && (Token.Expires.ToDateTimeUtc() > DateTime.Now.ToUniversalTime());
            }
        }

        /// <summary>
        /// Gets or sets the internal <see cref="IWhippetToken"/>.
        /// </summary>
        private IWhippetToken Token
        { get; set; }

        /// <summary>
        /// Gets the <see cref="IWhippetTenant"/> that the <see cref="WhippetIdentity"/> is associated with. This property is read-only.
        /// </summary>
        public IWhippetTenant Tenant
        {
            get
            {
                return _Tenant;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIdentity"/> class by using the specified <see cref="GenericIdentity"/> object.
        /// </summary>
        /// <param name="identity">The object from which to construct the new instance of <see cref="WhippetIdentity"/>.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="WhippetIdentity"/> is associated with.</param>
        /// <param name="token"><see cref="IWhippetToken"/> that was granted to the identity upon successful authentication.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetIdentity(GenericIdentity identity, IWhippetTenant tenant, IWhippetToken token = null)
            : base(identity)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                _Tenant = tenant;
                Token = token;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIdentity"/> class representing the user with the specified name.
        /// </summary>
        /// <param name="name">The name of the user on whose behalf the code is running.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="WhippetIdentity"/> is associated with.</param>
        /// <param name="token"><see cref="IWhippetToken"/> that was granted to the identity upon successful authentication.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetIdentity(string name, IWhippetTenant tenant, IWhippetToken token = null)
            : base(name)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                _Tenant = tenant;
                Token = token;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIdentity"/> class representing the user with the specified name and authentication type.
        /// </summary>
        /// <param name="name">The name of the user on whose behalf the code is running.</param>
        /// <param name="type">The type of authentication used to identify the user.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="WhippetIdentity"/> is associated with.</param>
        /// <param name="token"><see cref="IWhippetToken"/> that was granted to the identity upon successful authentication.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetIdentity(string name, string type, IWhippetTenant tenant, IWhippetToken token = null)
            : base(name, type)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                _Tenant = tenant;
                Token = token;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIdentity"/> class representing the user with the specified <see cref="IWhippetUser"/> instance.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> instance containing the name of the user on whose behalf the code is running.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="WhippetIdentity"/> is associated with.</param>
        /// <param name="token"><see cref="IWhippetToken"/> that was granted to the identity upon successful authentication.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetIdentity(IWhippetUser user, IWhippetTenant tenant, IWhippetToken token = null)
            : this(user?.UserName, tenant, token)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}

