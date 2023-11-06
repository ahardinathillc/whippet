using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ISessionFactory = NHibernate.ISessionFactory;
using Athi.Whippet.Security;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// A base class for an MVC controller with view support in Whippet. This type of controller supports handling of a user instance. This class must be inherited.
    /// </summary>
    /// <typeparam name="TController"><see cref="Controller"/> type.</typeparam>
    public abstract class WhippetSecureNHibernateController<TController> : WhippetNHibernateController<TController>, IWhippetSecureController<WhippetSecureNHibernateController<TController>>
    {
        /// <summary>
        /// Gets the current authenticated <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        public virtual IWhippetUser CurrentUser
        { get; private set; }

        /// <summary>
        /// Gets the current <see cref="IWhippetUser"/> ID. This property is read-only.
        /// </summary>
        public virtual Guid? CurrentUserID
        {
            get
            {
                Guid? value = null;

                if (CurrentUser != null)
                {
                    value = CurrentUser.ID;
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the unique ID of the <see cref="IWhippetSecureController{TController}"/>. This property is read-only. This property must be overridden.
        /// </summary>
        public abstract Guid ControllerID
        { get; }

        /// <summary>
        /// Gets a <see cref="WhippetViewProfileCollection"/> collection of views that the controller handles indexed by their respective IDs. This property is read-only.
        /// </summary>
        public abstract WhippetViewProfileCollection ViewIndex
        { get; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by a <see cref="WhippetViewSecurityCategory"/> with each associated <see cref="WhippetViewProfile"/> that belongs to that category. This property is read-only. This property must be overridden.
        /// </summary>
        public abstract IReadOnlyDictionary<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>> ViewCategories
        { get; }

        /// <summary>
        /// Gets an <see cref="WhippetMvcSecurityPermissionCollection.WhippetMvcSecurityPermissionReadOnlyCollection"/> collection of available <see cref="WhippetMvcSecurityPermission"/> objects for the available views in the controller. This property is read-only. This property must be overridden.
        /// </summary>
        public abstract WhippetMvcSecurityPermissionCollection.WhippetMvcSecurityPermissionReadOnlyCollection AvailablePermissions
        { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureNHibernateController{TController}"/> class with no arguments.
        /// </summary>
        protected WhippetSecureNHibernateController()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureNHibernateController{TController}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        protected WhippetSecureNHibernateController(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null)
            : this(logger, configuration, tokenService, sessionFactory, externalMappings, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSecureNHibernateController{TController}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        /// <param name="currentUser">Current authenticated user, if any.</param>
        protected WhippetSecureNHibernateController(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null, IWhippetUser currentUser = null)
            : base(logger, configuration, tokenService, sessionFactory, externalMappings)
        {
            CurrentUser = currentUser;
        }

        /// <summary>
        /// Authenticates the current request. 
        /// </summary>
        /// <param name="view">ID of the view to render upon successful authentication.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authentication.</param>
        /// <param name="customAuthenticatedAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authentication.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authentication was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        public virtual IActionResult Authenticate(Guid view, object viewModel, Func<Guid, object, IActionResult> customAuthenticatedAction = null, Func<IActionResult> customForbidAction = null)
        {
            return Authenticate(CreateViewViewModelTuple(ViewIndex[view].Filename, viewModel), customAuthenticatedAction, customForbidAction);
        }

        /// <summary>
        /// Authenticates the current request. This method must be overridden.
        /// </summary>
        /// <param name="viewViewModel"><see cref="Tuple{T1, T2}"/> containing the name of the view to render and associated view model (if any).</param>
        /// <param name="customAuthenticatedAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authentication.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authentication was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        protected abstract IActionResult Authenticate(Tuple<string, object> viewViewModel = null, Func<Guid, object, IActionResult> customAuthenticatedAction = null, Func<IActionResult> customForbidAction = null);

        /// <summary>
        /// Reloads <see cref="CurrentUser"/> based on the current authentication token against the data store.
        /// </summary>
        /// <param name="throwExceptionInsteadOfResult">If <see langword="true"/>, will raise an <see cref="Exception"/> in the event that the current user fails to reload instead of returning a <see cref="WhippetResult"/> object.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        public WhippetResult ReloadCurrentUser(bool throwExceptionInsteadOfResult = false)
        {
            WhippetResultContainer<IWhippetUser> result = ReloadCurrentUserInternal();

            if (result.IsSuccess)
            {
                CurrentUser = result.Item;
            }

            return result;
        }

        /// <summary>
        /// Reloads the current <see cref="IWhippetUser"/> based on the current authentication token against the data store. This method must be overridden.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        protected abstract WhippetResultContainer<IWhippetUser> ReloadCurrentUserInternal();

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials using the default tenant.
        /// </summary>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="view">ID of the view to render upon successful authorization.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authentication.</param>
        /// <param name="customAuthorizationAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authorization.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authorization was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IActionResult Authorize(IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser));
            }
            else
            {
                return Authorize(CurrentTenant, CurrentUser, view, viewModel, customAuthorizationAction, customForbidAction);
            }
        }

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to authorize the user's credentials against.</param>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="view">ID of the view to render upon successful authorization.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authentication.</param>
        /// <param name="customAuthorizationAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authorization.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authorization was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IActionResult Authorize(IWhippetTenant tenant, IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser));
            }
            else
            {
                return Task.Run(() => AuthorizeAsync(tenant, currentUser, view, viewModel, customAuthorizationAction, customForbidAction)).Result;
            }
        }

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials. This method must be overridden.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to authorize the user's credentials against.</param>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="view">ID of the view to render upon successful authorization.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authentication.</param>
        /// <param name="customAuthorizationAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authorization.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authorization was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected abstract Task<IActionResult> AuthorizeAsync(IWhippetTenant tenant, IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null);

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials for an endpoint action using the default tenant.
        /// </summary>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="endpoint">ID of the endpoint to execute upon successful authorization.</param>
        /// <param name="permissions">Permission(s) required by the endpoint in order to execute.</param>
        /// <param name="customAuthorizationAction">Custom function to execute (if any) to perform authorization.</param>
        /// <returns><see cref="Tuple{T1, T2}"/> containing a <see cref="Boolean"/> value indicating if authorization was successful and the <see cref="WhippetJsonResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Tuple<bool, WhippetJsonResult> AuthorizeEndpoint(IWhippetUser currentUser, Guid endpoint, WhippetPermissionType permissions, Func<IWhippetTenant, IWhippetUser, Guid, bool> customAuthorizationAction = null)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser));
            }
            else
            {
                return AuthorizeEndpoint(CurrentTenant, currentUser, endpoint, permissions, customAuthorizationAction);
            }
        }

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials for an endpoint action.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to authorize the user's credentials against.</param>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="endpoint">ID of the endpoint to execute upon successful authorization.</param>
        /// <param name="permissions">Permission(s) required by the endpoint in order to execute.</param>
        /// <param name="customAuthorizationAction">Custom function to execute (if any) to perform authorization.</param>
        /// <returns><see cref="Tuple{T1, T2}"/> containing a <see cref="Boolean"/> value indicating if authorization was successful and the <see cref="WhippetJsonResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Tuple<bool, WhippetJsonResult> AuthorizeEndpoint(IWhippetTenant tenant, IWhippetUser currentUser, Guid endpoint, WhippetPermissionType permissions, Func<IWhippetTenant, IWhippetUser, Guid, bool> customAuthorizationAction = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser));
            }
            else
            {
                return AuthorizeEndpoint(CurrentTenant, currentUser, endpoint, permissions, customAuthorizationAction);
            }
        }

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials for an endpoint action. This method must be overridden.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to authorize the user's credentials against.</param>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="endpoint">ID of the endpoint to execute upon successful authorization.</param>
        /// <param name="permissions">Permission(s) required by the endpoint in order to execute.</param>
        /// <param name="customAuthorizationAction">Custom function to execute (if any) to perform authorization.</param>
        /// <returns><see cref="Tuple{T1, T2}"/> containing a <see cref="Boolean"/> value indicating if authorization was successful and the <see cref="WhippetJsonResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected abstract Task<Tuple<bool, WhippetJsonResult>> AuthorizeEndpointAsync(IWhippetTenant tenant, IWhippetUser currentUser, Guid endpoint, WhippetPermissionType permissions, Func<IWhippetTenant, IWhippetUser, Guid, bool> customAuthorizationAction = null);
    }
}
