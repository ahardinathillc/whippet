using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;

namespace Athi.Whippet.Data.Database.Microsoft.DataClassification
{
    /// <summary>
    /// Represents the Data Classification Information Types as received from SQL Server for the active <see cref="WhippetSqlServerDataReader"/>. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerInformationType
    {
        /// <summary>
        /// Gets or sets the internal <see cref="InformationType"/> object.
        /// </summary>
        private InformationType InternalObject
        { get; set; }

        /// <summary>
        /// Gets the ID for the current object. This property is read-only.
        /// </summary>
        public string Id
        { 
            get
            {
                return InternalObject.Id;
            }
        }

        /// <summary>
        /// Gets the name for the current object. This property is read-only.
        /// </summary>
        public string Name
        {
            get
            {
                return InternalObject.Name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerInformationType"/> class with the specified <see cref="InformationType"/> object.
        /// </summary>
        /// <param name="infoType"><see cref="InformationType"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerInformationType(InformationType infoType)
        {
            if (infoType == null)
            {
                throw new ArgumentNullException(nameof(infoType));
            }
            else
            {
                InternalObject = infoType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerInformationType"/> class.
        /// </summary>
        /// <param name="name">Name of the information type.</param>
        /// <param name="id">ID of the information type.</param>
        public WhippetSqlServerInformationType(string name, string id)
            : this(new InformationType(name, id))
        { }

        public static implicit operator WhippetSqlServerInformationType(InformationType infoType)
        {
            return (infoType == null) ? null : new WhippetSqlServerInformationType(infoType);
        }

        public static implicit operator InformationType(WhippetSqlServerInformationType infoType)
        {
            return (infoType == null) ? null : infoType.InternalObject;
        }
    }
}
