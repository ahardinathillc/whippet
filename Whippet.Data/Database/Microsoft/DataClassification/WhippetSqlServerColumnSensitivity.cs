using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;

namespace Athi.Whippet.Data.Database.Microsoft.DataClassification
{
    /// <summary>
    /// Represents the Data Classification Sensitivity Information for columns as configured in the database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerColumnSensitivity
    {
        /// <summary>
        /// Gets or sets the internal <see cref="ColumnSensitivity"/> object.
        /// </summary>
        private ColumnSensitivity InternalObject
        { get; set; }

        /// <summary>
        /// Gets the list of sensitivity properties as received from the server. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetSqlServerSensitivityProperty> SensitivityProperties
        {
            get
            {
                List<WhippetSqlServerSensitivityProperty> props = new List<WhippetSqlServerSensitivityProperty>();

                if (InternalObject.SensitivityProperties != null && InternalObject.SensitivityProperties.Any())
                {
                    props.AddRange(InternalObject.SensitivityProperties.Cast<WhippetSqlServerSensitivityProperty>());
                }

                return props.AsReadOnly();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerColumnSensitivity"/> class with the specified <see cref="ColumnSensitivity"/> object.
        /// </summary>
        /// <param name="colSens"><see cref="ColumnSensitivity"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerColumnSensitivity(ColumnSensitivity colSens)
        {
            if (colSens == null)
            {
                throw new ArgumentNullException(nameof(colSens));
            }
            else
            {
                InternalObject = colSens;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerColumnSensitivity"/> class with the specified sensitivity properties.
        /// </summary>
        /// <param name="sensitivityProperties">Sensitivity properties to initialize with.</param>
        public WhippetSqlServerColumnSensitivity(IEnumerable<WhippetSqlServerSensitivityProperty> sensitivityProperties)
            : this(new ColumnSensitivity(sensitivityProperties?.Cast<SensitivityProperty>().ToList()))
        { }

        public static implicit operator WhippetSqlServerColumnSensitivity(ColumnSensitivity colSens)
        {
            return (colSens == null) ? null : new WhippetSqlServerColumnSensitivity(colSens);
        }

        public static implicit operator ColumnSensitivity(WhippetSqlServerColumnSensitivity colSens)
        {
            return (colSens == null) ? null : colSens.InternalObject;
        }
    }
}
