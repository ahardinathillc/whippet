using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.ComponentModel
{
    /// <summary>
    /// Represents an object that has implements a "Has-A" relationship as opposed to an "Is-A" relationship.
    /// </summary>
    /// <typeparam name="T">Type of object that serves as the basis of the relationship.</typeparam>
    public interface IComposition<T>
    {
        /// <summary>
        /// Gets the parent composition object. This property is read-only.
        /// </summary>
        T ParentObject
        { get; }
    }
}
