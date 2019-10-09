using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class ProjectKaffekopContext: DbContext
    {
        public ProjectKaffekopContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoffeeCup>()
                .HasKey(cc => new {cc.Id});

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderLine>()
                .HasKey((ol => new { ol.ProductId, ol.OrderId }));

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);
        }

        public DbSet<CoffeeCup> CoffeeCups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
