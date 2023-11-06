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
    public sealed class WhippetSqlServerSensitivityProperty
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SensitivityProperty"/> object.
        /// </summary>
        private SensitivityProperty InternalObject
        { get; set; }

        /// <summary>
        /// Represents the Data Classification Sensitivity Information for columns as configured in the database. This property is read-only.
        /// </summary>
        public WhippetSqlServerInformationType InformationType
        {
            get
            {
                return InternalObject.InformationType;
            }
        }

        /// <summary>
        /// Returns the label for the current object. This property is read-only.
        /// </summary>
        public WhippetSqlServerLabel Label
        {
            get
            {
                return InternalObject.Label;
            }
        }

        /// <summary>
        /// Gets the sensitivity rank for the current object. This property is read-only.
        /// </summary>
        public SensitivityRank SensitivityRank
        {
            get
            {
                return InternalObject.SensitivityRank;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerSensitivityProperty"/> class with the specified <see cref="SensitivityProperty"/> object.
        /// </summary>
        /// <param name="prop"><see cref="SensitivityProperty"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerSensitivityProperty(SensitivityProperty prop)
        {
            if (prop == null)
            {
                throw new ArgumentNullException(nameof(prop));
            }
            else
            {
                InternalObject = prop;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerSensitivityProperty"/> class.
        /// </summary>
        /// <param name="label">Label for the object.</param>
        /// <param name="informationType">Information type for the object.</param>
        /// <param name="sensitivityRank">Sensitivity rank for the object.</param>
        public WhippetSqlServerSensitivityProperty(WhippetSqlServerLabel label, WhippetSqlServerInformationType informationType, SensitivityRank sensitivityRank)
            : this(new SensitivityProperty(label, informationType, sensitivityRank))
        { }

        public static implicit operator WhippetSqlServerSensitivityProperty(SensitivityProperty prop)
        {
            return (prop == null) ? null : new WhippetSqlServerSensitivityProperty(prop);
        }

        public static implicit operator SensitivityProperty(WhippetSqlServerSensitivityProperty prop)
        {
            return (prop == null) ? null : prop.InternalObject;
        }
    }
}
