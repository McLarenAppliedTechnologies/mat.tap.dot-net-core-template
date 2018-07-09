using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST.API.Core.Factories;

namespace TEST.API.Core.DataManagers
{
    public abstract class DataManagerBase<TEntity, TKey> : IDataManager<TEntity, TKey> where TEntity : class
    {
        protected IDbContextFactory DbContextfactory { get; private set; }

        protected DataManagerBase(IDbContextFactory dbContextFactory)
        {
            DbContextfactory = dbContextFactory;
        }

        public virtual IQueryable<TEntity> GetAllItemsQuery(DbContext dbContext)
        {
            return DbContextfactory.GetDbSet<TEntity>(dbContext);
        }

        public IQueryable<TEntity> GetItemsPageQuery(DbContext dbContext, int page = 0, int pageSize = 50)
        {
            var items = GetAllItemsQuery(dbContext).Skip(pageSize * page).Take(pageSize);
            return items;
        }

        public async Task<TEntity> GetItemById(DbContext dbContext, TKey id)
        {
            var item = await GetAllItemsQuery(dbContext)
                .FirstOrDefaultAsync(CompareEntityKey(GetEntityKey(), id));
            if (item == null)
            {
                throw new EntityNotFoundException("Item", id);
            }
            return item;
        }

        public virtual async Task UpdateEntity(DbContext dbContext, TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await GetItemById(dbContext, GetEntityKey().Compile()(entity));
                if (item == null)
                {
                    throw new EntityNotFoundException("Item", GetEntityKey().Compile()(entity));
                }
            }
        }

        public virtual async Task<TEntity> AddEntity(DbContext dbContext, TEntity newEntity)
        {
            DbContextfactory.GetDbSet<TEntity>(dbContext).Add(newEntity);
            await dbContext.SaveChangesAsync();
            return newEntity;
        }

        public virtual async Task DeleteEntity(DbContext dbContext, TKey id)
        {
            var entity = await GetItemById(dbContext, id);
            DbContextfactory.GetDbSet<TEntity>(dbContext).Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
        }

        public async Task<bool> Exist(DbContext dbContext, TKey id)
        {
            return await GetAllItemsQuery(dbContext).AnyAsync(CompareEntityKey(GetEntityKey(), id));
        }

        /// <summary>
        /// Implements expression pointing to property that represents the key for the particular entity.
        /// </summary>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, TKey>> GetEntityKey();

        /// <summary>
        /// Helper method allowing compare entities ids in a query to specified constant.
        /// </summary>
        /// <param name="key1">Expression pointing to property that represents the key for the particular entity</param>
        /// <param name="key2">Constant to compare.</param>
        /// <returns>Expression ready to be used in methods like Where, First etc.</returns>
        protected Expression<Func<TEntity, bool>> CompareEntityKey(Expression<Func<TEntity, TKey>> key1, TKey key2)
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(key1.Body, Expression.Constant(key2)),
                key1.Parameters.FirstOrDefault());
        }
    }
}
