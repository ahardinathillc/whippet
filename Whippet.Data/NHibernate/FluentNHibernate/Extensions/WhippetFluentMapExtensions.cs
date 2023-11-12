using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetFluentMap{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetFluentMapExtensions
    {
        /// <summary>
        /// Maps the <see cref="IWhippetActiveEntity.Active"/> column.
        /// </summary>
        /// <typeparam name="T"><see cref="WhippetEntity"/> type being mapped.</typeparam>
        /// <param name="map"><see cref="WhippetFluentMap{T}"/> object that is creating the Fluent map.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void MapActiveEntity<T>(this WhippetFluentMap<T> map) where T : WhippetEntity, IWhippetActiveEntity, new()
        {
            if(map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }
            else
            {
                map.Map(m => m.Active).Not.Nullable();
            }
        }

        /// <summary>
        /// Maps the <see cref="IWhippetSoftDeleteEntity.Deleted"/> column.
        /// </summary>
        /// <typeparam name="T"><see cref="WhippetEntity"/> type being mapped.</typeparam>
        /// <param name="map"><see cref="WhippetFluentMap{T}"/> object that is creating the Fluent map.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void MapDeletedEntity<T>(this WhippetFluentMap<T> map) where T : WhippetEntity, IWhippetSoftDeleteEntity, new()
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }
            else
            {
                map.Map(m => m.Deleted).Not.Nullable();
            }
        }
    }
}