using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Integrations
{
    /// <summary>
    /// Provides support to objects that map to external objects that are synchronized with internal Whippet instances.
    /// </summary>
    public interface IThirdPartyEntityMap
    {
        /// <summary>
        /// Gets or sets the external server instance that the <see cref="ExternalEntity"/> is hosted on.
        /// </summary>
        /// <exception cref="InvalidCastException" />
        object ExternalServer
        { get; set; }

        /// <summary>
        /// Gets or sets the external object that the <see cref="Entity"/> is synchronized with.
        /// </summary>
        /// <exception cref="InvalidCastException" />
        object ExternalEntity
        { get; set; }

        /// <summary>
        /// Gets or sets the internal object that the <see cref="ExternalEntity"/> is synchronized with.
        /// </summary>
        /// <exception cref="InvalidCastException" />
        object Entity
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, then <see cref="ExternalEntity"/> is read-only and serves as the source of truth. Any changes made to <see cref="ExternalEntity"/> will overwrite <see cref="Entity"/> upon next synchronization.
        /// </summary>
        bool ExternalEntityReadOnly
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, then <see cref="Entity"/> is read-only and serves as the source of truth. Any changes made to <see cref="Entity"/> will overwrite <see cref="ExternalEntity"/> upon next synchronization.
        /// </summary>
        bool EntityReadOnly
        { get; set; }

        /// <summary>
        /// If <see langword="true"/>, then the changes made in both <see cref="ExternalEntity"/> and <see cref="Entity"/> will attempt to be merged with the record's last modified date entry serving as the deciding value in fields that both experienced changes.
        /// </summary>
        bool Bidirectional
        { get; set; }
    }

    /// <summary>
    /// Provides support to objects that map to external objects that are synchronized with internal Whippet instances.
    /// </summary>
    public interface IThirdPartyEntityMap<ExternalServerType, ExternalEntityType, WhippetEntity> : IThirdPartyEntityMap
        where ExternalServerType : class, new()
        where ExternalEntityType: class, new()
        where WhippetEntity: class, IWhippetEntity, new()
    {
        /// <summary>
        /// Gets or sets the external server instance that the <see cref="ExternalEntity"/> is hosted on.
        /// </summary>
        new ExternalServerType ExternalServer
        { get; set; }

        /// <summary>
        /// Gets or sets the external object that the <see cref="Entity"/> is synchronized with.
        /// </summary>
        new ExternalEntityType ExternalEntity
        { get; set; }

        /// <summary>
        /// Gets or sets the internal object that the <see cref="ExternalEntity"/> is synchronized with.
        /// </summary>
        new WhippetEntity Entity
        { get; set; }
    }
}

