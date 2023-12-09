using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EMS_App.Data
{
    public class EMSDesignDbContext : IDesignTimeDbContextFactory<EMSContext>
    {
        public EMSContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EMSContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new EMSContext(optionsBuilder.Options);
        }
    }
}
