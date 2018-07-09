using Microsoft.EntityFrameworkCore;

namespace TEST.API.Core.Factories
{
    public interface IDbContextFactory
    {
        DbContext CreateNewDbContext();

        DbSet<TEntity> GetDbSet<TEntity>(DbContext dbContext) where TEntity : class;
    }
}
