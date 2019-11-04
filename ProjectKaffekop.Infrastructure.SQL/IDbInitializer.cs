namespace ProjectKaffekop.Infrastructure.SQL
{
    public interface IDbInitializer
    {
        void Initialize(ProjectKaffekopContext context);
    }
}