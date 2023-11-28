using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="MagentoEntity"/> objects accessible by a RESTful interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="WhippetEntity"/> object to store in the repository.</typeparam>
    public interface IMagentoEntityRepository<TEntity> : IWhippetEntityRepository<TEntity, uint>, IWhippetRepository<TEntity, uint>, IWhippetRestRepository<TEntity, uint>, IDisposable
        where TEntity : MagentoEntity, IMagentoEntity, new()
    { }
}        
