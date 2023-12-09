using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EMS_App.Data
{
    public class EMSContext : IdentityDbContext<IdentityUser>
    {
        public EMSContext()
        {

        }
        public EMSContext (DbContextOptions<EMSContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TicketPurchase>()
                  .HasKey(m => new { m.OrderId, m.TicketId });
        }

        public DbSet<Ticket> Ticket { get; set; } = default!;
        public DbSet<Purchase> Purchase { get; set; } = default!;
        public DbSet<Billing> Billing { get; set; } = default!;
        public DbSet<Payment> Payment { get; set; } = default!;
        public DbSet<TicketPurchase> TicketPurchase { get; set; } = default!;
        public DbSet<Models.Program> events { get; set; } = default!;

        public DbSet<Speaker> Speaker { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
