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
        }

        public DbSet<CoffeeCup> CoffeeCups { get; set; }
    }
}