using System;
using Newtonsoft.Json.Linq;
using Athi.Whippet.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Base class for all Magento domain objects in Whippet. This class must be inherited.
    /// </summary>
    public abstract class MagentoEntity : WhippetEntity, IWhippetEntity, IMagentoEntity, IJsonObject
    {
        private MagentoServer _server;
        private MagentoRestEndpoint _restEndpoint;

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        public new virtual uint ID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MagentoServer"/> that the <see cref="MagentoEntity"/> resides on.
        /// </summary>
        public virtual MagentoServer Server
        {
            get
            {
                if (_server == null)
                {
                    _server = new MagentoServer();
                }

                return _server;
            }
            set
            {
                _server = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MagentoRestEndpoint"/> that the <see cref="MagentoEntity"/> resides on.
        /// </summary>
        public virtual MagentoRestEndpoint RestEndpoint
        {
            get
            {
                if (_restEndpoint == null)
                {
                    _restEndpoint = new MagentoRestEndpoint();
                }

                return _restEndpoint;
            }
            set
            {
                _restEndpoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMagentoServer"/> that the <see cref="IMagentoEntity"/> resides on.
        /// </summary>
        IMagentoServer IMagentoEntity.Server
        {
            get
            {
                return Server;
            }
            set
            {
                Server = value?.ToMagentoServer();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IMagentoRestEndpoint"/> that the <see cref="IMagentoEntity"/> resides on.
        /// </summary>
        IMagentoRestEndpoint IMagentoEntity.RestEndpoint
        {
            get
            {
                return RestEndpoint;
            }
            set
            {
                RestEndpoint = value.ToMagentoRestEndpoint();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntity"/> class with no arguments.
        /// </summary>
        protected MagentoEntity()
            : base(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntity"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        protected MagentoEntity(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : this()
        {
            ID = entityId;
            Server = server;
            RestEndpoint = restEndpoint;
        }

        /// <summary>
        /// When overridden in a derived class, returns the current instance as a JSON object in a <see cref="String"/> that is defined by the API documentation in Magento. This is typically used for POST and PUT requests as the default serializer suffices in GET requests.
        /// </summary>
        /// <returns><see cref="String"/> containing the JSON object representation of the current instance.</returns>
        public virtual string ToMagentoJsonString()
        {
            return String.Empty;
        }
    }
}
