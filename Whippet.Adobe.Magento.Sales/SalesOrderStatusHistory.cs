using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents an <see cref="ISalesOrder"/> status history entry.
    /// </summary>
    public struct SalesOrderStatusHistory : IExtensionInterfaceMap<SalesOrderStatusHistoryInterface>
    {
        private ISalesOrder _order;
        
        /// <summary>
        /// Gets or sets the ID of the history entry.
        /// </summary>
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the status history comment.
        /// </summary>
        public string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entry was created.
        /// </summary>
        public Instant? CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        public string EntityName
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is notified upon history entry creation.
        /// </summary>
        public bool CustomerNotified
        { get; set; }

        /// <summary>
        /// Specifies whether the status entry is visible on the storefront.
        /// </summary>
        public bool VisibleOnStorefront
        { get; set; }

        /// <summary>
        /// Gets or sets the status description.
        /// </summary>
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ISalesOrder"/> the status entry is for.
        /// </summary>
        public ISalesOrder ParentOrder
        {
            get
            {
                if (_order == null)
                {
                    _order = new SalesOrder();
                }

                return _order;
            }
            set
            {
                _order = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderStatusHistory"/> struct with no arguments.
        /// </summary>
        static SalesOrderStatusHistory()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderStatusHistory"/> struct with no arguments.
        /// </summary>
        public SalesOrderStatusHistory()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderStatusHistory"/> struct with the specified <see cref="SalesOrderStatusHistoryInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesOrderStatusHistoryInterface"/> object.</param>
        public SalesOrderStatusHistory(SalesOrderStatusHistoryInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderStatusHistory"/> struct with the specified parameters.
        /// </summary>
        /// <param name="id">History entry ID.</param>
        /// <param name="comment">Entry comment.</param>
        /// <param name="createdTimestamp">Timestamp of when the entry was created.</param>
        /// <param name="entityName">Entity name.</param>
        /// <param name="customerNotified">Specifies whether the customer was notified when the entry was created.</param>
        /// <param name="visibleOnFront">Specifies whether the entry is visible on the storefront.</param>
        /// <param name="parent">Parent <see cref="ISalesOrder"/> object.</param>
        /// <param name="status">Status description.</param>
        public SalesOrderStatusHistory(int id, string comment, Instant? createdTimestamp, string entityName, bool customerNotified, bool visibleOnFront, ISalesOrder parent, string status)
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
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderStatusHistoryInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderStatusHistoryInterface"/>.</returns>
        public SalesOrderStatusHistoryInterface ToInterface()
        {
            SalesOrderStatusHistoryInterface sInterface = new SalesOrderStatusHistoryInterface();

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
        /// <param name="model"><see cref="SalesOrderStatusHistoryInterface"/> object used to populate the object.</param>
        public void FromModel(SalesOrderStatusHistoryInterface model)
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
