using System;
using Microsoft.EntityFrameworkCore;

namespace ZwabyWebServices.Models
{
    public class BookingsContext : DbContext
    {
        public virtual DbSet<Booking> Bookings { get; set; }

        public BookingsContext(DbContextOptions<BookingsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.ServiceApproximateDuration).IsRequired();
                entity.Property(e => e.ServiceBathrooms).IsRequired();
                entity.Property(e => e.ServiceBedrooms).IsRequired();
                entity.Property(e => e.ServiceCity).IsRequired();
                entity.Property(e => e.ServiceDate).IsRequired();
                entity.Property(e => e.ServiceDateTime).IsRequired();
                entity.Property(e => e.ServiceNotes).IsRequired();
                entity.Property(e => e.ServicePrice).IsRequired();
                entity.Property(e => e.ServiceResidence).IsRequired();
                entity.Property(e => e.ServiceState).IsRequired();
                entity.Property(e => e.ServiceStreet).IsRequired();
                entity.Property(e => e.ServiceTime).IsRequired();
                entity.Property(e => e.ServiceZipCode).IsRequired();
            });
        }
    }
}
