using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Base class for all individual actions that are executed by an <see cref="InstallerBase"/> instance. This class must be inherited.
    /// </summary>
    public abstract class InstallerActionBase : IInstallerAction
    {
        /// <summary>
        /// Indicates whether the action supports asynchronous execution. This property must be overridden. This property is read-only.
        /// </summary>
        public abstract bool SupportsAsync
        { get; }

        /// <summary>
        /// Gets a description of the current action being performed. This property is read-only.
        /// </summary>
        public virtual string Action
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerActionBase"/> class with no arguments.
        /// </summary>
        private InstallerActionBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerActionBase"/> class with a description of the current action that is to be performed.
        /// </summary>
        /// <param name="action">Description of the current action that is to be performed.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected InstallerActionBase(string action)
            : this()
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(action);
            Action = action;
        }

        /// <summary>
        /// Executes the current action with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public abstract WhippetResultContainer<object> Execute(params object[] args);

        /// <summary>
        /// When overridden in a derived class, executes the current action asynchronously with the specified parameters. If not overridden, this method returns <see langword="null"/>.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual Task<WhippetResultContainer<object>> ExecuteAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken))
        {
            return null;
        }

        /// <summary>
        /// Searches the specified <see cref="IEnumerable{T}"/> collection of arguments for the specified parameter type and the required number of occurrences.
        /// </summary>
        /// <param name="parameterType">Type of parameter to search for.</param>
        /// <param name="arguments">Arguments that were passed to the installer action.</param>
        /// <param name="count">Minimum required number of parameters of the type specified in <paramref name="parameterType"/>.</param>
        /// <exception cref="Exception"></exception>
        protected virtual void VerifyParameters(Type parameterType, IEnumerable<object> arguments, int count = 1)
        {
            ArgumentNullException.ThrowIfNull(parameterType);
            ArgumentNullException.ThrowIfNull(arguments);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

            int parameterCount = 0;
            
            foreach (object arg in arguments)
            {
                if (arg != null)
                {
                    if (arg.GetType().Equals(parameterType))
                    {
                        parameterCount++;
                    }
                }
            }

            if (parameterCount < count)
            {
                throw new Exception("One or more arguments of type " + parameterType.FullName + " is missing.");
            }
        }
    }
}
