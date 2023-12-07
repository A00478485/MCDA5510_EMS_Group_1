using EMS_App.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_App.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Speaker> Speaker { get; set; }





    }
}
