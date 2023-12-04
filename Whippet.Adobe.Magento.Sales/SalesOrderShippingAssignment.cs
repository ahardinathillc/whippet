using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Provides shipping information for an <see cref="ISalesOrder"/>.
    /// </summary>
    public struct SalesOrderShippingAssignment : IExtensionInterfaceMap<SalesOrderShippingAssignmentInterface>
    {
        /// <summary>
        /// Gets or sets the shipping information.
        /// </summary>
        public SalesOrderShipping ShippingInformation
        { get; set; }
        
        public IEnumerable<ISalesOrderItem
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with no arguments.
        /// </summary>
        static SalesOrderShippingAssignment()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with no arguments.
        /// </summary>
        public SalesOrderShippingAssignment()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with the specified <see cref="SalesShippingAssignmentInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesShippingAssignmentInterface"/> object.</param>
        public SalesOrderShippingAssignment(SalesShippingAssignmentInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignment"/> struct with the specified parameters.
        /// </summary>
        /// <param name="id">History entry ID.</param>
        /// <param name="comment">Entry comment.</param>
        /// <param name="createdTimestamp">Timestamp of when the entry was created.</param>
        /// <param name="entityName">Entity name.</param>
        /// <param name="customerNotified">Specifies whether the customer was notified when the entry was created.</param>
        /// <param name="visibleOnFront">Specifies whether the entry is visible on the storefront.</param>
        /// <param name="parent">Parent <see cref="ISalesOrder"/> object.</param>
        /// <param name="status">Status description.</param>
        public SalesOrderShippingAssignment(int id, string comment, Instant? createdTimestamp, string entityName, bool customerNotified, bool visibleOnFront, ISalesOrder parent, string status)
            : this()
        {
            ID = id;
            Comment = comment;
            CreatedTimestamp = createdTimestamp;
            EntityName = entityName;
            CustomerNotified = customerNotified;
            VisibleOnStorefront = visibleOnFront;
            ParentOrder = parent;
            Status = status;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesShippingAssignmentInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesShippingAssignmentInterface"/>.</returns>
        public SalesShippingAssignmentInterface ToInterface()
        {
            SalesShippingAssignmentInterface sInterface = new SalesShippingAssignmentInterface();

            sInterface.ID = ID;
            sInterface.Comment = Comment;
            sInterface.CreatedAt = CreatedTimestamp.HasValue ? CreatedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            sInterface.EntityName = EntityName;
            sInterface.CustomerNotified = CustomerNotified.ToMagentoBoolean();
            sInterface.VisibleOnStorefront = VisibleOnStorefront.ToMagentoBoolean();
            sInterface.ParentID = ParentOrder.ID;
            sInterface.Status = Status;

            return sInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesShippingAssignmentInterface"/> object used to populate the object.</param>
        public void FromModel(SalesShippingAssignmentInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Comment = model.Comment;
                CreatedTimestamp = !String.IsNullOrWhiteSpace(model.CreatedAt) ? null : Instant.FromDateTimeUtc(DateTime.Parse(model.CreatedAt).ToUniversalTime(true));
                EntityName = model.EntityName;
                CustomerNotified = model.CustomerNotified.FromMagentoBoolean();
                VisibleOnStorefront = model.VisibleOnStorefront.FromMagentoBoolean();
                ParentOrder = new SalesOrder(Convert.ToUInt32(model.ParentID));
                Status = model.Status;
            }
        }
    }
}
