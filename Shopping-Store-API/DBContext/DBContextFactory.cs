using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shopping_Store_API.DBContext
{
    public class DBContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // Creator DbContext
        public AppDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext<AppDbContext>(args);
        }
        
        // Factory Method
        private TDbContext CreateDbContext<TDbContext>(string[] args) where TDbContext : DbContext
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ShopDB");

            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return (TDbContext)Activator.CreateInstance(typeof(TDbContext), optionsBuilder.Options);
        }
    }
}
