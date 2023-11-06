using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using NHibernate.Engine;

namespace Athi.Whippet.Data.NHibernate.UserTypes
{
    /// <summary>
    /// Base class for all custom user type mappings in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetUserTypeBase : IUserType
    {
        /// <summary>
        /// Gets the SQL types for the columns mapped by this type. This property is read-only.
        /// </summary>
        public virtual SqlType[] SqlTypes 
        { get; protected set; } 

        /// <summary>
        /// Gets the type returned by <see cref="NullSafeGet(DbDataReader, string[], ISessionImplementor, object)"/>. This property is read-only.
        /// </summary>
        public virtual Type ReturnedType 
        { get; protected set; }

        /// <summary>
        /// Indicates whether the objects of this type are mutable. This property is read-only.
        /// </summary>
        public virtual bool IsMutable
        { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTypeBase"/> class with no arguments.
        /// </summary>
        protected WhippetUserTypeBase()
        { }

        /// <summary>
        /// Reconstructs an object from the cacheable representation. At the very least, this method should perform a deep 
        /// copy if the type is mutable. See <see cref="IUserType.Disassemble(object)"/>.
        /// </summary>
        /// <param name="cached">The cacheable representation.</param>
        /// <param name="owner">The owner of the cached object.</param>
        /// <returns></returns>
        /// <remarks>Optional operation if the second level cache is not used.</remarks>
        public virtual object Assemble(object cached, object owner)
        {
            return cached;
        }
        
        /// <summary>
        /// Returns a deep copy of the persistent state, stopping at entities and at collections.
        /// </summary>
        /// <param name="value">A collection element or entity field value mapped as this user type.</param>
        /// <returns>A deep copy of the specified object.</returns>
        public virtual object DeepCopy(object value)
        {
            return value;
        }

        /// <summary>
        /// Transforms the object into its cacheable representation. At the very least, this method should perform 
        /// a deep copy if the type is mutable. This may not be enough for some implementations, however; for example, 
        /// associations must be cached as identifier values. Second level cache implementations may have additional 
        /// requirements, like cacheable representation being binary serializable.
        /// </summary>
        /// <param name="value">The object to be cached.</param>
        /// <returns>A cacheable representation of the object.</returns>
        /// <remarks>Optional operation if the second level cache is not used.</remarks>
        public virtual object Disassemble(object value)
        {
            return value;
        }

        //
        // Summary:
        //     Compare two instances of the class mapped by this type for persistent "equality"
        //     ie. equality of persistent state
        //
        // Parameters:
        //   x:
        //
        //   y:

        /// <summary>
        /// Compares two instances of the class mapped by this type for persistent equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public new bool Equals(object x, object y)
        {
            bool equals = (x != null && y != null) && object.ReferenceEquals(x, y);

            if(!equals && (x != null && y != null))
            {
                equals = x.Equals(y);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="x">Object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        public virtual int GetHashCode(object x)
        {
            return (x == null) ? 0 : x.GetHashCode();
        }

        /// <summary>
        /// Retrieves an instance of the mapped class from an ADO result set. Implementors should handle possibility of <see langword="null"/> values. This method must be overridden.
        /// </summary>
        /// <param name="rs"><see cref="DbDataReader"/> object returned from the query.</param>
        /// <param name="names">Column names returned from the query.</param>
        /// <param name="session">The session for which the operation is done.</param>
        /// <param name="owner">The containing entity.</param>
        /// <returns>Value constructed from the data reader.</returns>
        public abstract object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner);

        /// <summary>
        /// Writes an instance of the mapped class to a prepared statement. Implementors should handle possibility of <see langword="null"/> values. A multi-column type should be written to parameters starting from <paramref name="index"/>. This method must be overridden.
        /// </summary>
        /// <param name="cmd"><see cref="DbCommand"/> object containing the command statement.</param>
        /// <param name="value">Object to write.</param>
        /// <param name="index">Command parameter index.</param>
        /// <param name="session">The session for which the operation is done.</param>
        public abstract void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session);

        /// <summary>
        /// During merge, replaces the existing (<paramref name="target"/>) value in the entity that is merging with a new (<paramref name="original"/>) value 
        /// from the detached entity that is being merged. For immutable objects (or <see langword="null"/> values, it is safe to simply return the first parameter. 
        /// For objects with component values, it might make sense to recursively replace component values.
        /// </summary>
        /// <param name="original">The value from the detached entity being merged.</param>
        /// <param name="target">The value in the managed entity.</param>
        /// <param name="owner">The managed entity.</param>
        /// <returns>The value to be merged.</returns>
        public virtual object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}
