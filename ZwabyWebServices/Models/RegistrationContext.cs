using System;
using Microsoft.EntityFrameworkCore;

namespace ZwabyWebServices.Models
{
    public class RegistrationContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=zwabydb.database.windows.net;Database=zwabydb;User Id=zwabydb;Password=Zwabyazure00;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.EmailAddress).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
            });
        }
    }
}
