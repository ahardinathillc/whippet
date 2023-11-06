using System;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.UserTypes.NodaTime;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.EntityMappings.Components
{
    /// <summary>
    /// Defines a component mapping for <see cref="MultichannelOrderManagerWarehouse"/> objects.
    /// </summary>
    public class MultichannelOrderManagerWarehouseComponentMap : MultichannelOrderManagerComponentMap<MultichannelOrderManagerWarehouse>
    {
        private const string COMPONENT_COL_PREFIX = "57139f0e";

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouseComponentMap"/> with no arguments.
        /// </summary>
        public MultichannelOrderManagerWarehouseComponentMap()
            : base()
        {
            Map(w => w.AddressID).Length(32).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.AddressID)));
            Map(w => w.AddressLineOne).Length(30).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.AddressLineOne)));
            Map(w => w.AddressLineTwo).Length(30).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.AddressLineTwo)));
            Map(w => w.City).Length(30).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.City)));
            Map(w => w.Code).Length(6).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.Code)));
            Map(w => w.Country).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.Country)));
            Map(w => w.CustomerNumber).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.CustomerNumber)));
            Map(w => w.Description).Length(30).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.Description)));
            Map(w => w.FedEx_ID).Length(32).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.FedEx_ID)));
            Map(w => w.IsPickup).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.IsPickup)));
            Map(w => w.IsRetail).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.IsRetail)));
            Map(w => w.LookupBy).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.LookupBy)));
            Map(w => w.LookupOn).CustomType<NullableInstantUserType>().Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.LookupOn)));
            Map(w => w.MessageOne).Length(35).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.MessageOne)));
            Map(w => w.MessageTwo).Length(35).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.MessageTwo)));
            Map(w => w.State).Length(3).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.State)));
            Map(w => w.UPS_Canada_ID).Length(10).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.UPS_Canada_ID)));
            Map(w => w.UPS_ID).Length(32).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.UPS_ID)));
            Map(w => w.USPS_ID).Length(32).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.USPS_ID)));
            Map(w => w.WarehouseID).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.WarehouseID)));
            Map(w => w.ZipCode).Length(10).Not.Nullable().Column(GenerateColumnName(nameof(MultichannelOrderManagerWarehouse.ZipCode)));

            References<MultichannelOrderManagerServer>(w => w.Server).Not.Nullable().LazyLoad(Laziness.False).Column(GenerateColumnName(COMPONENT_COL_PREFIX + "_Server"));
        }
    }
}

