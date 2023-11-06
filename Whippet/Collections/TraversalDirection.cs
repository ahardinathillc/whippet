using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Collections
{
    /// <summary>
    /// Specifies the direction in which to iterate a collection.
    /// </summary>
    public enum TraversalDirection : byte
    {
        /// <summary>
        /// The collection will be traversed from the first element to the last sequentially.
        /// </summary>
        FirstToLast = 0,
        /// <summary>
        /// The stack will be traversed from the top element to the bottom sequentially.
        /// </summary>
        TopToBottom = FirstToLast,
        /// <summary>
        /// The collection will be traversed from the last element to the first sequentially.
        /// </summary>
        LastToFirst = 1,
        /// <summary>
        /// The stack will be traversed from the last element to the top sequentially.
        /// </summary>
        BottomToTop = LastToFirst
    }
}
