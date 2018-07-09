using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TEST.API.Core.Factories;

namespace TEST.API.Analytics.API.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<Model> options;

        public DbContextFactory(IConfiguration configuration)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<Model>();
            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options = dbContextOptionsBuilder.Options;
        }

        public DbContext CreateNewDbContext()
        {
            return new Model(options);
        }

        public DbSet<TEntity> GetDbSet<TEntity>(DbContext dbContext) where TEntity : class
        {
            return dbContext.Set<TEntity>();
        }
    }
}
