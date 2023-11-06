using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;

namespace Athi.Whippet.Data.Database.Microsoft.DataClassification
{
    /// <summary>
    /// Represents the Data Classification Information Labels as received from SQL Server for the active <see cref="WhippetSqlServerDataReader"/>. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerLabel
    {
        /// <summary>
        /// Gets or sets the internal <see cref="Label"/> object.
        /// </summary>
        private Label InternalObject
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
        /// Initializes a new instance of the <see cref="WhippetSqlServerLabel"/> class with the specified <see cref="Label"/> object.
        /// </summary>
        /// <param name="infoLabel"><see cref="Label"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerLabel(Label infoLabel)
        {
            if (infoLabel == null)
            {
                throw new ArgumentNullException(nameof(infoLabel));
            }
            else
            {
                InternalObject = infoLabel;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerLabel"/> class.
        /// </summary>
        /// <param name="name">Name of the information type.</param>
        /// <param name="id">ID of the information type.</param>
        public WhippetSqlServerLabel(string name, string id)
            : this(new Label(name, id))
        { }

        public static implicit operator WhippetSqlServerLabel(Label infoLabel)
        {
            return (infoLabel == null) ? null : new WhippetSqlServerLabel(infoLabel);
        }

        public static implicit operator Label(WhippetSqlServerLabel infoLabel)
        {
            return (infoLabel == null) ? null : infoLabel.InternalObject;
        }
    }
}
