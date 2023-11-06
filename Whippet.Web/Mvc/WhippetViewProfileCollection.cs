using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// Represents a read-only collection of unique <see cref="WhippetViewProfile"/> objects indexed by their respective controller ID. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetViewProfileCollection : ReadOnlyCollection<WhippetViewProfile>
    {
        private static WhippetViewProfileCollection _empty;

        /// <summary>
        /// Gets an empty <see cref="WhippetViewProfileCollection"/> instance. This property is read-only.
        /// </summary>
        public static WhippetViewProfileCollection Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new WhippetViewProfileCollection();
                }

                return _empty;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetViewProfile"/> object with the specified ID. This property is read-only.
        /// </summary>
        /// <param name="viewId">View ID of the view to retrieve.</param>
        /// <returns><see cref="WhippetViewProfile"/> object or <see langword="null"/> if no corresponding entry was found.</returns>
        public WhippetViewProfile this[Guid viewId]
        {
            get
            {
                return (from svp in this where svp.ViewID == viewId select svp).FirstOrDefault();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewProfileCollection"/> class with no arguments.
        /// </summary>
        private WhippetViewProfileCollection()
            : base(new List<WhippetViewProfile>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewProfileCollection"/> class with the specified collection of <see cref="WhippetViewProfile"/> objects.
        /// </summary>
        /// <param name="profiles"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetViewProfile"/> objects.</param>
        public WhippetViewProfileCollection(IEnumerable<WhippetViewProfile> profiles)
            : base(profiles == null ? new List<WhippetViewProfile>() : profiles.Distinct().ToList())
        { }

        /// <summary>
        /// Filters the results of the current collection and returns a new <see cref="WhippetViewProfileCollection"/> that contains only entries that belong to the specified controller ID.
        /// </summary>
        /// <param name="controllerId">Controller ID to filter by.</param>
        /// <returns><see cref="WhippetViewProfileCollection"/> object.</returns>
        public WhippetViewProfileCollection GetForController(Guid controllerId)
        {
            WhippetViewProfileCollection results = new WhippetViewProfileCollection();

            if (Count > 0)
            {
                try
                {
                    results = new WhippetViewProfileCollection(this.Where(svp => svp.ControllerID == controllerId));
                }
                catch
                {
                    results = new WhippetViewProfileCollection();
                }
            }

            return results;
        }

        /// <summary>
        /// Concatenates the two <see cref="WhippetViewProfileCollection"/> objects into a new <see cref="WhippetViewProfileCollection"/> instance.
        /// </summary>
        /// <param name="x">First <see cref="WhippetViewProfileCollection"/> object.</param>
        /// <param name="y">Second <see cref="WhippetViewProfileCollection"/> object.</param>
        /// <returns><see cref="WhippetViewProfileCollection"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WhippetViewProfileCollection Concat(WhippetViewProfileCollection x, WhippetViewProfileCollection y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            else if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            else
            {
                return new WhippetViewProfileCollection(x.Concat(y));
            }
        }
    }
}

