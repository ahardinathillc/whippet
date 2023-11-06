using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Collections.Trees.Extensions;

namespace Athi.Whippet.Collections.Trees
{
    /// <summary>
    /// Represents an individual node in a tree data structure.
    /// </summary>
    /// <typeparam name="TItem">Type of item stored in the <see cref="TreeNode{TItem}"/>.</typeparam>
    /// <remarks>Adapted from <a href="https://www.siepman.nl/blog/a-generic-tree-of-nodes-the-easy-way">A generic tree of nodes, the easy way!</a> by Alex Siepman.</remarks>
    public class TreeNode<TItem> : IEqualityComparer, IEqualityComparer<TItem>, IEnumerable<TItem>, IEnumerable<TreeNode<TItem>>, IEqualityComparer<TreeNode<TItem>>
    {
        private List<TreeNode<TItem>> _children;

        /// <summary>
        /// Gets the child <see cref="TreeNode{TItem}"/> located at the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the child <see cref="TreeNode{TItem}"/> to retrieve.</param>
        /// <returns><see cref="TreeNode{TItem}"/> object located at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual TreeNode<TItem> this[int index]
        {
            get
            {
                return InternalChildren[index];
            }
        }

        /// <summary>
        /// Gets the child <see cref="TreeNode{TItem}"/> objects of the current node.
        /// </summary>
        protected virtual IList<TreeNode<TItem>> InternalChildren
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<TreeNode<TItem>>();
                }

                return _children;
            }
        }

        /// <summary>
        /// Gets the root <see cref="TreeNode{TItem}"/> of the current node. This property is read-only.
        /// </summary>
        public virtual TreeNode<TItem> Root
        {
            get
            {
                return SelfAndAncestors.Last();
            }
        }

        /// <summary>
        /// Gets the current instance and immediate child nodes. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SelfAndChildren
        {
            get
            {
                return this.AsEnumerable().Concat(InternalChildren);
            }
        }

        /// <summary>
        /// Gets the current instance and all nodes that precede it. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SelfAndAncestors
        {
            get
            {
                return this.AsEnumerable().Concat(Ancestors);
            }
        }

        /// <summary>
        /// Gets the current instance and all descendant nodes. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SelfAndDescendants
        {
            get
            {
                return this.AsEnumerable().Concat(InternalChildren.SelectMany(c => c.SelfAndDescendants));
            }
        }

        /// <summary>
        /// Gets the current instance and all sibling nodes. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SelfAndSiblings
        {
            get
            {
                return IsRoot ? this.AsEnumerable() : Parent.InternalChildren;
            }
        }

        /// <summary>
        /// Gets all nodes in the hierarchy. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> All
        {
            get
            {
                return Root.SelfAndDescendants;
            }
        }

        /// <summary>
        /// Gets all nodes that are on the same hierarchy level as the current instance. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SameLevel
        {
            get
            {
                return SelfAndSameLevel.Where(Other);

            }
        }

        /// <summary>
        /// Determines which level in the hierarchy the current node resides at. This property is read-only.
        /// </summary>
        public virtual int Level
        {
            get
            {
                return Ancestors.Count();
            }
        }

        /// <summary>
        /// Indicates whether the current <see cref="TreeNode{TItem}"/> has children. This property is read-only.
        /// </summary>
        public virtual bool HasChildren
        {
            get
            {
                return Children.Any();
            }
        }

        /// <summary>
        /// Gets the current node and all nodes that reside at the same hierarchy level. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> SelfAndSameLevel
        {
            get
            {
                return GetNodesAtLevel(Level);
            }
        }

        /// <summary>
        /// Gets the current node's ancestors. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> Ancestors
        {
            get
            {
                return IsRoot ? Enumerable.Empty<TreeNode<TItem>>() : Parent.AsEnumerable().Concat(Parent.Ancestors);
            }
        }

        /// <summary>
        /// Gets the current node's descendants. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> Descendants
        {
            get
            {
                return SelfAndDescendants.Skip(1);
            }
        }

        /// <summary>
        /// Gets the current node's siblings. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> Siblings
        {
            get
            {
                return SelfAndSiblings.Where(Other);

            }
        }

        /// <summary>
        /// Gets the current node's children. This property is read-only.
        /// </summary>
        public virtual IEnumerable<TreeNode<TItem>> Children
        {
            get
            {
                return InternalChildren;
            }
        }

        /// <summary>
        /// Indicates whether the current <see cref="TreeNode{TItem}"/> is a root node. This property is read-only.
        /// </summary>
        public virtual bool IsRoot
        {
            get
            {
                return Parent == null;
            }
        }

        /// <summary>
        /// Gets the parent <see cref="TreeNode{TItem}"/> of the current instance. This property is read-only.
        /// </summary>
        public virtual TreeNode<TItem> Parent
        { get; private set; }

        /// <summary>
        /// Gets or sets the node value.
        /// </summary>
        public virtual TItem Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode{TItem}"/> class with no arguments.
        /// </summary>
        protected TreeNode()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode{TItem}"/> class with the specified value.
        /// </summary>
        /// <param name="value">Value to assign to the <see cref="TreeNode{TItem}"/>.</param>
        public TreeNode(TItem value)
            : this()
        {
            Value = value;
        }

        /// <summary>
        /// Adds the specified value as a new child <see cref="TreeNode{TItem}"/> to the current instance.
        /// </summary>
        /// <param name="value">Value to add to a new child node.</param>
        /// <param name="index">Index at which to add the child node.</param>
        /// <returns>Newly created <see cref="TreeNode{TItem}"/> object.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public virtual TreeNode<TItem> Add(TItem value, int index = -1)
        {
            TreeNode<TItem> newNode = new TreeNode<TItem>(value);
            Add(newNode, index);
            return newNode;
        }

        /// <summary>
        /// Adds the specified <see cref="TreeNode{TItem}"/> object as a child node to the current instance.
        /// </summary>
        /// <param name="childNode">Child <see cref="TreeNode{TItem}"/> object to add.</param>
        /// <param name="index">Index at which to add the child node or (-1) to append it to the end of the node list.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="TreeNodeIndexHigherThanLastItemIndexException" />
        /// <exception cref="TreeNodeCircularReferenceException" />
        public virtual void Add(TreeNode<TItem> childNode, int index = -1)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException(nameof(childNode));
            }
            else if (index < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (index >= InternalChildren.Count)
            {
                throw new TreeNodeIndexHigherThanLastItemIndexException();
            }
            else if ((Root != null && (Root.Equals(childNode))) || (childNode.SelfAndDescendants.Any(n => this.Equals(n))))
            {
                throw new TreeNodeCircularReferenceException();
            }
            else
            {
                childNode.Parent = this;

                if (index == -1)
                {
                    InternalChildren.Add(childNode);
                }
                else
                {
                    InternalChildren.Insert(index, childNode);
                }
            }
        }

        /// <summary>
        /// Appends the value as a new <see cref="TreeNode{TItem}"/> object and sets it as the first descendant of the current instance.
        /// </summary>
        /// <param name="value">Value to assign to the new node.</param>
        /// <returns>Newly created <see cref="TreeNode{TItem}"/> object.</returns>
        public virtual TreeNode<TItem> AddFirstChild(TItem value)
        {
            TreeNode<TItem> newNode = new TreeNode<TItem>(value);
            AddFirstChild(newNode);
            return newNode;
        }

        /// <summary>
        /// Appends the specified <see cref="TreeNode{TItem}"/> object as the first descendant of the current instance.
        /// </summary>
        /// <param name="childNode"><see cref="TreeNode{TItem}"/> object to set as the first child node.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TreeNodeCircularReferenceException" />
        public virtual void AddFirstChild(TreeNode<TItem> childNode)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException(nameof(childNode));
            }
            else
            {
                Add(childNode, 0);
            }
        }

        /// <summary>
        /// Appends the value as a new <see cref="TreeNode{TItem}"/> object and sets it as the first sibling of the current instance.
        /// </summary>
        /// <param name="value">Value to assign to the new node.</param>
        /// <returns>Newly created <see cref="TreeNode{TItem}"/> object.</returns>
        public virtual TreeNode<TItem> AddFirstSibling(TItem value)
        {
            TreeNode<TItem> newNode = new TreeNode<TItem>(value);
            AddFirstSibling(newNode);
            return newNode;
        }

        /// <summary>
        /// Appends the specified <see cref="TreeNode{TItem}"/> object as the first sibling of the current instance.
        /// </summary>
        /// <param name="childNode"><see cref="TreeNode{TItem}"/> object to set as the first sibling node.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TreeNodeCircularReferenceException" />
        public virtual void AddFirstSibling(TreeNode<TItem> childNode)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException(nameof(childNode));
            }
            else
            {
                Parent.AddFirstChild(childNode);
            }
        }

        /// <summary>
        /// Appends the value as a new <see cref="TreeNode{TItem}"/> object and sets it as the last sibling of the current instance.
        /// </summary>
        /// <param name="value">Value to assign to the new node.</param>
        /// <returns>Newly created <see cref="TreeNode{TItem}"/> object.</returns>
        public virtual TreeNode<TItem> AddLastSibling(TItem value)
        {
            TreeNode<TItem> newNode = new TreeNode<TItem>(value);
            AddLastSibling(newNode);
            return newNode;
        }

        /// <summary>
        /// Appends the specified <see cref="TreeNode{TItem}"/> object as the last sibling of the current instance.
        /// </summary>
        /// <param name="childNode"><see cref="TreeNode{TItem}"/> object to set as the last sibling node.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TreeNodeCircularReferenceException" />
        public virtual void AddLastSibling(TreeNode<TItem> childNode)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException(nameof(childNode));
            }
            else
            {
                Parent.Add(childNode);
            }
        }

        /// <summary>
        /// Assigns the specified value as the parent <see cref="TreeNode{TItem}"/> to the current instance.
        /// </summary>
        /// <param name="value">Value to assign to the new node.</param>
        /// <returns>Newly created <see cref="TreeNode{TItem}"/> object.</returns>
        /// <exception cref="TreeNodeParentAlreadyAssignedException" />
        public virtual TreeNode<TItem> AddParent(TItem value)
        {
            TreeNode<TItem> newNode = new TreeNode<TItem>(value);
            AddParent(newNode);
            return newNode;
        }

        /// <summary>
        /// Assigns the specified <see cref="TreeNode{TItem}"/> as the parent node.
        /// </summary>
        /// <param name="parentNode"><see cref="TreeNode{TItem}"/> object to assign as the parent node.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TreeNodeParentAlreadyAssignedException"></exception>
        public virtual void AddParent(TreeNode<TItem> parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException(nameof(parentNode));
            }
            else if (!IsRoot)
            {
                throw new TreeNodeParentAlreadyAssignedException();
            }
            else
            {
                parentNode.Add(this);
            }
        }

        /// <summary>
        /// Retrieves all nodes at the specified hierarchy level.
        /// </summary>
        /// <param name="level">Hierarhcy level to retrieve nodes.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        public virtual IEnumerable<TreeNode<TItem>> GetNodesAtLevel(int level)
        {
            return Root.GetNodesAtLevelInternal(level);
        }

        /// <summary>
        /// Retrieves all nodes at the specified hierarchy level.
        /// </summary>
        /// <param name="level">Hierarhcy level to retrieve nodes.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        protected virtual IEnumerable<TreeNode<TItem>> GetNodesAtLevelInternal(int level)
        {
            return (Level == level) ? this.AsEnumerable() : Children.SelectMany(c => c.GetNodesAtLevelInternal(level));
        }

        /// <summary>
        /// Removes the current <see cref="TreeNode{TItem}"/> from the tree.
        /// </summary>
        /// <exception cref="TreeNodeDisconnectException"></exception>
        public virtual void Disconnect()
        {
            if (IsRoot)
            {
                throw new TreeNodeDisconnectException();
            }
            else
            {
                Parent.InternalChildren.Remove(this);
                Parent = null;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return InternalChildren.Values().GetEnumerator();
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalChildren.GetEnumerator();
        }

        /// <summary>
        /// Gets an <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        public virtual IEnumerator<TreeNode<TItem>> GetEnumerator()
        {
            return InternalChildren.GetEnumerator();
        }

        /// <summary>
        /// Gets the string representation of the current value.
        /// </summary>
        /// <returns>String representation of the current value.</returns>
        public override string ToString()
        {
            return Value?.ToString();
        }

        /// <summary>
        /// Determines if the specified <see cref="TreeNode{TItem}"/> references a different instance than the current instance.
        /// </summary>
        /// <param name="node"><see cref="TreeNode{TItem}"/> object.</param>
        /// <returns><see langword="true"/> if the instances are different; otherwise, <see langword="false"/>.</returns>
        protected virtual bool Other(TreeNode<TItem> node)
        {
            return !ReferenceEquals(node, this);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            bool equals = false;

            if (obj is TreeNode<TItem>)
            {
                equals = Equals(obj as TreeNode<TItem>);
            }
            else if (obj is TItem)
            {
                equals = Equals((TItem)(obj));
            }

            return equals;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(TreeNode<TItem> obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(TItem obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        bool IEqualityComparer.Equals(object x, object y)
        {
            bool equals = false;

            if (x is TreeNode<TItem> && y is TreeNode<TItem>)
            {
                equals = Equals(x as TreeNode<TItem>, y as TreeNode<TItem>);
            }
            else if (x is TItem && y is TItem)
            {
                equals = Equals((TItem)(x), (TItem)(y));
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(TItem x, TItem y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.Equals(y);
            }

            return equals;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(TreeNode<TItem> x, TreeNode<TItem> y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = ReferenceEquals(x, y);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(TItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(TreeNode<TItem> obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Creates a new tree based on the specified collection of values.
        /// </summary>
        /// <typeparam name="TId">Type of ID that uniquely identifies each node.</typeparam>
        /// <param name="values">Values to assign to each node in the tree.</param>
        /// <param name="idSelector"><see cref="Func{T, TResult}"/> that retrieves the ID of each node.</param>
        /// <param name="parentIdSelector"><see cref="Func{T, TResult}"/> that retrieves the parent ID of each node.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects.</returns>
        /// <exception cref="TreeNodeSameIdAndParentIdException"></exception>
        public static IEnumerable<TreeNode<TItem>> CreateTree<TId>(IEnumerable<TItem> values, Func<TItem, TId> idSelector, Func<TItem, TId?> parentIdSelector)
              where TId : struct
        {
            List<TItem> valuesCache = null;
            IEnumerable<TreeNode<TItem>> nodes = null;

            TItem itemWithIdAndParentIdsTheSame = default(TItem);

            valuesCache = (values == null ? null : new List<TItem>(values));

            if (valuesCache == null || (valuesCache != null && valuesCache.Count == 0))
            {
                nodes = Enumerable.Empty<TreeNode<TItem>>();
            }
            else
            {
                itemWithIdAndParentIdsTheSame = valuesCache.FirstOrDefault(v => IsSameId(idSelector(v), parentIdSelector(v)));

                if (itemWithIdAndParentIdsTheSame != null)
                {
                    throw new TreeNodeSameIdAndParentIdException(itemWithIdAndParentIdsTheSame);
                }
                else
                {
                    nodes = valuesCache.Select(v => new TreeNode<TItem>(v));
                }
            }

            return CreateTree(nodes, idSelector, parentIdSelector);
        }

        /// <summary>
        /// Creates a new tree based on the specified collection of values.
        /// </summary>
        /// <typeparam name="TId">Type of ID that uniquely identifies each node.</typeparam>
        /// <param name="rootNodes"><see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects that serve as the root nodes.</param>
        /// <param name="idSelector"><see cref="Func{T, TResult}"/> that retrieves the ID of each node.</param>
        /// <param name="parentIdSelector"><see cref="Func{T, TResult}"/> that retrieves the parent ID of each node.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="TreeNode{TItem}"/> objects.</returns>
        /// <exception cref="TreeNodeSameIdAndParentIdException"></exception>
        public static IEnumerable<TreeNode<TItem>> CreateTree<TId>(IEnumerable<TreeNode<TItem>> rootNodes, Func<TItem, TId> idSelector, Func<TItem, TId?> parentIdSelector)
            where TId : struct

        {
            List<TreeNode<TItem>> rootNodesCache = null;
            List<TreeNode<TItem>> duplicates = null;

            rootNodesCache = new List<TreeNode<TItem>>(rootNodes);
            duplicates = rootNodesCache.Duplicates(n => n).ToList();

            TId? parentId = null;

            TreeNode<TItem> parent = null;

            if (duplicates.Any())
            {
                throw new TreeNodeDuplicateKeysDetectedException(duplicates.Count, duplicates[0]);
            }
            else
            {
                foreach (TreeNode<TItem> rootNode in rootNodesCache)
                {
                    parentId = parentIdSelector(rootNode.Value);
                    parent = rootNodesCache.FirstOrDefault(n => IsSameId(idSelector(n.Value), parentId));

                    if (parent != null)
                    {
                        parent.Add(rootNode);
                    }
                    else if (parentId != null)
                    {
                        throw new TreeNodeParentIdNotFoundException(parentId.Value);
                    }
                }
            }

            return rootNodesCache.Where(n => n.IsRoot);
        }

        /// <summary>
        /// Determines if the two identifiers are equal.
        /// </summary>
        /// <typeparam name="TId">Type of identifier to compare.</typeparam>
        /// <param name="id">First ID to compare.</param>
        /// <param name="parentId">Second ID to compare.</param>
        /// <returns><see langword="true"/> if the values are equal; otherwise, <see langword="false"/>.</returns>
        private static bool IsSameId<TId>(TId id, TId? parentId)
            where TId : struct
        {
            return parentId != null && id.Equals(parentId.Value);
        }

        public static bool operator ==(TreeNode<TItem> x, TreeNode<TItem> y)
        {
            bool equals = (x is null && y is null);

            if (!equals && !(x is null) && !(y is null))
            {
                equals = x.Equals(y);
            }

            return equals;
        }

        public static bool operator !=(TreeNode<TItem> x, TreeNode<TItem> y)
        {
            bool notEquals = false;

            if (!(x is null) && !(y is null))
            {
                notEquals = !x.Equals(y);
            }
            else if (((x is null) && !(y is null)) || (!(x is null) && (y is null)))
            {
                notEquals = true;
            }

            return notEquals;
        }
    }
}

