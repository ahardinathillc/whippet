using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NHibernate;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Web.Mvc.Security;

namespace Athi.Whippet.Jobs.Web.Mvc
{
    /// <summary>
    /// Base class for all <see cref="IJob"/> controllers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TController"><see cref="Controller"/> type.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type that the controller handles.</typeparam>
    public abstract class JobControllerBase<TController, TJob> : WhippetSecureNHibernateController<TController>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the current authenticated <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        public new IWhippetUser CurrentUser
        { get; private set; }

        /// <summary>
        /// Handles reloading of the current <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        protected virtual Func<WhippetResultContainer<IWhippetUser>> ReloadCurrentUserDelegate
        { get; private set; }

        /// <summary>
        /// Handles authorization of an <see cref="IWhippetUser"/> with the current <see cref="IWhippetTenant"/>. This property is read-only.
        /// </summary>
        protected virtual Func<IWhippetTenant, IWhippetUser, Guid, object, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult>, Func<IActionResult>, Task<IActionResult>> AuthorizeDelegate
        { get; private set; }

        /// <summary>
        /// Handles authentication of an <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        protected virtual Func<Tuple<string, object>, Func<Guid, object, IActionResult>, Func<IActionResult>, IActionResult> AuthenticateDelegate
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobControllerBase{TController, TJob}"/> class with no arguments.
        /// </summary>
        private JobControllerBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobControllerBase{TController, TJob}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        private JobControllerBase(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null)
            : this(logger, configuration, tokenService, sessionFactory, externalMappings, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobControllerBase{TController, TJob}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        /// <param name="currentUser">Current authenticated user, if any.</param>
        private JobControllerBase(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null, IWhippetUser currentUser = null)
            : base(logger, configuration, tokenService, sessionFactory, externalMappings)
        {
            CurrentUser = currentUser;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobControllerBase{TController, TJob}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="currentTenant">Current <see cref="IWhippetTenant"/> that provides a context for the current controller.</param>
        /// <param name="reloadCurrentUserDelegate">Delegate that handles reloading of the currently logged in <see cref="IWhippetUser"/>.</param>
        /// <param name="authorizeCurrentTenantDelegate">Delegate that handles authorization using the current <see cref="IWhippetTenant"/>.</param>
        /// <param name="authenticateDelegate">Delegate that handles authentication of the currently logged in <see cref="IWhippetUser"/>.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        /// <param name="currentUser">Current authenticated user, if any.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JobControllerBase(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, IWhippetTenant currentTenant, Func<WhippetResultContainer<IWhippetUser>> reloadCurrentUserDelegate, Func<IWhippetTenant, IWhippetUser, Guid, object, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult>, Func<IActionResult>, Task<IActionResult>> authorizeCurrentTenantDelegate, Func<Tuple<string, object>, Func<Guid, object, IActionResult>, Func<IActionResult>, IActionResult> authenticateDelegate, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null, IWhippetUser currentUser = null)
            : this(logger, configuration, tokenService, sessionFactory, externalMappings, currentUser)
        {
            if (currentTenant == null)
            {
                throw new ArgumentNullException(nameof(currentTenant));
            }
            else if (reloadCurrentUserDelegate == null)
            {
                throw new ArgumentNullException(nameof(reloadCurrentUserDelegate));
            }
            else if (authorizeCurrentTenantDelegate == null)
            {
                throw new ArgumentNullException(nameof(authorizeCurrentTenantDelegate));
            }
            else if (authenticateDelegate == null)
            {
                throw new ArgumentNullException(nameof(authenticateDelegate));
            }
            else
            {
                CurrentTenant = currentTenant;
                ReloadCurrentUserDelegate = reloadCurrentUserDelegate;
                AuthorizeDelegate = authorizeCurrentTenantDelegate;
                AuthenticateDelegate = authenticateDelegate;
            }
        }

        /// <summary>
        /// Reloads the current <see cref="IWhippetUser"/> based on the current authentication token against the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        protected override WhippetResultContainer<IWhippetUser> ReloadCurrentUserInternal()
        {
            return ReloadCurrentUserDelegate();
        }

        /// <summary>
        /// Authenticates the current request. This method must be overridden.
        /// </summary>
        /// <param name="viewViewModel"><see cref="Tuple{T1, T2}"/> containing the name of the view to render and associated view model (if any).</param>
        /// <param name="customAuthenticatedAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authentication.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authentication was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        protected override IActionResult Authenticate(Tuple<string, object> viewViewModel = null, Func<Guid, object, IActionResult> customAuthenticatedAction = null, Func<IActionResult> customForbidAction = null)
        {
            return AuthenticateDelegate(viewViewModel, customAuthenticatedAction, customForbidAction);
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
        protected override async Task<IActionResult> AuthorizeAsync(IWhippetTenant tenant, IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null)
        {
            return await AuthorizeDelegate(tenant, currentUser, view, viewModel, customAuthorizationAction, customForbidAction);
        }
    }
}

