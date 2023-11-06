using System;
using System.Collections.Generic;
using System.Linq;

namespace Athi.Whippet.Collections.Trees.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="TreeNode{TItem}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class TreeNodeExtensions
    {
        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> collection of all values stored in the specified <see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects.
        /// </summary>
        /// <typeparam name="T">Type of object stored in each <see cref="TreeNode{TItem}"/> instance.</typeparam>
        /// <param name="nodes"><see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection.</returns>
        public static IEnumerable<T> Values<T>(this IEnumerable<TreeNode<T>> nodes)
        {
            return (nodes == null) ? null : nodes.Select(n => n.Value);
        }
    }
}

