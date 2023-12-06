using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS_App.Models;

namespace EMS_App.Data
{
    public class EMSContext : DbContext
    {
        public EMSContext (DbContextOptions<EMSContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                  .HasKey(m => new { m.Created, m.UserId });
        }

        public DbSet<EMS_App.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<Purchase> Purchase { get; set; } = default;
    }
}
