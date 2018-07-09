using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TEST.API.Core.Factories;

namespace TEST.API.Core.DataManagers
{
    public class DataManager<TEntity> : DataManagerBase<TEntity, int> where TEntity : class, IEntity
    {
        public DataManager(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        protected override Expression<Func<TEntity, int>> GetEntityKey()
        {
            return item => item.Id;
        }
    }
}
