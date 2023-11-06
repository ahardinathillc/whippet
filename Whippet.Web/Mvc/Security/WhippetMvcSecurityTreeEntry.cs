using System;
using System.Diagnostics.CodeAnalysis;
using Athi.Whippet.Collections.Trees;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents an individual entry within a security tree. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMvcSecurityTreeEntry : IEqualityComparer<WhippetMvcSecurityTreeEntry>, IEquatable<WhippetMvcSecurityTreeEntry>
    {
        /// <summary>
        /// Gets the entry name. This property is read-only.
        /// </summary>
        public string EntryName
        { get; private set; }

        /// <summary>
        /// Gets the parent <see cref="WhippetMvcSecurityTreeEntry"/> (if any). This property is read-only.
        /// </summary>
        public WhippetMvcSecurityTreeEntry Parent
        { get; private set; }

        /// <summary>
        /// Gets extra data that is applied to the "data" attribute of the node upon rendering (if any). This property is read-only.
        /// </summary>
        public string Data
        { get; private set; }

        /// <summary>
        /// Gets the unique node ID of the <see cref="Parent"/> node. This property is read-only.
        /// </summary>
        internal Guid? ParentID
        {
            get
            {
                return (Parent == null) ? null : Parent.NodeID;
            }
        }

        /// <summary>
        /// Gets the unique node ID. This property is read-only.
        /// </summary>
        public Guid NodeID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntry"/> class with no arguments.
        /// </summary>
        private WhippetMvcSecurityTreeEntry()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntry"/> class with the specified ID and categeory name.
        /// </summary>
        /// <param name="id">Unique ID of the node.</param>
        /// <param name="name">Entry name.</param>
        /// <param name="parent">Parent <see cref="WhippetMvcSecurityTreeEntry"/> object (if any).</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMvcSecurityTreeEntry(Guid id, string name, WhippetMvcSecurityTreeEntry parent = null)
            : this(id, name, null, parent)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntry"/> class with the specified ID and categeory name.
        /// </summary>
        /// <param name="id">Unique ID of the node.</param>
        /// <param name="name">Entry name.</param>
        /// <param name="data">Extra data that is applied to the "data" attribte of the node upon rendering.</param>
        /// <param name="parent">Parent <see cref="WhippetMvcSecurityTreeEntry"/> object (if any).</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMvcSecurityTreeEntry(Guid id, string name, string data, WhippetMvcSecurityTreeEntry parent = null)
            : this()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                EntryName = name;
                NodeID = id;
                Parent = parent;
                Data = data;
            }
        }

        /// <summary>
        /// Compares the specified object to the current instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as WhippetMvcSecurityTreeEntry);
        }

        /// <summary>
        /// Compares the specified object to the current instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetMvcSecurityTreeEntry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the specified objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetMvcSecurityTreeEntry x, WhippetMvcSecurityTreeEntry y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.NodeID.Equals(y.NodeID)
                    && String.Equals(x.EntryName, y.EntryName, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Parent == null && y.Parent == null) || ((x.Parent != null) && (y.Parent != null) && x.Parent.Equals(y.Parent)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return NodeID.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetMvcSecurityTreeEntry obj)
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
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return EntryName + " [" + NodeID.ToString("D") + "]";
        }

        /// <summary>
        /// Provides support for comparing <see cref="WhippetMvcSecurityTreeEntry"/> objects for equality. This class cannot be inherited.
        /// </summary>
        public sealed class WhippetMvcSecurityTreeEntryEqualityComparer : EqualityComparer<WhippetMvcSecurityTreeEntry>, IEqualityComparer<WhippetMvcSecurityTreeEntry>
        {
            private static WhippetMvcSecurityTreeEntryEqualityComparer _default;
            private static WhippetMvcSecurityTreeEntryEqualityComparer _idOnlyExcludeParent;
            private static WhippetMvcSecurityTreeEntryEqualityComparer _idOnlyIncludeParent;

            /// <summary>
            /// Gets the default <see cref="WhippetMvcSecurityTreeEntryEqualityComparer"/> instance. This property is read-only.
            /// </summary>
            public static new WhippetMvcSecurityTreeEntryEqualityComparer Default
            {
                get
                {
                    if (_default == null)
                    {
                        _default = new WhippetMvcSecurityTreeEntryEqualityComparer();
                    }

                    return _default;
                }
            }

            /// <summary>
            /// Gets the <see cref="WhippetMvcSecurityTreeEntryEqualityComparer"/> instance that compares only the <see cref="WhippetMvcSecurityTreeEntry.NodeID"/> values. This property is read-only.
            /// </summary>
            public static WhippetMvcSecurityTreeEntryEqualityComparer IdOnlyExcludeParent
            {
                get
                {
                    if (_idOnlyExcludeParent == null)
                    {
                        _idOnlyExcludeParent = new WhippetMvcSecurityTreeEntryEqualityComparer(true, false);
                    }

                    return _idOnlyExcludeParent;
                }
            }

            /// <summary>
            /// Gets the <see cref="WhippetMvcSecurityTreeEntryEqualityComparer"/> instance that compares the <see cref="WhippetMvcSecurityTreeEntry.NodeID"/> and <see cref="WhippetMvcSecurityTreeEntry.ParentID"/> values. This property is read-only.
            /// </summary>
            public static WhippetMvcSecurityTreeEntryEqualityComparer IdOnlyIncludeParent
            {
                get
                {
                    if (_idOnlyIncludeParent == null)
                    {
                        _idOnlyIncludeParent = new WhippetMvcSecurityTreeEntryEqualityComparer(true, true);
                    }

                    return _idOnlyIncludeParent;
                }
            }

            /// <summary>
            /// Option that allows for comparison by the node IDs only.
            /// </summary>
            private bool CompareByIdOnly
            { get; set; }

            /// <summary>
            /// Option that toggles wheter the parent node is included in the comparison.
            /// </summary>
            private bool IncludeParentNode
            { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryEqualityComparer"/> class with no arguments.
            /// </summary>
            private WhippetMvcSecurityTreeEntryEqualityComparer()
                : this(false, true)
            { }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetMvcSecurityTreeEntryEqualityComparer"/> class with the specified options.
            /// </summary>
            /// <param name="compareByIdOnly">If <see langword="true"/>, will compare the objects based on their ID without including their name.</param>
            /// <param name="includeParentNode">If <see langword="true"/>, will include the parent nodes in the comparison.</param>
            private WhippetMvcSecurityTreeEntryEqualityComparer(bool compareByIdOnly, bool includeParentNode)
                : base()
            {
                CompareByIdOnly = false;
                IncludeParentNode = true;
            }

            /// <summary>
            /// Compares the specified objects for equality.
            /// </summary>
            /// <param name="x">First object to compare.</param>
            /// <param name="y">Second object to compare.</param>
            /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
            public override bool Equals(WhippetMvcSecurityTreeEntry x, WhippetMvcSecurityTreeEntry y)
            {
                bool equals = (x == null && y == null);

                if (!equals && (x != null) && (y != null))
                {
                    if (!CompareByIdOnly && IncludeParentNode)
                    {
                        equals = x.Equals(y);
                    }
                    else if (CompareByIdOnly && !IncludeParentNode)
                    {
                        equals = x.NodeID.Equals(y.NodeID);
                    }
                    else
                    {
                        equals = x.NodeID.Equals(y.NodeID) && (x.ParentID.GetValueOrDefault().Equals(y.ParentID.GetValueOrDefault()));
                    }
                }

                return equals;
            }

            /// <summary>
            /// Gets the hash code for the specified object.
            /// </summary>
            /// <param name="obj">Object to get hash code for.</param>
            /// <returns>Hash code for the specified object.</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public override int GetHashCode(WhippetMvcSecurityTreeEntry obj)
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
        }
    }
}

