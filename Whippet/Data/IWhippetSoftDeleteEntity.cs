using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides a <see cref="Boolean"/> field to <see cref="IWhippetEntity"/> objects that indicates whether they are currently marked as "Deleted" in the data store.
    /// </summary>
    public interface IWhippetSoftDeleteEntity : IWhippetEntity
    {
        /// <summary>
        /// Indicates whether the current <see cref="IWhippetEntity"/> is deleted.
        /// </summary>
        bool Deleted
        { get; set; }
    }
}
