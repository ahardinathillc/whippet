using System;
using System.Data;
using System.Collections.ObjectModel;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports
{
    /// <summary>
    /// Represents a flattened Multichannel Order Manager (M.O.M.) tax rate export that exports the tax rate for <see cref="MultichannelOrderManagerPostalCode"/>, <see cref="MultichannelOrderManagerStateProvince"/>, and <see cref="MultichannelOrderManagerCountry"/> objects.
    /// </summary>
    public class MultichannelOrderManagerFlattenedTaxRateExport : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper, IWhippetCloneable, IMultichannelOrderManagerTaxRateExport, IEqualityComparer<IMultichannelOrderManagerTaxRateExport>, IComparable<MultichannelOrderManagerFlattenedTaxRateExport>
    {
        private string _viewName;

        private MultichannelOrderManagerPostalCode _postalCode;
        private MultichannelOrderManagerStateProvince _stateProvince;
        private MultichannelOrderManagerCountry _country;

        /// <summary>
        /// Gets or sets the name of the view that the export utilizes. If set to <see cref="String.Empty"/> or <see langword="null"/>, the default view name will be used.
        /// </summary>
        private string _ViewName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_viewName))
                {
                    _viewName = MultichannelOrderManagerDatabaseConstants.Exports.Views.FlattenedTaxRateExport;
                }

                return _viewName;
            }
            set
            {
                _viewName = value;
            }
        }

        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return _ViewName;
            }
        }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        public virtual decimal TaxRate
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerPostalCode PostalCode
        {
            get
            {
                if (_postalCode == null)
                {
                    _postalCode = new MultichannelOrderManagerPostalCode();
                }

                return _postalCode;
            }
            set
            {
                _postalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerPostalCode IMultichannelOrderManagerTaxRateExport.PostalCode
        {
            get
            {
                return PostalCode;
            }
            set
            {
                PostalCode = value.ToMultichannelOrderManagerPostalCode();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerStateProvince StateProvince
        {
            get
            {
                if (_postalCode == null)
                {
                    _stateProvince = new MultichannelOrderManagerStateProvince();
                }

                return _stateProvince;
            }
            set
            {
                _stateProvince = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerStateProvince"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerStateProvince IMultichannelOrderManagerTaxRateExport.StateProvince
        {
            get
            {
                return StateProvince;
            }
            set
            {
                StateProvince = value.ToMultichannelOrderManagerStateProvince();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        public virtual MultichannelOrderManagerCountry Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new MultichannelOrderManagerCountry();
                }

                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerCountry"/> that the tax rate applies to.
        /// </summary>
        IMultichannelOrderManagerCountry IMultichannelOrderManagerTaxRateExport.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = value.ToMultichannelOrderManagerCountry();
            }
        }

        /// <summary>
        /// Specifies whether shipping should be taxed.
        /// </summary>
        public virtual bool TaxShipping
        { get; set; }

        /// <summary>
        /// Specifies whether non-tangible products (such as services, including subscription-based software) should be taxed.
        /// </summary>
        public virtual bool TaxServices
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> that the export was generated from.
        /// </summary>
        IMultichannelOrderManagerServer IMultichannelOrderManagerTaxRateExport.Server
        {
            get
            {
                return ((IMultichannelOrderManagerEntity)(this)).Server;
            }
            set
            {
                ((IMultichannelOrderManagerEntity)(this)).Server = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerFlattenedTaxRateExport()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with the specified table or view name.
        /// </summary>
        /// <param name="tableOrViewName">Name of the table or view to extract the data from.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerFlattenedTaxRateExport(string tableOrViewName)
            : this()
        {
            if (String.IsNullOrWhiteSpace(tableOrViewName))
            {
                throw new ArgumentNullException(nameof(tableOrViewName));
            }
            else
            {
                _ViewName = tableOrViewName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with the specified <see cref="IMultichannelOrderManagerTaxRateExport"/> object.
        /// </summary>
        /// <param name="export"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        public MultichannelOrderManagerFlattenedTaxRateExport(IMultichannelOrderManagerTaxRateExport export)
            : this((export == null) ? default(decimal) : export.TaxRate, (export == null) ? null : export.PostalCode.ToMultichannelOrderManagerPostalCode(), (export == null) ? null : export.StateProvince.ToMultichannelOrderManagerStateProvince(), (export == null) ? null : export.Country.ToMultichannelOrderManagerCountry())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with the specified <see cref="IMultichannelOrderManagerTaxRateExport"/> object.
        /// </summary>
        /// <param name="export"><see cref="IMultichannelOrderManagerTaxRateExport"/> object.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerFlattenedTaxRateExport(IMultichannelOrderManagerTaxRateExport export, string tableOrViewName)
            : this((export == null) ? default(decimal) : export.TaxRate, tableOrViewName, (export == null) ? null : export.PostalCode.ToMultichannelOrderManagerPostalCode(), (export == null) ? null : export.StateProvince.ToMultichannelOrderManagerStateProvince(), (export == null) ? null : export.Country.ToMultichannelOrderManagerCountry())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with the specified parameters.
        /// </summary>
        /// <param name="rate">Tax rate.</param>
        /// <param name="postalCode">Postal code the rate applies to.</param>
        /// <param name="stateProvince">State/province the rate applies to.</param>
        /// <param name="country">Country the rate applies to.</param>
        public MultichannelOrderManagerFlattenedTaxRateExport(decimal rate, MultichannelOrderManagerPostalCode postalCode = null, MultichannelOrderManagerStateProvince stateProvince = null, MultichannelOrderManagerCountry country = null)
            : this()
        {
            TaxRate = rate;
            PostalCode = postalCode;
            StateProvince = stateProvince;
            Country = country;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> class with the specified parameters.
        /// </summary>
        /// <param name="rate">Tax rate.</param>
        /// <param name="tableOrViewName">Name of the table or view to extract the data from.</param>
        /// <param name="postalCode">Postal code the rate applies to.</param>
        /// <param name="stateProvince">State/province the rate applies to.</param>
        /// <param name="country">Country the rate applies to.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerFlattenedTaxRateExport(decimal rate, string tableOrViewName, MultichannelOrderManagerPostalCode postalCode = null, MultichannelOrderManagerStateProvince stateProvince = null, MultichannelOrderManagerCountry country = null)
            : this(rate, postalCode, stateProvince, country)
        {
            if (String.IsNullOrWhiteSpace(tableOrViewName))
            {
                throw new ArgumentNullException(nameof(tableOrViewName));
            }
            else
            {
                _ViewName = tableOrViewName;
            }
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            WhippetDataRowImportMapEntry rate = new WhippetDataRowImportMapEntry(nameof(TaxRate), MultichannelOrderManagerDatabaseConstants.Exports.Columns.RATE);
            WhippetDataRowImportMapEntry postalCode = new WhippetDataRowImportMapEntry(nameof(PostalCode), MultichannelOrderManagerDatabaseConstants.Exports.Columns.ZIPCODE);
            WhippetDataRowImportMapEntry state = new WhippetDataRowImportMapEntry(nameof(StateProvince), MultichannelOrderManagerDatabaseConstants.Exports.Columns.STATE_ID);
            WhippetDataRowImportMapEntry country = new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Exports.Columns.COUNTRY_ID);
            WhippetDataRowImportMapEntry shipping = new WhippetDataRowImportMapEntry(nameof(TaxShipping), MultichannelOrderManagerDatabaseConstants.Exports.Columns.TAX_SHIPPING);
            WhippetDataRowImportMapEntry services = new WhippetDataRowImportMapEntry(nameof(TaxServices), MultichannelOrderManagerDatabaseConstants.Exports.Columns.TAX_SAAS);

            return new WhippetDataRowImportMap(new[]
            {
                rate,
                postalCode,
                state,
                country,
                shipping,
                services
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                WhippetDataRowImportMap map = (importMap == null ? ImportMap : importMap);

                TaxRate = dataRow.Field<decimal>(map[nameof(TaxRate)].Column);
                PostalCode = new MultichannelOrderManagerPostalCode() { PostalCode = dataRow.Field<string>(map[nameof(PostalCode)].Column) };
                StateProvince = new MultichannelOrderManagerStateProvince(dataRow.Field<int?>(map[nameof(StateProvince)].Column).GetValueOrDefault());
                Country = new MultichannelOrderManagerCountry(dataRow.Field<int?>(map[nameof(Country)].Column).GetValueOrDefault());
                TaxShipping = dataRow.Field<bool?>(map[nameof(TaxShipping)].Column).GetValueOrDefault();
                TaxServices = dataRow.Field<bool?>(map[nameof(TaxServices)].Column).GetValueOrDefault();
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = ImportMap;
            DataTable table = new DataTable();

            DataColumn taxRate = DataColumnFactory.CreateDataColumn(map[nameof(TaxRate)].Column, typeof(decimal), false);
            DataColumn postalCode = DataColumnFactory.CreateDataColumn(map[nameof(PostalCode)].Column, typeof(string), true, 20);
            DataColumn state = DataColumnFactory.CreateDataColumn(map[nameof(StateProvince)].Column, typeof(int), true);
            DataColumn country = DataColumnFactory.CreateDataColumn(map[nameof(Country)].Column, typeof(int), true);
            DataColumn taxShipping = DataColumnFactory.CreateDataColumn(map[nameof(TaxShipping)].Column, typeof(bool), false);
            DataColumn taxServices = DataColumnFactory.CreateDataColumn(map[nameof(TaxServices)].Column, typeof(bool), false);

            table.Columns.AddRange(new[]
            {
                taxRate,
                postalCode,
                state,
                country,
                taxShipping,
                taxServices
            });

            return table;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is IMultichannelOrderManagerTaxRateExport)) ? false : Equals((IMultichannelOrderManagerTaxRateExport)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerTaxRateExport obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerTaxRateExport x, IMultichannelOrderManagerTaxRateExport y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    ((x.Country == null && y.Country == null) || (x.Country != null && x.Country.Equals(y.Country)))
                        && ((x.PostalCode == null && y.PostalCode == null) || (x.PostalCode != null && x.PostalCode.Equals(y.PostalCode)))
                        && ((x.StateProvince == null && y.StateProvince == null) || (x.StateProvince != null && x.StateProvince.Equals(y.StateProvince)))
                        && (x.TaxRate == y.TaxRate)
                        && (x.TaxServices == y.TaxServices)
                        && (x.TaxShipping == y.TaxShipping);
            }

            return equals;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public virtual object Clone()
        {
            MultichannelOrderManagerFlattenedTaxRateExport export = new MultichannelOrderManagerFlattenedTaxRateExport();

            export.Country = Country.Clone<MultichannelOrderManagerCountry>();
            export.MomObjectID = MomObjectID;
            export.PostalCode = PostalCode.Clone<MultichannelOrderManagerPostalCode>();
            export.Server = Server.Clone<MultichannelOrderManagerServer>();
            export.StateProvince = StateProvince.Clone<MultichannelOrderManagerStateProvince>();
            export.TaxRate = TaxRate;
            export.TaxServices = TaxServices;
            export.TaxShipping = TaxShipping;

            return export;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IMultichannelOrderManagerTaxRateExport"/> object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        public virtual int GetHashCode(IMultichannelOrderManagerTaxRateExport obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }

        /// <summary>
        /// Compares the current instance to the specified <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> for determining sort order.
        /// </summary>
        /// <param name="obj"><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> to compare against.</param>
        /// <returns>A signed integer that indicates the relative values of the current object and <paramref name="obj"/>. Values less than zero indicates that the current object precedes <paramref name="obj"/>; zero indicates that the values are equal; and values greater than zero indicate that the current object follows <paramref name="obj"/>.</returns>
        public virtual int CompareTo(MultichannelOrderManagerFlattenedTaxRateExport obj)
        {
            return IMultichannelOrderManagerPostalCodeComparer.Instance.Compare(PostalCode, (obj == null) ? null : obj.PostalCode);
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

        /// <summary>
        /// Provides an <see cref="IComparer{T}"/> for <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class MultichannelOrderManagerFlattenedTaxRateExportComparer : IComparer<MultichannelOrderManagerFlattenedTaxRateExport>
        {
            private static MultichannelOrderManagerFlattenedTaxRateExportComparer _instance;

            /// <summary>
            /// Gets a singleton instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportComparer"/> class. This property is read-only.
            /// </summary>
            public static MultichannelOrderManagerFlattenedTaxRateExportComparer Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new MultichannelOrderManagerFlattenedTaxRateExportComparer();
                    }

                    return _instance;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportComparer"/> class with no arguments.
            /// </summary>
            private MultichannelOrderManagerFlattenedTaxRateExportComparer()
            { }

            /// <summary>
            /// Compares two objects and returns an indication of their relative sort order.
            /// </summary>
            /// <param name="x">An object to compare to <paramref name="y"/>.</param>
            /// <param name="y">An object to compare to <paramref name="x"/>.</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>. Values less than zero indicates that <paramref name="x"/> precedes <paramref name="y"/>; zero indicates that the values are equal; and values greater than zero indicate that <paramref name="x"/> follows <paramref name="y"/>.</returns>
            public int Compare(MultichannelOrderManagerFlattenedTaxRateExport x, MultichannelOrderManagerFlattenedTaxRateExport y)
            {
                int compareResult = 0;

                if (x != null && y != null)
                {
                    compareResult = x.CompareTo(y);
                }
                else if (x != null && y == null)
                {
                    compareResult = 1;
                }
                else if (x == null && y != null)
                {
                    compareResult = -1;
                }

                return compareResult;
            }
        }
    }
}
