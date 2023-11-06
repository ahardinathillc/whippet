using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet
{
    /// <summary>
    /// Manages <see cref="ProgressDelegate"/> invocation by providing internal boilerplate code.
    /// </summary>
    public class ProgressDelegateManager
    {
        /// <summary>
        /// Gets the initial starting position of the <see cref="ProgressDelegate"/>. This property is read-only.
        /// </summary>
        public int InitialIndex
        { get; private set; }

        /// <summary>
        /// Total number of items that the <see cref="ProgressDelegate"/> is expecting. This property is read-only.
        /// </summary>
        public int TotalItems
        { get; private set; }

        /// <summary>
        /// Current position of the <see cref="ProgressDelegate"/>. This property is read-only.
        /// </summary>
        public int CurrentIndex
        { get; private set; }

        /// <summary>
        /// The <see cref="ProgressDelegate"/> to invoke. This property is read-only.s
        /// </summary>
        protected ProgressDelegate Delegate
        { get; private set; }

        /// <summary>
        /// Indicates whether the <see cref="Delegate"/> has a valid <see cref="ProgressDelegate"/> assigned to it. This property is read-only.
        /// </summary>
        public bool DelegateConfigured
        {
            get
            {
                return Delegate != null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressDelegateManager"/> class with no arguments.
        /// </summary>
        protected ProgressDelegateManager()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressDelegateManager"/> class.
        /// </summary>
        /// <param name="initialIndex">Initial starting position of the <see cref="ProgressDelegate"/>.</param>
        /// <param name="totalItems">Total number of items the <see cref="ProgressDelegate"/> is expecting.</param>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> to invoke.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public ProgressDelegateManager(int initialIndex, int totalItems, ProgressDelegate pDelegate)
            : this()
        {
            if (pDelegate != null)
            {
                if (initialIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(initialIndex));
                }
                else if (totalItems < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(totalItems));
                }
                else
                {
                    InitialIndex = initialIndex;
                    TotalItems = totalItems;
                    Delegate = pDelegate;
                }
            }
        }

        /// <summary>
        /// Advances the <see cref="ProgressDelegate"/> status with the specified message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        /// <param name="severity"><see cref="WhippetResultSeverity"/> of the operation.</param>
        public virtual void Advance(string message = null, WhippetResultSeverity? severity = null)
        {
            if (DelegateConfigured)
            {
                Advance(1, message, severity);
            }
        }

        /// <summary>
        /// Advances the <see cref="ProgressDelegate"/> status by a given amount with the specified message.
        /// </summary>
        /// <param name="amount">Amount to advance the <see cref="ProgressDelegate"/> by.</param>
        /// <param name="message">Message to dispaly.</param>
        /// <param name="severity"><see cref="WhippetResultSeverity"/> of the operation.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual void Advance(int amount, string message = null, WhippetResultSeverity? severity = null)
        {
            if (DelegateConfigured)
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
                else
                {
                    if ((amount + CurrentIndex) >= (TotalItems - 1))
                    {
                        CurrentIndex = TotalItems - 1;
                    }
                    else
                    {
                        CurrentIndex = CurrentIndex + amount;
                    }

                    UpdateProgress(CurrentIndex, TotalItems, message, severity, Delegate);
                }
            }
        }

        /// <summary>
        /// Updates the target <see cref="ProgressDelegate"/>.
        /// </summary>
        /// <param name="currentIndex">Current zero-based index of the <see cref="ProgressDelegate"/>.</param>
        /// <param name="totalItems">Total number of items the <see cref="ProgressDelegate"/> is configured for.</param>
        /// <param name="message">Message to display.</param>
        /// <param name="severity"><see cref="WhippetResultSeverity"/> of the operation.</param>
        /// <param name="pDelegate"><see cref="ProgressDelegate"/> to invoke.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        protected virtual void UpdateProgress(int currentIndex, int totalItems, string message, WhippetResultSeverity? severity, ProgressDelegate pDelegate)
        {
            if(currentIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentIndex));
            }
            else if(totalItems < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(totalItems));
            }
            if(pDelegate != null)
            {
                decimal percentage = Convert.ToDecimal(currentIndex) / Convert.ToDecimal(totalItems);
                pDelegate(Convert.ToInt32(percentage * 100), message, severity);
            }
        }
    }
}
