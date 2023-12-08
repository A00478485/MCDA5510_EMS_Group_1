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
            modelBuilder.Entity<TicketPurchase>()
                  .HasKey(m => new { m.OrderId, m.TicketId });
        }

        public DbSet<Ticket> Ticket { get; set; } = default!;
        public DbSet<Purchase> Purchase { get; set; } = default!;
        public DbSet<Billing> Billing { get; set; } = default!;
        public DbSet<Payment> Payment { get; set; } = default!;
        public DbSet<TicketPurchase> TicketPurchase { get; set; } = default!;
        public DbSet<Event> events { get; set; } = default!;
    }
}
