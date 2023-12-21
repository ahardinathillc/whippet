using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Installer
{
    /// <summary>
    /// Provides a collection of related <see cref="InstallerAction"/> objects that are sorted by their required order of execution. This class cannot be inherited.
    /// </summary>
    public sealed class InstallerActionCollection : SortedList<int, InstallerAction>, IDictionary<int, InstallerAction>, ICollection<KeyValuePair<int, InstallerAction>>, IEnumerable<KeyValuePair<int, InstallerAction>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<int, InstallerAction>, IReadOnlyCollection<KeyValuePair<int, InstallerAction>>
    {
        /// <summary>
        /// Gets or sets the <see cref="Action{T}"/> that updates a progress reporter. 
        /// </summary>
        public Action<double> PercentComplete
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerActionCollection"/> class with no arguments.
        /// </summary>
        public InstallerActionCollection()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerActionCollection"/> class with the specified capacity.
        /// </summary>
        /// <param name="capacity">Capacity to set the collection to initially.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public InstallerActionCollection(int capacity)
            : base(capacity)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallerActionCollection"/> class with the specified <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public InstallerActionCollection(IDictionary<int, InstallerAction> dictionary)
            : base(dictionary)
        { }

        /// <summary>
        /// Executes each <see cref="InstallerAction"/> entry in the current collection.
        /// </summary>
        /// <returns><see cref="WhippetResult"/> object containing the result of the operation.</returns>
        public WhippetResult PerformInstall()
        {
            WhippetResult result = WhippetResult.Success;
            int completedStep = 0;
            
            if (Count > 0)
            {
                foreach (KeyValuePair<int, InstallerAction> action in this)
                {
                    result = action.Value.DoAction();

                    if (!result.IsSuccess)
                    {
                        break;
                    }
                    else
                    {
                        completedStep++;
                        UpdatePercentage(completedStep);
                    }
                }
            }

            return result;
        }
        
        /// <summary>
        /// Updates the percentage complete by calling <see cref="PercentComplete"/> with the calculated value if <see cref="PercentComplete"/> is not <see langword="null"/>.
        /// </summary>
        /// <param name="completedStep">Step number that was completed.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void UpdatePercentage(int completedStep)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(completedStep, nameof(completedStep));

            if (PercentComplete != null)
            {
                PercentComplete(Convert.ToDouble(completedStep) / Convert.ToDouble(Count));
            }
        }
    }
}
