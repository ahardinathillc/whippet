using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using NodaTime;
using Dynamitey;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Base class for all Multichannel Order Manager (M.O.M.) objects. This class must be inherited.
    /// </summary>
    public abstract class MultichannelOrderManagerEntity : WhippetEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IJsonObject
    {
        private MultichannelOrderManagerServer _server;

        private WhippetDataRowImportMap _internalMap;

        /// <summary>
        /// Gets the <see cref="WhippetDataRowImportMap"/> object for the current object. This property is read-only.
        /// </summary>
        public WhippetDataRowImportMap ImportMap
        {
            get
            {
                if (_internalMap == null)
                {
                    _internalMap = CreateImportMap();
                }

                return _internalMap;
            }
        }

        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public override Guid ID
        {
            get
            {
                byte[] bytes = new byte[16];
                Array.Copy(BitConverter.GetBytes(MomObjectID), bytes, sizeof(long));
                return new Guid(bytes);
            }
            set
            {
                if (BitConverter.ToInt64(value.ToByteArray(), sizeof(long)) != 0)
                {
                    throw new OverflowException();
                }
                else
                {
                    MomObjectID = BitConverter.ToInt64(value.ToByteArray(), 0);
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique record ID of the <see cref="MultichannelOrderManagerEntity"/> instance.
        /// </summary>
        protected virtual long MomObjectID
        { get; set; }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return ExternalTableName;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only. This property must be overridden.
        /// </summary>
        protected abstract string ExternalTableName
        { get; }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerServer"/> object that the <see cref="IMultichannelOrderManagerEntity"/> is registered with.
        /// </summary>
        public virtual MultichannelOrderManagerServer Server
        {
            get
            {
                if (_server == null)
                {
                    _server = new MultichannelOrderManagerServer();
                }

                return _server;
            }
            set
            {
                _server = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="IMultichannelOrderManagerServer"/> object that the <see cref="IMultichannelOrderManagerCustomer"/> is registered with.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerEntity.Server
        {
            get
            {
                return Server;
            }
            set
            {
                Server = value.ToMultichannelOrderManagerServer();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntity"/> class with no arguments.
        /// </summary>
        protected MultichannelOrderManagerEntity()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the object.</param>
        protected MultichannelOrderManagerEntity(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity. This method must be overridden.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public abstract WhippetDataRowImportMap CreateImportMap();

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public abstract void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null);

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity. This method must be overridden.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public abstract DataTable CreateDataTable();

        /// <summary>
        /// Imports the specified <see langword="dynamic"/> object containing information needed to populate the <see cref="IWhippetEntity"/>.
        /// </summary>
        /// <param name="dynObj"><see langword="dynamic"/> object containing the data to import.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void ImportObject(dynamic dynObj)
        {
            if (dynObj == null)
            {
                throw new ArgumentNullException(nameof(dynObj));
            }
            else
            {
                DataTable table = CreateDataTable();
                DataRow row = table.NewRow();

                object rowValue = null;

                foreach (DataColumn column in table.Columns)
                {
                    rowValue = Dynamic.InvokeGet(dynObj, column.ColumnName);

                    if (rowValue == null)
                    {
                        if (column.DataType.Equals(typeof(char)))
                        {
                            rowValue = ' ';
                        }
                        else if (column.DataType.Equals(typeof(string)))
                        {
                            rowValue = String.Empty;
                        }
                        else if (column.DataType.Equals(typeof(bool)))
                        {
                            rowValue = default(bool);
                        }
                        else
                        {
                            rowValue = DBNull.Value;
                        }
                    }

                    row[column] = rowValue;
                }

                ImportDataRow(row);
            }
        }

        /// <summary>
        /// Creates a new <see cref="DataRow"/> that represents the current entity's state.
        /// </summary>
        /// <returns><see cref="DataRow"/> object containing the values of the current entity.</returns>
        public virtual DataRow CreateDataRow()
        {
            return this.CreateDataRow__Internal();
        }

        /// <summary>
        /// Converts the specified nullable <see cref="DateTime"/> value to a nullable <see cref="Instant"/>.
        /// </summary>
        /// <param name="value">Nullable <see cref="DateTime"/> value.</param>
        /// <returns>Nullable <see cref="Instant"/> value.</returns>
        protected Instant? ToNullableInstant(DateTime? value)
        {
            Instant? instValue = null;

            if (value.HasValue)
            {
                if (value.Value.Kind == DateTimeKind.Utc)
                {
                    instValue = Instant.FromDateTimeUtc(value.Value);
                }
                else
                {
                    instValue = Instant.FromDateTimeUtc(value.Value.ToUniversalTime());
                }
            }

            return instValue;
        }

        /// <summary>
        /// Checks the length of <paramref name="value"/> to ensure that it fits within the column size.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <param name="propertyName">Property name that maps to the appropriate data column.</param>
        /// <param name="allowNull">Indicates whether <see langword="null"/> values are allowed.</param>
        /// <param name="allowWhitespace">Indicates whether values of blank or whitespace are allowed.</param>
        /// <returns>Value that was supplied if no exceptions.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException" />
        protected virtual string EnsureLength(string value, string propertyName, bool allowNull = false, bool allowWhitespace = true)
        {
            if (String.IsNullOrWhiteSpace(value) && !allowWhitespace)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (String.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            else
            {
                this.CheckLengthRequirement(value, ImportMap[propertyName].Column, allowNull);
                return value;
            }
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}
