using System;
using System.Collections.ObjectModel;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all <see cref="MagentoEntity"/> command objects that support the bulk API. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IMagentoEntity"/> object type the command acts upon.</typeparam>
    public abstract class MagentoEntityBulkCommandBase<TEntity> : WhippetCommand, IWhippetCommand, IMagentoEntityBulkCommand<TEntity>
        where TEntity : IMagentoEntity
    {
        private readonly IEnumerable<TEntity> _Entities;

        private ReadOnlyCollection<TEntity> _readOnlyEntities;

        /// <summary>
        /// Read-only collection of all <typeparamref name="TEntity"/> objects in the command. This property is read-only.
        /// </summary>
        public IReadOnlyList<TEntity> Entities
        {
            get
            {
                if (_readOnlyEntities == null)
                {
                    if (_Entities != null)
                    {
                        if (_Entities is IList<TEntity>)
                        {
                            _readOnlyEntities = new ReadOnlyCollection<TEntity>((IList<TEntity>)(_Entities));
                        }
                        else
                        {
                            _readOnlyEntities = new ReadOnlyCollection<TEntity>(new List<TEntity>(_Entities));
                        }
                    }
                }

                return _readOnlyEntities;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityBulkCommandBase{TEntity}"/> class with no arguments.
        /// </summary>
        private MagentoEntityBulkCommandBase()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityBulkCommandBase{TEntity}"/> class with the specified <see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.
        /// </summary>
        /// <param name="entities"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MagentoEntityBulkCommandBase(IEnumerable<TEntity> entities)
            : this()
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            else
            {
                _Entities = entities;
            }
        }
    }
}
