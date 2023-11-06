using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;

namespace Athi.Whippet.Data.Database.Microsoft.DataClassification
{
    /// <summary>
    /// Provides the functionality to retrieve Sensitivity Classification data as received from SQL Server for the active <see cref="WhippetSqlServerDataReader"/>. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerSensitivityClassification
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SensitivityClassification"/> object.
        /// </summary>
        private SensitivityClassification InternalObject
        { get; set; }

        /// <summary>
        /// Gets the column sensitivity for the current object. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetSqlServerColumnSensitivity> ColumnSensitivities
        {
            get
            {
                return InternalObject.ColumnSensitivities?.Cast<WhippetSqlServerColumnSensitivity>().ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the information types for the current object. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetSqlServerInformationType> InformationTypes
        {
            get
            {
                return InternalObject.InformationTypes?.Cast<WhippetSqlServerInformationType>().ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the labels for the current object. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetSqlServerLabel> Labels
        {
            get
            {
                return InternalObject.Labels?.Cast<WhippetSqlServerLabel>().ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the relative sensitivity rank for the query associated with the active <see cref="WhippetSqlServerDataReader"/>. This property is read-only.
        /// </summary>
        public SensitivityRank SensitivityRank
        {
            get
            {
                return InternalObject.SensitivityRank;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerSensitivityClassification"/> class with the specified <see cref="SensitivityClassification"/> object.
        /// </summary>
        /// <param name="classification"><see cref="SensitivityClassification"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerSensitivityClassification(SensitivityClassification classification)
        {
            if (classification == null)
            {
                throw new ArgumentNullException(nameof(classification));
            }
            else
            {
                InternalObject = classification;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerSensitivityClassification"/> class.
        /// </summary>
        /// <param name="labels">Labels to initialize with.</param>
        /// <param name="informationTypes">Information types to initialize with.</param>
        /// <param name="columnSensitivity">Column sensitivities to initialize with.</param>
        /// <param name="sensitivityRank">Relative sensitivity rank for the query associated with the active <see cref="WhippetSqlServerDataReader"/>.</param>
        public WhippetSqlServerSensitivityClassification(IEnumerable<WhippetSqlServerLabel> labels, IEnumerable<WhippetSqlServerInformationType> informationTypes, IEnumerable<WhippetSqlServerColumnSensitivity> columnSensitivity, SensitivityRank sensitivityRank)
            : this(new SensitivityClassification(labels?.Cast<Label>().ToList(), informationTypes?.Cast<InformationType>().ToList(), columnSensitivity?.Cast<ColumnSensitivity>().ToList(), sensitivityRank))
        { }

        public static implicit operator WhippetSqlServerSensitivityClassification(SensitivityClassification classification)
        {
            return (classification == null) ? null : new WhippetSqlServerSensitivityClassification(classification);
        }

        public static implicit operator SensitivityClassification(WhippetSqlServerSensitivityClassification classification)
        {
            return (classification == null) ? null : classification.InternalObject;
        }
    }
}
