using CustomerStorage.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerStorage.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Database.EnsureCreatedAsync();

            builder.Entity<Customer>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
