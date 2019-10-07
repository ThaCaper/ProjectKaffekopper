using Microsoft.EntityFrameworkCore;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class ProjectKaffekopContext: DbContext
    {
        public ProjectKaffekopContext(DbContextOptions opt) : base(opt)
        {

        }

    }
}