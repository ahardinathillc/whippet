using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Provides support to <see cref="Controller"/> objects for providing a current user instance.
    /// </summary>
    /// <typeparam name="TController">Type of <see cref="Controller"/> being supported.</typeparam>
    public interface IWhippetSecureController<TController> : IActionFilter, IFilterMetadata, IAsyncActionFilter, IDisposable where TController : Controller
    {
        /// <summary>
        /// Gets the current authenticated <see cref="IWhippetUser"/>. This property is read-only.
        /// </summary>
        IWhippetUser CurrentUser
        { get; }

        /// <summary>
        /// Gets the current <see cref="IWhippetUser"/> ID. This property is read-only.
        /// </summary>
        Guid? CurrentUserID
        { get; }

        /// <summary>
        /// Gets the unique ID of the <see cref="IWhippetSecureController{TController}"/>. This property is read-only.
        /// </summary>
        Guid ControllerID
        { get; }

        /// <summary>
        /// Gets a <see cref="WhippetViewProfileCollection"/> collection of views that the controller handles indexed by their respective IDs. This property is read-only.
        /// </summary>
        WhippetViewProfileCollection ViewIndex
        { get; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by a <see cref="WhippetViewSecurityCategory"/> with each associated <see cref="WhippetViewProfile"/> that belongs to that category. This property is read-only.
        /// </summary>
        IReadOnlyDictionary<WhippetViewSecurityCategory, IEnumerable<WhippetViewProfile>> ViewCategories
        { get; }

        /// <summary>
        /// Gets an <see cref="WhippetMvcSecurityPermissionCollection.WhippetMvcSecurityPermissionReadOnlyCollection"/> collection of available <see cref="WhippetMvcSecurityPermission"/> objects for the available views in the controller. This property is read-only. This property must be overridden.
        /// </summary>
        WhippetMvcSecurityPermissionCollection.WhippetMvcSecurityPermissionReadOnlyCollection AvailablePermissions
        { get; }

        /// <summary>
        /// Authenticates the current request. 
        /// </summary>
        /// <param name="view">ID of the view to render upon successful authentication.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authentication.</param>
        /// <param name="customAuthenticatedAction">Custom <see cref="IActionResult"/> function to execute (if any) on successful authentication.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authentication was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        IActionResult Authenticate(Guid view, object viewModel, Func<Guid, object, IActionResult> customAuthenticatedAction = null, Func<IActionResult> customForbidAction = null);

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials using the default tenant.
        /// </summary>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="view">ID of the view to render upon successful authorization.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authorization.</param>
        /// <param name="customAuthorizationAction">Custom <see cref="IActionResult"/> function to execute (if any) to perform authorization.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authorization was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        IActionResult Authorize(IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null);

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to authorize the user's credentials against.</param>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="view">ID of the view to render upon successful authorization.</param>
        /// <param name="viewModel">View model to assign to the view upon successful authorization.</param>
        /// <param name="customAuthorizationAction">Custom <see cref="IActionResult"/> function to execute (if any) to perform authorization.</param>
        /// <param name="customForbidAction">Custom <see cref="IActionResult"/> function to execute (if any) when authorization was unsuccessful.</param>
        /// <returns><see cref="IActionResult"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        IActionResult Authorize(IWhippetTenant tenant, IWhippetUser currentUser, Guid view, object viewModel, Func<IWhippetTenant, IWhippetUser, Guid, object, IActionResult> customAuthorizationAction = null, Func<IActionResult> customForbidAction = null);

        /// <summary>
        /// Authorizes the current request based on the specified <see cref="IWhippetUser"/> object's credentials for an endpoint action using the default tenant.
        /// </summary>
        /// <param name="currentUser">Current <see cref="IWhippetUser"/> that is logged in.</param>
        /// <param name="endpoint">ID of the endpoint to execute upon successful authorization.</param>
        /// <param name="permissions">Permission(s) required by the endpoint in order to execute.</param>
        /// <param name="customAuthorizationAction">Custom function to execute (if any) to perform authorization.</param>
        /// <returns><see cref="Tuple{T1, T2}"/> containing a <see cref="Boolean"/> value indicating if authorization was successful and the <see cref="WhippetJsonResult"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Tuple<bool, WhippetJsonResult> AuthorizeEndpoint(IWhippetUser currentUser, Guid endpoint, WhippetPermissionType permissions, Func<IWhippetTenant, IWhippetUser, Guid, bool> customAuthorizationAction = null);

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
        Tuple<bool, WhippetJsonResult> AuthorizeEndpoint(IWhippetTenant tenant, IWhippetUser currentUser, Guid endpoint, WhippetPermissionType permissions, Func<IWhippetTenant, IWhippetUser, Guid, bool> customAuthorizationAction = null);
    }
}

