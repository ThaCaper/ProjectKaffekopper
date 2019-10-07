using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class ProjectKaffekopContext: DbContext
    {
        public ProjectKaffekopContext(DbContextOptions opt) : base(opt)
        {

        }
<<<<<<< HEAD

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoffeeCup>()
                .HasKey(cc => new {cc.Id});
        }

        public DbSet<CoffeeCup> CoffeeCups { get; set; }
=======
        public DbSet<CoffeeCup> Cups { get; set; }
>>>>>>> e495e884687003176df1e481d3058a0d5bba81da
    }
}