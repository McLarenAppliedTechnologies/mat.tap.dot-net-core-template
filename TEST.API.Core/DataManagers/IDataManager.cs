using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.API.Core.DataManagers
{
    /// <summary>
    /// Generic interface for database (or some other storage) entities.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <typeparam name="TKey">Key type.</typeparam>
    public interface IDataManager<TEntity, in TKey> :IDisposable
    {
        /// <summary>
        /// Gets all items query.
        /// </summary>
        /// <param name="dbContext"></param>
        IQueryable<TEntity> GetAllItemsQuery(DbContext dbContext);

        /// <summary>
        /// Gets items query page.
        /// </summary>
        IQueryable<TEntity> GetItemsPageQuery(DbContext dbContext, int page = 0, int pageSize = 50);

        /// <summary>
        /// Gets item by ID.
        /// </summary>
        Task<TEntity> GetItemById(DbContext dbContext, TKey id);

        /// <summary>
        /// Updates entity in storage.
        /// </summary>
        Task UpdateEntity(DbContext dbContext, TEntity entity);

        /// <summary>
        /// Adds new entity to storage.
        /// </summary>
        Task<TEntity> AddEntity(DbContext context, TEntity newEntity);

        /// <summary>
        /// Delete entity from storage.
        /// </summary>
        Task DeleteEntity(DbContext dbContext, TKey id);
    }
}
