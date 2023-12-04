using Microsoft.EntityFrameworkCore;

namespace EMS_App.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    
        
    }
}
