using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Represents an <see cref="IMagentoEntity"/> command object that supports the bulk API.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IMagentoEntity"/> object type the command acts upon.</typeparam>
    public interface IMagentoEntityBulkCommand<TEntity> : IWhippetCommand
        where TEntity : IMagentoEntity
    {
        /// <summary>
        /// Read-only collection of all <typeparamref name="TEntity"/> objects in the command. This property is read-only.
        /// </summary>
         IReadOnlyList<TEntity> Entities
        { get; }
    }
}
