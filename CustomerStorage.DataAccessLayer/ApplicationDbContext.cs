using CustomerStorage.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerStorage.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasIndex(u => u.Name)
            .IsUnique();

            builder.Entity<Customer>().HasQueryFilter(e => !e.IsRemoved);
        }
    }
}
