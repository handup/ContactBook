using ContactBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}