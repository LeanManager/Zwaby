using System;
using Microsoft.EntityFrameworkCore;

namespace ZwabyWebServices.Models
{
    public class CancellationsContext : DbContext
    {
        public virtual DbSet<Cancellation> Cancellations { get; set; }

        public CancellationsContext(DbContextOptions<CancellationsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancellation>(entity =>
            {
                entity.Property(e => e.CancellationReason).IsRequired();
                entity.Property(e => e.CancellationDate).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.EmailAddress).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
            });
        }
    }
}
