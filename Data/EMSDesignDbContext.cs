using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EMS_App.Data
{
    public class EMSDesignDbContext : IDesignTimeDbContextFactory<EMSContext>
    {
        public EMSContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var bldr = new DbContextOptionsBuilder<EMSContext>();
            var con_str = config.GetConnectionString("EMSContext");
            bldr.UseSqlServer(con_str, b => b.MigrationsAssembly("EMS_App"));

            return new EMSContext(bldr.Options);

        }
    }
}
