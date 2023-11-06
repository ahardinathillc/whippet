using System;
using System.Linq;
using Athi.Whippet.Collections.Trees;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents an individual <see cref="TreeNode{TItem}"/> comprised of zero or more <see cref="WhippetMvcSecurityTreeEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMvcSecurityTreeNode : TreeNode<WhippetMvcSecurityTreeEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeNode"/> class with no arguments.
        /// </summary>
        private WhippetMvcSecurityTreeNode()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeNode"/> class with the specified value.
        /// </summary>
        /// <param name="value">Value to assign to the <see cref="WhippetMvcSecurityTreeNode"/>.</param>
        public WhippetMvcSecurityTreeNode(WhippetMvcSecurityTreeEntry value)
            : base(value)
        { }

        /// <summary>
        /// Creates a new tree based on the specified collection of values.
        /// </summary>
        /// <param name="values">Values to assign to each node in the tree.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects.</returns>
        /// <exception cref="TreeNodeSameIdAndParentIdException"></exception>
        public static IEnumerable<TreeNode<WhippetMvcSecurityTreeEntry>> CreateTree(IEnumerable<WhippetMvcSecurityTreeEntry> values)
        {
            return CreateTree(values, ste => ste.NodeID, ste => ste.ParentID);
        }
    }
}

