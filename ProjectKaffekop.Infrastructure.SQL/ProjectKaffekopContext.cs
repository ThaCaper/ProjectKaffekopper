using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class ProjectKaffekopContext: DbContext
    {
        public ProjectKaffekopContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<CoffeeCup> Cups { get; set; }
    }
}