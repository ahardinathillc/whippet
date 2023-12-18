using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data.NHibernate.FluentNHibernate;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory.EntityMappings
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="Warehouse"/> objects.
    /// </summary>
    public class WarehouseMap : MultichannelOrderManagerAuditableFluentMap<Warehouse>
    {
        private const string TABLE_NAME = "WAREHOUS";

        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseMap"/> class with no arguments.
        /// </summary>
        public WarehouseMap()
            : base(TABLE_NAME, null, true)
        {
            Map(w => w.Code).Not.Nullable().Length(6).Default(String.Empty);
            Map(w => w.Description).Not.Nullable().Length(30).Default(String.Empty);

            Component(warehouse => warehouse.Address, address =>
            {
                address.Map(a => a.LineOne).Column("ADDR").Not.Nullable().Length(30).Default(String.Empty);
                address.Map(a => a.LineTwo).Column("ADDR2").Not.Nullable().Length(30).Default(String.Empty);
                address.Map(a => a.City).Column("CITY").Not.Nullable().Length(30).Default(String.Empty);
                address.Map(a => a.State).Column("STATE").Not.Nullable().Length(30).Default(String.Empty);
                address.Map(a => a.PostalCode).Column("ZIPCODE").Not.Nullable().Length(10).Default(String.Empty);
                address.Map(a => a.CountryCode).Column("COUNTRY").Not.Nullable().Length(3).Default(String.Empty);
            });
            
            Map(w => w.UPS_Canada_ID).Column("UPSCA_ID").Not.Nullable().Length(10).Default(String.Empty);
            Map(w => w.IsRetail).Column("RETAIL").Not.Nullable();
            Map(w => w.CustomerNumber).Column("CUSTNUM").Not.Nullable();
            Map(w => w.IsPickup).Column("IS_PICKUP").Not.Nullable();
            Map(w => w.AddressID).Column("ADDR_ID").Not.Nullable().Length(32).Default(String.Empty);
            Map(w => w.FedEx_ID).Column("SH_FEX_ID").Not.Nullable().Length(32).Default(String.Empty);
            Map(w => w.UPS_ID).Column("SH_UPS_ID").Not.Nullable().Length(32).Default(String.Empty);
            Map(w => w.USPS_ID).Column("SH_USP_ID").Not.Nullable().Length(32).Default(String.Empty);
        }
        
        /// <summary>
        /// Configures the default bindings and map setup. This is method is called from the constructor.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="MultichannelOrderManagerFluentMap{T}.DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected override void ConfigureDefaultBindings(string table, string schema, bool useDefaultPrimaryKeyBinding)
        {
            base.ConfigureDefaultBindings(table, schema, false);
            Id(w => w.ID).Column("WAREHOUS_ID").Not.Nullable().GeneratedBy.Identity();
        }
    }
}
