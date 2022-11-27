using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using DiscountProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new DiscountMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
