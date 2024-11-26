using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Persistence
{
    public static partial class PersistenceServiceRegistrtion
    {
        public class ECXHRDbContextFactory
            : IDesignTimeDbContextFactory<OMSDbContext>
        {
            public OMSDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<OMSDbContext>();
                var connectionString = configuration.GetConnectionString("staggingConnectionString");
                builder.UseSqlServer(connectionString);
                return new OMSDbContext(builder.Options);
            }

        }

    }
 
}
