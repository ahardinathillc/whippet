using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Json;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a domain object in Whippet.
    /// </summary>
    public interface IWhippetEntity : IJsonObject
    {
        /// <summary>
        /// Unique identifier of the entity.
        /// </summary>
        public Guid ID
        { get; set; }
    }
}
